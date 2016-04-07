using System.Collections.Generic;
using System.IO;
using System.Linq;
using NCrafts.App.Business.Common.Database.Data;
using NCrafts.App.Business.Core;
using NCrafts.App.Business.Core.Data;
using SQLite.Net;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace NCrafts.App.Business.Common.Database
{
    public class SQLDatabase
    {
        private readonly SQLiteConnection myDb;
        public bool WasInstalled { get; private set; }

        public SQLDatabase()
        {
            var dataBasePath = Path.Combine(DependencyService.Get<IFileHandler>().GetFolderPath(), "myDataBase");
            WasInstalled = DependencyService.Get<IFileHandler>().IsFileExist(dataBasePath);
            myDb = new SQLiteConnection(DependencyService.Get<ISQLitePlatform>(), dataBasePath);
            myDb.CreateTable<DSession>();
            myDb.CreateTable<DSpeaker>();
            myDb.CreateTable<DTag>();
        }

        public void StorageAllToDatabase(IDataSourceRepository dataSourceRepository)
        {
            var sessions = dataSourceRepository.Retreive().Sessions
                .Select(x => new DSession
                {
                    IdString = x.Id.ToString(),
                    Title = x.Title,
                    Description = x.Description,
                    Room = x.Room.Name,
                    Start = x.Interval.StartDate,
                    End = x.Interval.EndDate,
                    IsRegister = x.IsRegister
                });
            InsertObjects(sessions);
            var speakers = dataSourceRepository.Retreive().Speakers
                .Select(x => new DSpeaker
                {
                    IdString = x.Id.ToString(),
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProfilPicture = x.ProfilPicture,
                    Details = x.Details,
                    Company = x.Company,
                    Slide = x.Slide,
                    Site = x.Site,
                    Twitter = x.Twitter,
                    Github = x.Github,
                });
            InsertObjects(speakers);
            var tags = dataSourceRepository.Retreive().Tags
                .Select(x => new DTag
                {
                    Title = x.Title,
                });
            InsertObjects(tags);
        }

        public void GetAllFromDatabase()
        {
            var sessions = myDb.Table<DSession>()
                .Select(x => new Session
                {
                    Id = new SessionId(x.IdString),
                    Title = x.Title,
                    Description = x.Description,
                    Interval = new TimeSlot { StartDate = x.Start, EndDate = x.End},
                    IsRegister = x.IsRegister,
                    Room = new Room { Name = x.Room},
                    SessionsConflit = new List<Session>(),
                    Speakers = new List<SpeakerId>(),
                    Tags = new List<Tag>()
                }).ToList();
            SetTheConflict(sessions);
            var speakers = myDb.Table<DSpeaker>()
                .Select(x => new Speaker
                {
                    Id = new SpeakerId(x.IdString),
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Company = x.Company,
                    Details = x.Details,
                    Github = x.Github,
                    ProfilPicture = x.ProfilPicture,
                    ProfilPictureIcon = x.ProfilPictureIcon,
                    Twitter = x.Twitter,
                    Site = x.Site,
                    Slide = x.Slide,
                    Books = new List<Book>(),
                    Languages = new List<string>()
                });
            var tags = myDb.Table<DTag>()
                .Select(x => new Tag
                {
                    Title = x.Title,
                    Sessions = new List<SessionId>()
                });
        }

        private void SetTheConflict(List<Session> sessions)
        {
            foreach (var session in sessions.Where(session => session.IsRegister))
            {
                session.Register(sessions.Where(x => x.IsRegister).ToList());
            }
        }

        private void InsertOrReplaceObjects<T>(IEnumerable<T> listToInsert)
        {
            foreach (var elem in listToInsert)
            {
                myDb.InsertOrReplace(elem);
            }
        }

        private void InsertObjects<T>(IEnumerable<T> listToInsert)
        {
            foreach (var elem in listToInsert)
            {
                myDb.Insert(elem);
            }
        }
    }
}
