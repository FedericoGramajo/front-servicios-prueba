using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Booking;
using ClientLibrary.Models.Landing;
using ClientLibrary.Services.Contracts;

namespace ClientLibrary.Services.Implementations;

public class ProfessionalDashboardService(IHttpClientHelper httpClient, IApiCallHelper apiHelper) : IProfessionalDashboardService
{
    public async Task<DashboardMetrics> GetDashboardMetricsAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.GetMetrics,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<DashboardMetrics>(result) ?? new DashboardMetrics(0, 0, 0, 0.0);
    }

    public async Task<List<ServiceGroup>> GetServiceGroupsAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.GetServiceGroups,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<ServiceGroup>>(result) ?? new List<ServiceGroup>();
    }

    public async Task<List<ServiceTransaction>> GetTransactionsAsync(DateTime start, DateTime end, string? status, string? city)
    {
        var client = await httpClient.GetPrivateClientAsync();
        // Construct query string manually or via helper if available
        // Simple manual construction for now
        string query = $"?start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}";
        if (!string.IsNullOrEmpty(status)) query += $"&status={status}";
        if (!string.IsNullOrEmpty(city)) query += $"&city={city}";

        var apiCall = new ApiCall
        {
            Route = Constant.Professional.GetTransactions + query,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<ServiceTransaction>>(result) ?? new List<ServiceTransaction>();
    }

    public async Task AddServiceAsync(ServiceFormModel service)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.AddService,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Model = service
        };
        await apiHelper.ApiCallTypeCall<ServiceFormModel>(apiCall);
    }

    public async Task UpdateServiceAsync(ServiceFormModel service)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.UpdateService,
            Type = Constant.ApiCallType.Update,
            Client = client,
            Model = service
        };
        await apiHelper.ApiCallTypeCall<ServiceFormModel>(apiCall);
    }

    public async Task DeleteServiceAsync(string serviceSlug)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = $"{Constant.Professional.DeleteService}/{serviceSlug}",
            Type = Constant.ApiCallType.Delete,
            Client = client
        };
        await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
    }

    // Category Management
    public async Task<List<string>> GetAvailableCategoriesAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.GetAvailableCategories,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<string>>(result) ?? new List<string>();
    }

    public async Task<List<string>> GetMyCategoriesAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.GetMyCategories,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<string>>(result) ?? new List<string>();
    }

    public async Task<ServiceResponse> AddMyCategoryAsync(string category)
    {
        var client = await httpClient.GetPrivateClientAsync();
        // Assuming category is sent as a string in body or query? 
        // ApiCall expects an object Model. Let's wrap it or send as is if supported.
        // Usually safer to wrap in a simple object or send as query param if simple string.
        // Let's assume we send it as a dedicated wrapper or just query for simplicity if API supports it.
        // But to be proper, let's assume body with "Category" property or similar. 
        // For now, let's send it as a stringModel to body.
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.AddMyCategory,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Model = new { Category = category }
        };
        var result = await apiHelper.ApiCallTypeCall<object>(apiCall);
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }

    public async Task<ServiceResponse> RemoveMyCategoryAsync(string category)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = $"{Constant.Professional.RemoveMyCategory}/{category}", // or query
            Type = Constant.ApiCallType.Delete,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }

    // Availability Management
    public async Task<List<ProfessionalAvailability>> GetAvailabilityAsync(string professionalId)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = $"{Constant.Professional.GetAvailability}/{professionalId}",
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<ProfessionalAvailability>>(result) ?? new List<ProfessionalAvailability>();
    }

    public async Task<ServiceResponse> AddAvailabilityAsync(AddAvailabilityRequest request)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.AddAvailability,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Model = request
        };
        var result = await apiHelper.ApiCallTypeCall<AddAvailabilityRequest>(apiCall);
        
        if (result == null)
            return new ServiceResponse(false, "Error de conexión con el servidor");

        if (result.IsSuccessStatusCode)
        {
            var response = await apiHelper.GetServiceResponse<ServiceResponse>(result);
            return response ?? new ServiceResponse(true, "Horario agregado correctamente");
        }
        else
        {
            var response = await apiHelper.GetServiceResponse<ServiceResponse>(result);
            return response ?? new ServiceResponse(false, $"Error del servidor: {result.StatusCode}");
        }
    }



    public async Task<ServiceResponse> RemoveAvailabilityAsync(Guid id)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = $"{Constant.Professional.RemoveAvailability}/{id}",
            Type = Constant.ApiCallType.Delete,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        
        if (result == null)
            return new ServiceResponse(false, "Error de conexión con el servidor");

        if (result.IsSuccessStatusCode)
        {
            var response = await apiHelper.GetServiceResponse<ServiceResponse>(result);
            return response ?? new ServiceResponse(true, "Horario eliminado correctamente");
        }
        else
        {
            var response = await apiHelper.GetServiceResponse<ServiceResponse>(result);
            return response ?? new ServiceResponse(false, $"Error del servidor: {result.StatusCode}");
        }
    }
    
    // Certification Management
    public async Task<List<CertificationModel>> GetCertificationsAsync()
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.GetCertifications,
            Type = Constant.ApiCallType.Get,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<List<CertificationModel>>(result) ?? new List<CertificationModel>();
    }

    public async Task<ServiceResponse> AddCertificationAsync(CertificationModel certification)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Professional.AddCertification,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Model = certification
        };
        var result = await apiHelper.ApiCallTypeCall<CertificationModel>(apiCall);
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }

    public async Task<ServiceResponse> RemoveCertificationAsync(Guid id)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = $"{Constant.Professional.RemoveCertification}/{id}",
            Type = Constant.ApiCallType.Delete,
            Client = client
        };
        var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
        return await apiHelper.GetServiceResponse<ServiceResponse>(result);
    }
}
