using System.ComponentModel.DataAnnotations;
using System;

namespace asp_net_mvc_localization.Models
{
    public class TestUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Password { get; set; }

        [Range(1,125)]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [Range(0.1, 9.9)]
        public double rand { get; set; }
    }
}