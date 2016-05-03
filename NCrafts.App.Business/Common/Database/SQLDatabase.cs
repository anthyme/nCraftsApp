using System.Collections.Generic;
using System.IO;
using System.Linq;
using NCrafts.App.Business.Common.Database.Data;
using NCrafts.App.Business.Core;
using NCrafts.App.Business.Core.Data;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace NCrafts.App.Business.Common.Database
{
    public class SQLDatabase
    {
        private readonly SQLiteConnection _myDb;
        public bool WasInstalled { get; private set; }

        public SQLDatabase()
        {
            var dataBasePath = Path.Combine(DependencyService.Get<IFileHandler>().GetFolderPath(), "myDataBase.db");
            WasInstalled = DependencyService.Get<IFileHandler>().IsFileExist(dataBasePath);
            _myDb = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(), dataBasePath);
            CreateTable();
        }

        public void StartDatabase(IDataSourceRepository dataSourceRepository)
        {
            if (WasInstalled)
                GetAllFromDatabase(dataSourceRepository);
            else
                StorageAllToDatabase(dataSourceRepository);
        }

        /*
        ###
        **   Method to create and clear Table
        ###
        */

        private void CreateTable()
        {
            _myDb.CreateTable<DBSession>();
            _myDb.CreateTable<DBSpeaker>();
            _myDb.CreateTable<DBTag>();
            _myDb.CreateTable<DBSessionSpeaker>();
            _myDb.CreateTable<DBSessionTag>();
        }

        private void ClearAllTable()
        {
            _myDb.DeleteAll<DBSession>();
            _myDb.DeleteAll<DBTag>();
            _myDb.DeleteAll<DBSession>();
            _myDb.DeleteAll<DBSessionSpeaker>();
            _myDb.DeleteAll<DBSessionTag>();
        }

        /*
        ###
        ** Method to insert in the database
        ###
        */

        // TODO: Change the storage by only checking what has changed
        public void StorageAllToDatabase(IDataSourceRepository dataSourceRepository)
        {
            var speakers = dataSourceRepository.Retreive().Speakers
                .Select(x => new DBSpeaker
                {
                    IdString = x.Id.ToString(),
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProfilPicture = x.ProfilPicture,
                    ProfilPictureIcon = x.ProfilPictureIcon,
                    Details = x.Details,
                    Company = x.Company,
                    Slide = x.Slides,
                    Site = x.Site,
                    Twitter = x.Twitter,
                    Github = x.Github,
                    DSessions = new List<DBSession>()
                }).ToList();
            var tags = dataSourceRepository.Retreive().Tags
                .Select(x => new DBTag
                {
                    Title = x.Title,
                    Sessions = new List<DBSession>()
                }).ToList();

            var sessions = dataSourceRepository.Retreive().Sessions
                .Select(x => new DBSession
                {
                    IdString = x.Id.ToString(),
                    Title = x.Title,
                    Description = x.Description,
                    Room = x.Room.Name,
                    Start = x.Interval.StartDate.ToLocalTime(),
                    End = x.Interval.EndDate.ToLocalTime(),
                    IsRegister = x.IsRegister,
                    DSpeakers = speakers.Where(dspeaker => x.Speakers.Any(speakerSession => speakerSession.ToString() == dspeaker.IdString)).ToList(),
                    Tags = tags.Where(dtag => x.Tags.Any(tagSession => tagSession.Title == dtag.Title)).ToList()
                });

            foreach (var session in sessions)
            {
                foreach (var speaker in session.DSpeakers)
                {
                    speaker.DSessions.Add(session);
                }
                foreach (var tag in session.Tags)
                {
                    tag.Sessions.Add(session);
                }
            }

            ClearAllTable();
            _myDb.InsertAll(tags);
            _myDb.InsertAll(speakers);
            _myDb.InsertAllWithChildren(sessions);
        }

        /*
        ###
        **   Method to update in the database
        ###
        */

        public void UpdateRegistrationSession(Session session)
        {
            var dSession = _myDb.Table<DBSession>().Single(x => x.IdString == session.Id.ToString());
            dSession.IsRegister = session.IsRegister;
            _myDb.Update(dSession);
        }

        /*
        ###
        **   Method to request in the database
        ###
        */

        public void GetAllFromDatabase(IDataSourceRepository dataSourceRepository)
        {
            var speakerMap = _myDb.Table<DBSpeaker>()
                .GroupBy(p => p.IdString)
                .ToDictionary(g => g.Key, g => new Speaker
                {
                    Id = new SpeakerId(g.First().IdString),
                    FirstName = g.First().FirstName,
                    LastName = g.First().LastName,
                    Company = g.First().Company,
                    Details = g.First().Details,
                    Github = g.First().Github,
                    ProfilPicture = g.First().ProfilPicture,
                    ProfilPictureIcon = g.First().ProfilPictureIcon,
                    Twitter = g.First().Twitter,
                    Site = g.First().Site,
                    Slides = g.First().Slide,
                    Books = new List<Book>(),
                    Languages = new List<string>(),
                    Sessions = new List<SessionId>()
                });
            var tagMap = _myDb.Table<DBTag>()
                .GroupBy(p => p.Title)
                .ToDictionary(g => g.Key, g => new Tag
                {
                    Title = g.First().Title,
                    Sessions = new List<SessionId>()
                });
            var sessions = _myDb.GetAllWithChildren<DBSession>()
                 .Select(x => new Session
                 {
                     Id = new SessionId(x.IdString),
                     Title = x.Title,
                     Description = x.Description,
                     Interval = new TimeSlot { StartDate = x.Start, EndDate = x.End },
                     IsRegister = x.IsRegister,
                     Room = new Room { Name = x.Room },
                     SessionsConflit = new List<Session>(),
                     Speakers = x.DSpeakers.Select(speaker => speakerMap[speaker.IdString].Id).ToList(),
                     Tags = x.Tags.Select(tag => tagMap[tag.Title]).ToList(),
                 }).ToList();

            SetTheConflict(sessions);
            ResolveLinkingSession(sessions, speakerMap, tagMap);

            dataSourceRepository.Retreive().Sessions = sessions;
            dataSourceRepository.Retreive().Tags = tagMap.Values.ToList();
            dataSourceRepository.Retreive().Speakers = speakerMap.Values.ToList();
        }

        private static void ResolveLinkingSession(IEnumerable<Session> sessions, IReadOnlyDictionary<string, Speaker> speakerMap, IReadOnlyDictionary<string, Tag> tagMap)
        {
            foreach (var session in sessions)
            {
                foreach (var speaker in session.Speakers)
                {
                    speakerMap[speaker.ToString()].Sessions.Add(session.Id);
                }
                foreach (var tag in session.Tags)
                {
                    tagMap[tag.Title].Sessions.Add(session.Id);
                }
            }
        }

        private static void SetTheConflict(List<Session> sessions)
        {
            foreach (var session in sessions.Where(session => session.IsRegister))
            {
                session.Register(sessions.Where(x => x.IsRegister).ToList());
            }
        }
    }
}
