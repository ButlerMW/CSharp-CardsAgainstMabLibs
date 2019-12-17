using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CardsAgainstMadLibs.Models
{
    public class Credentials
    {
        [Required]
        public string Username {get;set;}
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage="Password must be at least 3 characters.")]
        public string Password{get;set;}
    }
}