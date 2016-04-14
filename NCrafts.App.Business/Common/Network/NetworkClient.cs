using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NCrafts.App.Business.Common.JsonSerializer;
using NCrafts.App.Business.Core.Data;

namespace NCrafts.App.Business.Common.Network
{
    public class NetworkClient
    {
        private readonly HttpClient _client;
        public bool IsSessionResponse { get; set; }
        public bool IsSpeakerResponse { get; set; }

        public NetworkClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://api.ncrafts.io/events/ncrafts2016/") };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // TODO: add inject inside SQLite
        public async Task GetSpeakers(IDataSourceRepository dataSourceRepository)
        {
            var response = await _client.GetAsync("speakers");
            IsSpeakerResponse = response.IsSuccessStatusCode;
            if (IsSpeakerResponse)
            {
                var speakers = Converter.GetSpeakersFromJson(response.Content.ReadAsStringAsync().Result);
                dataSourceRepository.Retreive().AddSpeakers(speakers);
            }
        }

        public async Task GetSessions(IDataSourceRepository dataSourceRepository)
        {
            var response = await _client.GetAsync("sessions");
            IsSessionResponse = response.IsSuccessStatusCode;
            if (IsSessionResponse)
            {
                var results = Converter.GetSessionsAndTagsFromJson(response.Content.ReadAsStringAsync().Result);
                dataSourceRepository.Retreive().AddSessions(results.Item1);
                dataSourceRepository.Retreive().AddTags(results.Item2);
            }
        }
    }
}
