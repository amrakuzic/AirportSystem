using DomainModel.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Services
{
    public class DocumentService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseApiUrl = "https://localhost:44334/api/Document";
        public DocumentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Document>> GetDocumentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Document>>(BaseApiUrl);
        }

        public async Task<Document> GetDocumentAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Document>($"{BaseApiUrl}/{id}");
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            var httpPutRequest = new HttpRequestMessage(HttpMethod.Put, BaseApiUrl);
            httpPutRequest.Content = new StringContent(JsonSerializer.Serialize(document), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPutRequest);
        }

        public async Task AddDocumentAsync(Document document)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Post, BaseApiUrl);
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(document), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }

        public async Task DeleteDocumentAsync(int documentId)
        {
            var httpDeleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"{BaseApiUrl}/{documentId}");
            await _httpClient.SendAsync(httpDeleteRequest);
        }
    }
}

