using ClientLibrary.Models.Booking;

namespace ClientLibrary.Services.Contracts
{
    public interface IAvailabilityService
    {
        Task<List<DateTime>> GetAvailableSlotsAsync(string professionalId, DateTime date, Guid serviceOfferingId);
    }
}
