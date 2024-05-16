﻿using System.ComponentModel.DataAnnotations;

namespace e_store.DTOs
{
    public class UserForLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
