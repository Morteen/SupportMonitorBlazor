using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Services
{
    public interface IBlazorTmsService
    {
        Task<IEnumerable<BlazorTMS>> GetBlazorTms();
        Task<BlazorTMS> GetTMS(int id);
    }
}
