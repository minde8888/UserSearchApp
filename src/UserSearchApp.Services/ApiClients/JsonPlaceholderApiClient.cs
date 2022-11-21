using Newtonsoft.Json;
using UserSearchApp.Services.Dtos;

namespace UserSearchApp.Services.ApiClients
{
    public class JsonPlaceholderApiClient : IJsonPlaceholderApiClient
    {
        private readonly HttpClient _httpClient;
        public JsonPlaceholderApiClient(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("JsonPlaceHolderApiClient");
        }

        public async Task<SearchUserInfo> SearchUserAsync(string name)
        {
            var endPoint = "users";
            HttpResponseMessage response = await _httpClient.GetAsync(endPoint);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SearchUserInfo>>(data).FirstOrDefault(u => u.Name == name);

            return result;
        }
    }
}
