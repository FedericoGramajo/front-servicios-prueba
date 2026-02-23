using ClientLibrary.Models.Booking.States;

namespace ClientLibrary.Helper
{
    public static class BookingHelper
    {
        public static string ToLabel(string? status)
        {
            return BookingStateFactory.Create(status).DisplayName;
        }

        public static string GetBadgeClass(string? status)
        {
            return BookingStateFactory.Create(status).BadgeClass;
        }

        public static string GetIconClass(string? status)
        {
            return BookingStateFactory.Create(status).IconClass;
        }
    }
}
