using ClientLibrary.Models;
using ClientLibrary.Models.Booking;

namespace ClientLibrary.Services.Contracts
{
    public interface IBookingService
    {
        Task<ServiceResponse> CreateBookingAsync(CreateBooking model);
        Task<List<GetBooking>> GetCustomerBookingsAsync(string customerId);
    }
}
