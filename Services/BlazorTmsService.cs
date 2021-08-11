using SupportMonitorBlazor.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;

namespace SupportMonitorBlazor.Services
{
    public class BlazorTmsService : IBlazorTmsService
    {
        private readonly HttpClient httpClient;

        public BlazorTmsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }





        public async Task<IEnumerable<BlazorTMS>> GetBlazorTms()
        {
            return await httpClient.GetJsonAsync<BlazorTMS[]>("api/BlazorTms");
        }

        public async Task<BlazorTMS> GetTMS(int id)
        {
             return await httpClient.GetJsonAsync<BlazorTMS>($"api/BlazorTms/{id}");
        }
    }
}
