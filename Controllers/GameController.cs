using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CardsAgainstMadLibs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using CardsAgainstMadLibs.Hubs;

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
            if(HttpContext.Session.GetInt32("currentuser") == null)
            {
                return Redirect("/loginreg");
            }
            int cardcount = dbContext.Cards.Count();
            Console.WriteLine(cardcount);
            // if(dbContext.Cards.Any(Card => Card.CardId == 5)) 
            if(cardcount >= 27)
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
                Card card16 = new Card();
                card16.String1 = "Christmas is a";
                card16.String2 = "time for celebrating the one and only";
                card16.String3 = ".";
                dbContext.Add(card16);
                dbContext.SaveChanges();
                Card card17 = new Card();
                card17.String1 = "Your mom likes her men";
                card17.String2 = "just like";
                card17.String3 = ".";
                dbContext.Add(card17);
                dbContext.SaveChanges();
                Card card18 = new Card();
                card18.String1 = "Without a";
                card18.String2 = "face,";
                card18.String3 = "would be out of a job.";
                dbContext.Add(card18);
                dbContext.SaveChanges();
                Card card19 = new Card();
                card19.String1 = "Crying like a";
                card19.String2 = "child won't make";
                card19.String3 = "respect you.";
                dbContext.Add(card19);
                dbContext.SaveChanges();
                Card card20 = new Card();
                card20.String1 = "I like to smell my";
                card20.String2 = "fingers after touching";
                card20.String3 = "'s feet.";
                dbContext.Add(card20);
                dbContext.SaveChanges();
                Card card21 = new Card();
                card21.String1 = "Danger:";
                card21.String2 = "Material left in the bathroom by";
                card21.String3 = ".";
                dbContext.Add(card21);
                dbContext.SaveChanges();
                Card card22 = new Card();
                card22.String1 = "In an emergency, use";
                card22.String2 = "powder to save";
                card22.String3 = "'s life";
                dbContext.Add(card22);
                dbContext.SaveChanges();
                Card card23 = new Card();
                card23.String1 = "Baseball is a";
                card23.String2 = "sport,";
                card23.String3 = "says so.";
                dbContext.Add(card23);
                dbContext.SaveChanges();
                Card card24 = new Card();
                card24.String1 = "Cancel your plans for Friday,";
                card24.String2 = "dinner with";
                card24.String3 = ".";
                dbContext.Add(card24);
                dbContext.SaveChanges();
                Card card25 = new Card();
                card25.String1 = "Can you bring my";
                card25.String2 = "shoes?";
                card25.String3 = "Stole my other pair.";
                dbContext.Add(card25);
                dbContext.SaveChanges();
                Card card26 = new Card();
                card26.String1 = "Drink that";
                card26.String2 = "potion. It helped";
                card26.String3 = "win the Nobel Prize.";
                dbContext.Add(card26);
                dbContext.SaveChanges();
                Card card27 = new Card();
                card27.String1 = "I don't think I'm all that";
                card27.String2 = "but";
                card27.String3 = "disagrees.";
                dbContext.Add(card27);
                dbContext.SaveChanges();
                return View();
            }
        }

        [HttpGet("/card")]
        public IActionResult CardPage()
        {
            if(HttpContext.Session.GetInt32("currentuser") == null)
            {
                return RedirectToAction("LoginRegPage", "LoginReg");
            }
            CardUserVM CardInputModel = new CardUserVM();
            Random random = new Random();
            // int x = random.Next(1,16); //Noun
            int x = random.Next(16,27); //Person
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