using System.ComponentModel.DataAnnotations;
using System;

namespace asp_net_mvc_localization.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        [Range(1,125)]
        public int Age { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}