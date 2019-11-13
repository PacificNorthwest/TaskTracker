using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LangateTaskTracker.WebServer.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required, Display(Name = "Email")]
        public string Email { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords do not match"), DataType(DataType.Password), Display(Name = "Password confirmation")]
        public string PasswordConfirm { get; set; }
    }
}
