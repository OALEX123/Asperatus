using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Shukratar.Shared.Job
{
    /// <summary>
    /// Job service runner (hosted on azure)
    /// </summary>
    public class AzureJobService : IJobService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerSettings _settings;

        public AzureJobService(Uri address, string username, string password)
        {
            _client = new HttpClient { BaseAddress = new Uri(address.OriginalString + "/api/") };

            var auth = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ':' + password))}";

            _client.DefaultRequestHeaders.Add("authorization", auth);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _settings = new JsonSerializerSettings
            {
                ContractResolver = new UnderscoreMappingResolver()
            };
        }

        public Job GetState()
        {
            var result = _client.GetStringAsync("triggeredwebjobs/shukratar-crawler").Result;

            return JsonConvert.DeserializeObject<Job>(result, _settings);
        }

        public void Run()
        {
            _client.PostAsync("triggeredwebjobs/shukratar-crawler/run", null).Wait();
        }

        private class UnderscoreMappingResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return Regex.Replace(propertyName, @"([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", "$1$3_$2$4").ToLower();
            }
        }
    }
}