using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.Network.Data;
using NCrafts.App.Business.Core;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Common
{
    public class NetworkClient
    {
        private readonly HttpClient _client;

        public NetworkClient()
        {
            _client = new HttpClient {BaseAddress = new Uri("http://api.ncrafts.io/events/ncrafts2016/") };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // TODO: try to factorize or find a proper way for request
        public async Task TestSpeakers(IDataSourceRepository dataSourceRepository)
        {
            var response = await _client.GetAsync("speakers");
            if (response.IsSuccessStatusCode)
            {
                var objectResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SpeakerModel>>(response.Content.ReadAsStringAsync().Result);
                var speakers =
                    objectResult.Select(
                        speaker =>
                            new Speaker
                            {
                                FirstName = speaker.Name,
                                LastName = "Fake",
                                Details = "No resum",
                                Id = new SpeakerId(speaker.Id),
                                ProfilPicture = "simonbrown.jpg",
                                ProfilPictureIcon = "simonbrown.jpg",
                                Sessions = speaker.Sessions.Select(session => new SessionId(session.Id)).ToList()
                            }).ToList();
                dataSourceRepository.Retreive().AddSpeakers(speakers);
            }
        }

        public async Task TestSessions(IDataSourceRepository dataSourceRepository)
        {
            var response = await _client.GetAsync("sessions");
            if (response.IsSuccessStatusCode)
            {
                var objectResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SessionModel>>(response.Content.ReadAsStringAsync().Result);
                var sessions =
                    objectResult.Select(
                        session =>
                            new Session
                            {
                                Id = new SessionId(session.Id),
                                Title = session.Title,
                                Description = session.Abstract,
                                Interval = new TimeSlot { StartDate = Convert.ToDateTime(session.StartTime), EndDate = Convert.ToDateTime(session.StartTime).Add(new TimeSpan(0, session.DurationInMinutes, 0))},
                                Room = new Room { Name = session.Place},
                                Tags = session.Tags.Select(tag => new Tag {Title = tag}).ToList(),
                                Speakers = new List<SpeakerId> { new SpeakerId(session.SpeakerId) },
                            }).ToList();
                var tags = objectResult.SelectMany(session => session.Tags.Select(tag => new Tag { Title = tag, Sessions = new List<SessionId> {new SessionId(session.Id)}}));
//                var groupByTag = tags.GroupBy(tag => tag.Title);
                var groupByTag2 = tags.GroupBy(tag => tag.Title);
                var tmp = groupByTag2.Select(group => new Tag {Title = group.Key, Sessions = new List<SessionId>(group.SelectMany(x => x.Sessions).ToList())}).ToList();

                //var tags2 = objectResult.SelectMany(session => session.Tags).Distinct().ToList();
                dataSourceRepository.Retreive().AddSessions(sessions);
            }
        }
    }
}
