using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Landing;

namespace ClientLibrary.Services.Implementations
{
    public class UserProfileService(IHttpClientHelper httpClient, IApiCallHelper apiHelper) : IUserProfileService
    {
        public async Task<UserProfileModel> GetProfileAsync()
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.UserProfile.Get,
                Type = Constant.ApiCallType.Get,
                Client = client
            };
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
            return await apiHelper.GetServiceResponse<UserProfileModel>(result);
        }

        public async Task<ServiceResponse> UpdateProfileAsync(UserProfileModel profile)
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.UserProfile.Update,
                Type = Constant.ApiCallType.Update,
                Client = client,
                Model = profile
            };
            var result = await apiHelper.ApiCallTypeCall<UserProfileModel>(apiCall);
            return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<List<AddressModel>> GetAddressesAsync()
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.UserProfile.GetAddresses,
                Type = Constant.ApiCallType.Get,
                Client = client
            };
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
            return await apiHelper.GetServiceResponse<List<AddressModel>>(result);
        }

        public async Task<ServiceResponse> AddAddressAsync(AddressModel address)
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.UserProfile.AddAddress,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Model = address
            };
            var result = await apiHelper.ApiCallTypeCall<AddressModel>(apiCall);
            return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> DeleteAddressAsync(AddressModel address)
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.UserProfile.DeleteAddress,
                Type = Constant.ApiCallType.Post, // POST for delete with body, or regular DELETE if ID
                Client = client,
                Model = address
            };
            var result = await apiHelper.ApiCallTypeCall<AddressModel>(apiCall);
            return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }
    }
}
