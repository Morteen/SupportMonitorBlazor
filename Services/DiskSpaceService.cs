using Microsoft.AspNetCore.Components;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Services
{
    public class DiskSpaceService : IDiskSpaceService
    {
        private readonly HttpClient httpClient;

        public DiskSpaceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<DiskSpace>> GetAllDiskSpace()
        {
            return await httpClient.GetJsonAsync<DiskSpace[]>("api/DiskSpace");
        }

        public  async Task<IEnumerable<DiskSpace>> GetTMSDiskspace(int id)
        {
            return await httpClient.GetJsonAsync<DiskSpace[]>($"api/DiskSpace/{id}");
        }

        

        public async Task<DiskSpace> UpdateDiskSpace(DiskSpace updatetdSpace)
        {
            return await httpClient.PutJsonAsync<DiskSpace>($"api/DiskSpace", updatetdSpace);
        }
    }
}
