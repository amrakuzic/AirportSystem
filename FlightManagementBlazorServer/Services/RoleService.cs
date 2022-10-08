using DomainModel.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Services
{
    public class RoleService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseApiUrl = "https://localhost:44334/api/Role";
        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Role>>(BaseApiUrl);
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Role>($"{BaseApiUrl}/{id}");
        }

        public async Task UpdateRoleAsync(Role role)
        {
            var httpPutRequest = new HttpRequestMessage(HttpMethod.Put, BaseApiUrl);
            httpPutRequest.Content = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPutRequest);
        }

        public async Task AddRoleAsync(Role role)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Post, BaseApiUrl);
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var httpDeleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"{BaseApiUrl}/{roleId}");
            await _httpClient.SendAsync(httpDeleteRequest);
        }
    }
}
