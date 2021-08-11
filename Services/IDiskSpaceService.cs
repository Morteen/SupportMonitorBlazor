using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Services
{
    public interface IDiskSpaceService
    {
        Task<IEnumerable<DiskSpace>> GetAllDiskSpace();
        Task<IEnumerable <DiskSpace>> GetTMSDiskspace(int id);
        Task<DiskSpace> UpdateDiskSpace(DiskSpace space);
    }
}
