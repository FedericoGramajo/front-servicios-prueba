using ClientLibrary.Models.Landing;

namespace ClientLibrary.Services
{
    public interface IServiceHistoryService
    {
        Task<List<ServiceHistoryItem>> GetHistoryAsync();
    }
}
