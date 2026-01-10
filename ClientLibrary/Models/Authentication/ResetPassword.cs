using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Authentication
{
    public class ResetPassword : AuthenticationBase
    {
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

    }
}
