using DomainModel.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Services
{
    public class LuggageService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseApiUrl = "https://localhost:44334/api/Luggage";
        public LuggageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Luggage>> GetLuggagesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Luggage>>(BaseApiUrl);
        }

        public async Task<Luggage> GetLuggageAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Luggage>($"{BaseApiUrl}/{id}");
        }

        public async Task UpdateLuggageAsync(Luggage luggage)
        {
            var httpPutRequest = new HttpRequestMessage(HttpMethod.Put, BaseApiUrl);
            httpPutRequest.Content = new StringContent(JsonSerializer.Serialize(luggage), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPutRequest);
        }

        public async Task AddLuggageAsync(Luggage luggage)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Post, BaseApiUrl);
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(luggage), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }

        public async Task DeleteLuggageAsync(int luggageId)
        {
            var httpDeleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"{BaseApiUrl}/{luggageId}");
            await _httpClient.SendAsync(httpDeleteRequest);
        }
    }
}
