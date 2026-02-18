using System;

namespace ClientLibrary.Models.Landing
{
    public record ServiceHistoryItem(string Service, string Category, string Professional, DateTime Date, string Status, decimal Total);
    
    public class UserProfileModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ContactPreference { get; set; } = "WhatsApp";
        public string Availability { get; set; } = "Mañana";
        public string Notes { get; set; } = string.Empty;
    }

    public class AddressModel
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
    }
}
