using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Authentication
{
    public enum UserType { Customer = 0, Professional = 1 }
    public class CreateUser : AuthenticationBase
    {
        [Required]
        public string? FullName { get; set; }
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
        [Required, Phone]
        public string? PhoneNumber { get; set; }
        public string? ProfileImage { get; set; }
        public required UserType UserType { get; set; }
    }
}
