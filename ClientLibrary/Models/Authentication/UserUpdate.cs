namespace ClientLibrary.Models.Authentication
{
    public class UserUpdate
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? ProfileImage { get; set; }
    }
}
