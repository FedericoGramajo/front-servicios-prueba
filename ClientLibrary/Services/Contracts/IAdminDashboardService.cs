using System.Collections.Generic;
using System.Threading.Tasks;
using ClientLibrary.Models;
using ClientLibrary.Models.Landing;
using ClientLibrary.Models.Authentication.Rol.Professional;

namespace ClientLibrary.Services.Contracts;

public interface IAdminDashboardService
{
    Task<List<AdminMetric>> GetMetricsAsync();
    Task<List<ReportBar>> GetCategoryReportAsync();
    Task<List<ReportBar>> GetStatusReportAsync();
    Task<List<GetProfessional>> GetProfessionalsAsync();
    Task<ServiceResponse> UpdateProfessionalAsync(GetProfessional professional);
}
