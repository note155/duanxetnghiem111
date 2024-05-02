﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.ketnoi;
using Shared.Model;

namespace duanxetnghiem.Client.Services
{
    public class ThongbaoServices : IThongbao
    {
        private readonly HttpClient _httpClient;

        public ThongbaoServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Thongbao> addAsync(Thongbao tbao)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Thongbao/Add_Thongbao", tbao);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Thongbao>();
        }

        public async Task<List<Thongbao>> getall()
        {
            return await _httpClient.GetFromJsonAsync<List<Thongbao>>("api/Thongbao/All_TB");
        }

        public async Task<List<Thongbao>> getbyid(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<Thongbao>>($"api/Thongbao/Getbyid/{id}");
        }

        public async Task<Thongbao> updateAsync(Thongbao tbao)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Thongbao/Update-Thongbao", tbao);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Thongbao>();
        }
    }
}
