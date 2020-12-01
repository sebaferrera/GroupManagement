﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace GroupManagement.DTOs
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters.", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UserLoggedInDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool LoggedIn { get; set; }
        public string Token { get; set; }
    }

    public class UserRegistrationResultDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public IList<string> RegistrationErrors { get; set; }
        [JsonIgnore]
        public bool HasRegistrationErrors => RegistrationErrors == null ? false : RegistrationErrors.Any();
    }
}
