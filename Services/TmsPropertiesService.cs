using Microsoft.AspNetCore.Components;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Services
{

    public class TmsPropertiesService : ITmsPropertiesService
    {


        private readonly HttpClient httpClient;

        public TmsPropertiesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

       

        public async Task<IEnumerable<TmsProperties>> GetAllTmsProperties()
        {
            return await httpClient.GetJsonAsync<TmsProperties[]>("api/TmsProperties");
        }

        public async Task<IEnumerable<TmsProperties>> GetTmsProperties(int id)
        {
            return await httpClient.GetJsonAsync<TmsProperties[]>($"api/TmsProperties/{id}");
        }

        public Task<TmsProperties> UpdateTmsProperties(TmsProperties props)
        {
            throw new NotImplementedException();
        }
    }
}
