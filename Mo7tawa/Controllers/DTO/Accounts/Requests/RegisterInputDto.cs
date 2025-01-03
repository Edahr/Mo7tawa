﻿using System.ComponentModel.DataAnnotations;

namespace Mo7tawa.Controllers.DTO.Accounts.Requests
{
    public class RegisterInputDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
