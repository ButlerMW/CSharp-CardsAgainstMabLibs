using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CardsAgainstMadLibs.Models
{
    public class CardUserVM
    {
        public User User {get;set;}
        public Card Card {get;set;}
    }
}