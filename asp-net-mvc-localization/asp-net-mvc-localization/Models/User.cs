using System.ComponentModel.DataAnnotations;
using System;
using asp_net_mvc_localization.Utils;

namespace asp_net_mvc_localization.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Display]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display]
        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Password { get; set; }

        [Display]
        [Range(1,125)]
        public int Age { get; set; }

        [Display]
        public DateTime Birthday { get; set; }

        [Display]
        [Required]
        [Range(0.1, 9.9)]
        public double Rand { get; set; }
    }
}