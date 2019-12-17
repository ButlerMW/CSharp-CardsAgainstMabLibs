using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CardsAgainstMadLibs.Models
{
    public class User
    {
        [Key]
        public int UserId   {get;set;}
        
        [Required]
        [MinLength(3)]
        public string Username {get;set;}

        [Required]
        [MinLength(3)]
        [DataType(DataType.Password)]

        public string Password {get;set;}

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword {get;set;}
    }
}