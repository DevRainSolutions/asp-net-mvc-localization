using System.ComponentModel.DataAnnotations;
using asp_net_mvc_localization.Utils;
using System;

namespace asp_net_mvc_localization.Models
{
    public class TestUser
    {
        [Required(ErrorMessageResourceName="Required", ErrorMessageResourceType=typeof(Resources.ValidationResources))]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [LocalizedRequired()]
        [MinLength(6)]
        [MaxLength(64)]
        public string Password { get; set; }

        [Range(1,125)]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        [LocalizedRequired]
        [Range(0.1, 9.9)]
        public double rand { get; set; }
    }
}