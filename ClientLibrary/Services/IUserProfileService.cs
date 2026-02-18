using ClientLibrary.Models.Landing;
using ClientLibrary.Models;

namespace ClientLibrary.Services
{
    public interface IUserProfileService
    {
        Task<UserProfileModel> GetProfileAsync();
        Task<ServiceResponse> UpdateProfileAsync(UserProfileModel profile);
        Task<List<AddressModel>> GetAddressesAsync();
        Task<ServiceResponse> AddAddressAsync(AddressModel address);
        Task<ServiceResponse> DeleteAddressAsync(AddressModel address); // Or by ID
    }
}
