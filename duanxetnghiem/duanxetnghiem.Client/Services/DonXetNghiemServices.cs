﻿using duanxetnghiem.Data.Model;
using Shared.form;
using Shared.ketnoi;
using Shared.Model;
using System.Net.Http.Json;

namespace duanxetnghiem.Client.Services
{
    public class DonXetNghiemServices : IDonXetNghiem
    {
        private readonly HttpClient _httpClient;
        public DonXetNghiemServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<DonXetNghiem> addAsync(DonXetNghiem DonXetNghiem)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/DonXetNghiem/Add-DXN", DonXetNghiem);
            var respone = await newstudent.Content.ReadFromJsonAsync<DonXetNghiem>();
            return respone;
        }

        public async Task<DXNandGXN> addnew(DXNandGXN a)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/DonXetNghiem/Add-DXNandGXN", a);
            var respone = await newstudent.Content.ReadFromJsonAsync<DXNandGXN>();
            return respone;
        }
        public async Task<gmail> guiemailxacnhan(gmail gm)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/DonXetNghiem/gui-XNemail", gm);
            var respone = await newstudent.Content.ReadFromJsonAsync<gmail>();
            return respone;
        }
        public async Task<DonXetNghiem> deleteAsync(int id)
        {
            var newstudent = await _httpClient.DeleteAsync($"api/DonXetNghiem/Delete-DXN/{id}");
            var respone = await newstudent.Content.ReadFromJsonAsync<DonXetNghiem>();
            return respone;
        }

        public async Task<DXNandGXN> deletegxnAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/DonXetNghiem/Delete-DXNGXN/{id}");

            // Handle the response here if needed

            return null; // or return any appropriate result
        }


        public async Task<List<DonXetNghiem>> getallAsync()
        {
            var allstudent = await _httpClient.GetAsync("api/DonXetNghiem/All-DXN");
            var respone = await allstudent.Content.ReadFromJsonAsync<List<DonXetNghiem>>();
            return respone;
        }


        public async Task<List<DonXetNghiem>> getallbyiduserAsync(int id)
        {
            var allstudent = await _httpClient.GetAsync($"api/DonXetNghiem/All-DXNbyiduser/{id}");
            var respone = await allstudent.Content.ReadFromJsonAsync<List<DonXetNghiem>>();
            return respone;
        }

        public async Task<List<DXNandGXN>> getallGXNAsync(int idDXN)
        {
            var allstudent = await _httpClient.GetAsync($"api/DonXetNghiem/All-DXNandGXN/{idDXN}");
            var respone = await allstudent.Content.ReadFromJsonAsync<List<DXNandGXN>>();
            return respone;
        }

        public async Task<DonXetNghiem> getbyid(int Id)
        {
            var response = await _httpClient.GetAsync($"api/DonXetNghiem/Single-DXN/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var respone = await response.Content.ReadFromJsonAsync<DonXetNghiem>();
                return respone;
            }
            else
            {
                // Xử lý khi không thành công, ví dụ: trả về null hoặc throw exception
                return null;
            }
        }

        public Task<List<DXNandGXN>> getmaubyidbs(int idbs)
        {
            throw new NotImplementedException();
        }

        public async Task<DXNandGXN> getOngNghiem(int Id)
        {
            var response = await _httpClient.GetAsync($"api/DonXetNghiem/Single-OngNghiem/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var respone = await response.Content.ReadFromJsonAsync<DXNandGXN>();
                return respone;
            }
            else
            {
                // Handle the case where the request was not successful
                return null; // or throw an exception
            }
        }

        public async Task<List<DonXetNghiem>> ListDXNBS(int id)
        {
            var response = await _httpClient.GetAsync($"api/DonXetNghiem/All-DXNbyidbs/{id}");
            if (response.IsSuccessStatusCode)
            {
                var respone = await response.Content.ReadFromJsonAsync<List<DonXetNghiem>>();
                return respone;
            }
            else
            {
                // Handle the case where the request was not successful
                return null; // or throw an exception
            }
        }

        public async Task<List<DonXetNghiem>> ListDXNBSHoanThanh(int id)
        {
            var response = await _httpClient.GetAsync($"api/DonXetNghiem/All-DXNbyidbsHoanthanh/{id}");
            if (response.IsSuccessStatusCode)
            {
                var respone = await response.Content.ReadFromJsonAsync<List<DonXetNghiem>>();
                return respone;
            }
            else
            {
                // Handle the case where the request was not successful
                return null; // or throw an exception
            }
        }

        public async Task<DXNandGXN> SuaOngNghiem(DXNandGXN a)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/DonXetNghiem/Update-OngNghiem", a);
            var respone = await newstudent.Content.ReadFromJsonAsync<DXNandGXN>();
            return respone;
        }

        public async Task<DonXetNghiem> updateAsync(DonXetNghiem DonXetNghiem)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/DonXetNghiem/Update-DXN", DonXetNghiem);
            var respone = await newstudent.Content.ReadFromJsonAsync<DonXetNghiem>();
            return respone;
        }
    }
}
