﻿using System.ComponentModel.DataAnnotations;

namespace BlogRazor.Web.Models.ViewModels
{
    public class Register
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
