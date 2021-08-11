using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Services
{
    public interface ITmsPropertiesService
    {
        Task<IEnumerable<TmsProperties>> GetAllTmsProperties();
        Task<IEnumerable<TmsProperties>> GetTmsProperties(int id);
        Task<TmsProperties> UpdateTmsProperties(TmsProperties props);
    }
}
