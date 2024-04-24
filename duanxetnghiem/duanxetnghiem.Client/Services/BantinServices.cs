using duanxetnghiem.Data.Model;
using System.Net.Http.Json;
using Shared.ketnoi;
using Shared.Model;

namespace duanxetnghiem.Client.Services
{
    public class BantinServices : IBantin
    {
        private readonly HttpClient _httpClient;
        public BantinServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Bantin> addAsync(Bantin btin)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Bantin/Add-News", btin);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Bantin>();
        }

        public async Task<Bantin> deleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Bantin/Delete-News/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Bantin>();
        }

        public async Task<List<Bantin>> getallAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Bantin>>("api/Bantin/All-News");
        }

        public async Task<Bantin> getbyid(int Id)
        {
            return await _httpClient.GetFromJsonAsync<Bantin>($"api/Bantin/Single-News/{Id}");
        }

        public async Task<Bantin> updateAsync(Bantin btin)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Bantin/Update-News", btin);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Bantin>();
        }
    }
}
