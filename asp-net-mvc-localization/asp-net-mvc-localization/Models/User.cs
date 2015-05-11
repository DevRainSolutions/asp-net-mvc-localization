using System.ComponentModel.DataAnnotations;
using System;
using asp_net_mvc_localization.Utils;
using Newtonsoft.Json.Serialization;

namespace asp_net_mvc_localization.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MyEmailAddress]
        public string Email { get; set; }
               
        [Required]
        [MinLength(6)]
        [MaxLength(64)]
        public string Password { get; set; }
       
        [Range(1,125)]
        public int Age { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")] 
        public DateTime Birthday { get; set; }
       
        [Required]
        [Range(0.1, 9.9)]
        public double Rand { get; set; }
    }
}