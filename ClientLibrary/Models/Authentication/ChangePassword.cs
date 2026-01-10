using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLibrary.Models.Authentication
{
    public class ChangePassword
    {
        public string Token { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; }
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

    }
}
