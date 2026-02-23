using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Booking;
using ClientLibrary.Services.Contracts;

namespace ClientLibrary.Services.Implementations
{
    public class AvailabilityService(IApiCallHelper apiHelper, IHttpClientHelper httpClient) : IAvailabilityService
    {
        public async Task<List<DateTime>> GetAvailableSlotsAsync(string professionalId, DateTime date, Guid serviceOfferingId)
        {
            var client = httpClient.GetPublicClient();
            var dateStr = date.ToString("yyyy-MM-dd");
            var route = $"{Constant.Availability.GetSlots}?professionalId={professionalId}&date={dateStr}&serviceOfferingId={serviceOfferingId}";
            
            var apiCall = new ApiCall
            {
                Route = route,
                Type = Constant.ApiCallType.Get,
                Client = client
            };

            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
            if (result != null && result.IsSuccessStatusCode)
            {
                var response = await apiHelper.GetServiceResponse<List<DateTime>>(result);
                return response ?? new List<DateTime>();
            }
            return new List<DateTime>();
        }
    }
}
