namespace DevStream.Games.Twitch.WebClient
{
    using DevStream.Games.Twitch.Core.DTOs;
    using DevStream.Games.Twitch.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class GameDataService : IGameDataService
    {
        private readonly HttpClient _httpClient;
        private readonly TwitchConfig _config;

        public GameDataService(
            HttpClient httpClient,
            TwitchConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<ICollection<TwitchGameData>> Get(int skip = 0, int take = 30)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Client-Id", "kimne78kx3ncx6brgo4mv6wki5h1ko");
            var jsonContext = System.Net.Http.Json.JsonContent.Create(GetRequestBody());
            var response = await _httpClient.PostAsync(_config.Url, jsonContext);
            var content = await response.Content.ReadAsStringAsync();
            var result = Serialize(content);
            return result;
        }

        private ICollection<TwitchGameData> Serialize(string data)
        {
            var jsonObject = JsonDocument.Parse(data);
            var root = jsonObject.RootElement;

            var edges = root
                .GetProperty("data")
                .GetProperty("directoriesWithTags")
                .GetProperty("edges");

            var edgeCollection = edges.EnumerateArray()
                .Select(f => f.GetProperty("node"))
                .Select(f => new TwitchGameData()
                {
                    Name = Regex.Replace(f.GetProperty("displayName").GetString(), "[^0-9a-zA-Z]+", ""),
                    ViewerCount = f.GetProperty("viewersCount").GetDecimal()
                })
                .ToList();

            return edgeCollection;
        }

        private object GetRequestBody()
        {
            var requestBodyObject = new Dictionary<string, object>();

            requestBodyObject.Add("operationName", "BrowsePage_AllDirectories");

            var requestBodyObjectVariable = new Dictionary<string, object>();
            requestBodyObjectVariable.Add("limit", 30);
            var requestBodyObjectVariableOptions = new Dictionary<string, object>();
            var requestBodyObjectVariableOptionsRec = new Dictionary<string, object>();
            requestBodyObjectVariableOptionsRec.Add("platform", "web");
            requestBodyObjectVariableOptions.Add("recommendationsContext", requestBodyObjectVariableOptionsRec);
            requestBodyObjectVariableOptions.Add("requestID", "JIRA-VXP-2397");
            requestBodyObjectVariableOptions.Add("sort", "RELEVANCE");
            requestBodyObjectVariableOptions.Add("tags", new List<int>());
            requestBodyObjectVariable.Add("options", requestBodyObjectVariableOptions);
            requestBodyObjectVariable.Add("cursor", "eyJvZmYiOjUyLCJibGsiOjAsInN1YiI6eyIxIjp7Im9mZiI6NTIsInRvdCI6MTAwfSwiMiI6eyJvZmYiOjAsInRvdCI6MTgwfSwiMyI6eyJvZmYiOjAsInRvdCI6MH19fQ==");

            requestBodyObject.Add("variables", requestBodyObjectVariable);

            var requestBodyObjectExtensions = new Dictionary<string, object>();
            var requestBodyObjectExtensionsPersQ = new Dictionary<string, object>();
            requestBodyObjectExtensionsPersQ.Add("version", 1);
            requestBodyObjectExtensionsPersQ.Add("sha256Hash", "78957de9388098820e222c88ec14e85aaf6cf844adf44c8319c545c75fd63203");
            requestBodyObjectExtensions.Add("persistedQuery", requestBodyObjectExtensionsPersQ);

            requestBodyObject.Add("extensions", requestBodyObjectExtensions);

            return requestBodyObject;
        }
    }
}
