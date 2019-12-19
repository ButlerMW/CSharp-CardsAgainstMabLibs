using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CardsAgainstMadLibs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace CardsAgainstMadLibs.Controllers
{
    public class GameController : Controller
    {
        private CardsAgainstMadLibsContext dbContext;
        public GameController(CardsAgainstMadLibsContext context)
        {
            dbContext = context;
        }

        [HttpGet("/welcome")]
        public IActionResult Welcome()
        {
            int cardcount = dbContext.Cards.Count();
            Console.WriteLine(cardcount);
            // if(dbContext.Cards.Any(Card => Card.CardId == 5)) 
            if(cardcount >= 5)
            {
                return View();
            }
            else
            {
                Card card1 = new Card();
                card1.String1 = "Have you ever wanted to";
                card1.String2 = "all sorts of";
                card1.String3 = "with friends, family, and colleagues?";
                dbContext.Add(card1);
                dbContext.SaveChanges();
                Card card2 = new Card();
                card2.String1 = "We are here to";
                card2.String2 = "for";
                card2.String3 = ".";
                dbContext.Add(card2);
                dbContext.SaveChanges();
                Card card3 = new Card();
                card3.String1 = "The day I";
                card3.String2 = "the";
                card3.String3 = ".";
                dbContext.Add(card3);
                Card card4 = new Card();
                dbContext.SaveChanges();
                card4.String1 = "For my next trick, I will";
                card4.String2 = "a rabbit out of a/an";
                card4.String3 = ".";
                dbContext.Add(card4);
                dbContext.SaveChanges();
                Card card5 = new Card();
                card5.String1 = "It's important to";
                card5.String2 = "all";
                card5.String3 = ".";
                dbContext.Add(card5);
                dbContext.SaveChanges();
                return View();
            }
        }

        [HttpGet("/card")]
        public IActionResult CardPage()
        {
            CardUserVM CardInputModel = new CardUserVM();
            Random random = new Random();
            int x = random.Next(1,6);
            CardInputModel.Card = dbContext.Cards.Where(Card => Card.CardId == x).FirstOrDefault();
            int? loggeduserId = HttpContext.Session.GetInt32("currentuser");
            CardInputModel.User = dbContext.Users.Where(User => User.UserId == loggeduserId).FirstOrDefault();
            // Console.WriteLine("**************************************************************");
            // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(CardInputModel.Card));
            // Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(CardInputModel.User));
            // Console.WriteLine("**************************************************************");
            return View(CardInputModel);
        }

        // [HttpPost("/submitcard")]
        // public IActionResult SubmitCard()
        // {
        //     return RedirectToAction("Dashboard");
        // }

        // [HttpGet("/dashboard")]
        // public IActionResult Dashboard()
        // {
        //     return View();
        // }

        // [HttpPost("/vote")]
        // public IActionResult Vote()
        // {
        //     return RedirectToAction("WinnerPage");
        // }

        // [HttpGet("/winner")]
        // public IActionResult WinnerPage()
        // {
        //     return View();
        // }
    }
}