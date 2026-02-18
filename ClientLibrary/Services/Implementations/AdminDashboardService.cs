using System.Collections.Generic;
using System.Threading.Tasks;
using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Authentication.Rol.Professional;
using ClientLibrary.Models.Landing;
using ClientLibrary.Services.Contracts;

namespace ClientLibrary.Services.Implementations;

public class AdminDashboardService(IHttpClientHelper httpClient, IApiCallHelper apiHelper) : IAdminDashboardService
{
    public async Task<List<AdminMetric>> GetMetricsAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Admin.GetMetrics,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<AdminMetric>>(result) ?? new List<AdminMetric>();
    }

    public async Task<List<ReportBar>> GetCategoryReportAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Admin.GetCategoryReport,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<ReportBar>>(result) ?? new List<ReportBar>();
    }

    public async Task<List<ReportBar>> GetStatusReportAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Admin.GetStatusReport,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<ReportBar>>(result) ?? new List<ReportBar>();
    }

    public async Task<List<GetProfessional>> GetProfessionalsAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Admin.GetProfessionals,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Model = null!,
            Id = null!
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<GetProfessional>>(result) ?? new List<GetProfessional>();
    }

    public async Task<ServiceResponse> UpdateProfessionalAsync(GetProfessional professional)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Admin.UpdateProfessional,
            Type = Constant.ApiCallType.Update,
            Client = client,
            Model = professional
        };
        var result = await apiHelper.ApiCallTypeCall<GetProfessional>(apiCall);
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }
}
