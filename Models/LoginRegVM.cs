using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CardsAgainstMadLibs.Models
{
    public class LoginRegVM
    {
        public User User {get;set;}
        public Credentials Credentials {get;set;}
    }
}