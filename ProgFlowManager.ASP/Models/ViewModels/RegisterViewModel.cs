﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProgFlowManager.ASP.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Username")]
        [MinLength(3, ErrorMessage = "Username must contain at least 3 characters")]
        public string Name { get; set; }
        [DisplayName("Bio")]
        [MinLength(10, ErrorMessage = "Bio must contain at least 10 characters")]
        public string Resume { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+{}:;<>,.?~=-]).{8,}$", ErrorMessage = "Password must contain the following criteria:")]
        public string PasswordHash { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordHash), ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<string> ErrorMessages()
        {
            List<string> errors = new();

            if (!Regex.IsMatch(PasswordHash, "^(?=.*[A-Z])"))
                errors.Add("Password must contain at least one uppercase letter.");
            if (!Regex.IsMatch(PasswordHash, "^(?=.*[a-z])"))
                errors.Add("Password must contain at least one lowercase letter.");
            if (!Regex.IsMatch(PasswordHash, "^(?=.*[0-9])"))
                errors.Add("Password must contain at least one digit.");
            if (!Regex.IsMatch(PasswordHash, "^(?=.*[!@#$%^&*()_+{}:;<>,.?~=-])"))
                errors.Add("Password must contain at least one special character.");

            return errors;
        }
    }
}
