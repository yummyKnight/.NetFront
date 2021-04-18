using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Services.Contracts;

namespace Client.Services.Implementations {
    public class GenericServices<TDomainClass> : IGenericServices<TDomainClass> where TDomainClass : class {
        private HttpClient HttpClient { get; }
        private string ApiPath { get; }

        public GenericServices(HttpClient httpClient, string apiName) {
            HttpClient = httpClient;
            ApiPath = "api/" + apiName;
        }

        public async Task<IEnumerable<TDomainClass>> Get() {
            using var response = await HttpClient.GetAsync(ApiPath);
            System.Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<TDomainClass>>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public async Task<TDomainClass> Get(int id) {
            using var response = await HttpClient.GetAsync($"{ApiPath}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TDomainClass>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public async Task<TDomainClass> Put(TDomainClass tDomainClass) {
            var sendContent =
                new StringContent(JsonSerializer.Serialize(tDomainClass), Encoding.UTF8, "application/json");
            using var response = await HttpClient.PutAsync(ApiPath, sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TDomainClass>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public async Task<TDomainClass> Patch(TDomainClass tDomainClass) {
            var sendContent =
                new StringContent(JsonSerializer.Serialize(tDomainClass), Encoding.UTF8, "application/json");
            using var response = await HttpClient.PatchAsync(ApiPath, sendContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TDomainClass>(content,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public async Task Delete(int id) {
            using var response = await HttpClient.DeleteAsync($"{ApiPath}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
// git remote add origin git@github.com:yummyKnight/.NetFront.git
//     git branch -M master
//     git push -u origin master