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
        public bool IsConfResponse { get; set; }
        public bool IsSpeakerResponse { get; set; }
        public bool IsSessionResponse { get; set; }
        private Conf _configuration;

        public NetworkClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task GetConf()
        {
            var response = await _client.GetAsync("http://raw.githubusercontent.com/anthyme/ncraftsdata/master/conf.json");
            IsConfResponse = response.IsSuccessStatusCode;
            if (IsConfResponse)
            {
                _configuration = Converter.GetConfFromJson(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task GetSpeakers(IDataSourceRepository dataSourceRepository)
        {
            if (!IsConfResponse) return;
            var response = await _client.GetAsync(_configuration.SpeakersUrl);
            IsSpeakerResponse = response.IsSuccessStatusCode;
            if (IsSpeakerResponse)
            {
                var speakers = Converter.GetSpeakersFromJsonTmp(response.Content.ReadAsStringAsync().Result);
                dataSourceRepository.Retreive().AddSpeakers(speakers);
            }
        }

        public async Task GetSessions(IDataSourceRepository dataSourceRepository)
        {
            if (!IsConfResponse) return;
            var response = await _client.GetAsync(_configuration.SessionsUrl);
            IsSessionResponse = response.IsSuccessStatusCode;
            if (IsSessionResponse)
            {
                var results = Converter.GetSessionsAndTagsFromJsonTmp(response.Content.ReadAsStringAsync().Result);
                dataSourceRepository.Retreive().AddSessions(results.Item1);
                dataSourceRepository.Retreive().AddTags(results.Item2);
            }
        }
    }
}
