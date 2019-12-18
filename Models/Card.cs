using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CardsAgainstMadLibs.Models
{
    public class Card
    {
        [Key]
        public int CardId   {get;set;}

        public string String1 {get;set;}
        public string String2 {get;set;}
        public string String3 {get;set;}
    }
}