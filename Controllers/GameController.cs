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
            if(cardcount >= 15)
            {
                return View();
            }
            else
            {
                Card card1 = new Card();
                card1.String1 = "It's the most";
                card1.String2 = "time of the";
                card1.String3 = ".";
                dbContext.Add(card1);
                dbContext.SaveChanges();
                Card card2 = new Card();
                card2.String1 = "There are many";
                card2.String2 = "ways to choose an/a";
                card2.String3 = ".";
                dbContext.Add(card2);
                dbContext.SaveChanges();
                Card card3 = new Card();
                card3.String1 = "This is Live! Speaking to you at the";
                card3.String2 = "forum from the broadcasting";
                card3.String3 = ".";
                dbContext.Add(card3);
                Card card4 = new Card();
                dbContext.SaveChanges();
                card4.String1 = "The weather is too";
                card4.String2 = "to go somewhere that's near an/a";
                card4.String3 = ".";
                dbContext.Add(card4);
                dbContext.SaveChanges();
                Card card5 = new Card();
                card5.String1 = "I have to go take a";
                card5.String2 = "";
                card5.String3 = "in the bathroom.";
                dbContext.Add(card5);
                dbContext.SaveChanges();
                Card card6 = new Card();
                card6.String1 = "The pasta is";
                card6.String2 = "and tastes like";
                card6.String3 = "gross...";
                dbContext.Add(card6);
                dbContext.SaveChanges();
                Card card7 = new Card();
                card7.String1 = "In the shadow world of spies, a/an";
                card7.String2 = "organization spies to infiltrate";
                card7.String3 = ".";
                dbContext.Add(card7);
                dbContext.SaveChanges();
                Card card8 = new Card();
                card8.String1 = "Acme Corporation, a";
                card8.String2 = "company that make explosives for many";
                card8.String3 = ".";
                dbContext.Add(card8);
                dbContext.SaveChanges();
                Card card9 = new Card();
                card9.String1 = "Now featuring a";
                card9.String2 = "film:";
                card9.String3 = "The Musical.";
                dbContext.Add(card9);
                dbContext.SaveChanges();
                Card card10 = new Card();
                card10.String1 = "Now featuring a";
                card10.String2 = "film:";
                card10.String3 = "The Musical.";
                dbContext.Add(card10);
                dbContext.SaveChanges();
                Card card11 = new Card();
                card11.String1 = "The new Avengers movie was";
                card11.String2 = "until they added";
                card11.String3 = ".";
                dbContext.Add(card11);
                dbContext.SaveChanges();
                Card card12 = new Card();
                card12.String1 = "It's";
                card12.String2 = "to go alone, take";
                card12.String3 = "!";
                dbContext.Add(card12);
                dbContext.SaveChanges();
                Card card13 = new Card();
                card13.String1 = "I walked outside and saw two";
                card13.String2 = "hobos eating a";
                card13.String3 = ".";
                dbContext.Add(card13);
                dbContext.SaveChanges();
                Card card14 = new Card();
                card14.String1 = "Yum! These bagels taste";
                card14.String2 = "but, they could use some";
                card14.String3 = ".";
                dbContext.Add(card14);
                dbContext.SaveChanges();
                Card card15 = new Card();
                card15.String1 = "I am";
                card15.String2 = "to take your";
                card15.String3 = ".";
                dbContext.Add(card15);
                dbContext.SaveChanges();
                return View();
            }
        }

        [HttpGet("/card")]
        public IActionResult CardPage()
        {
            CardUserVM CardInputModel = new CardUserVM();
            Random random = new Random();
            int x = random.Next(1,16);
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