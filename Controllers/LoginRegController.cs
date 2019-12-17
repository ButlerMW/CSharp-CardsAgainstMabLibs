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
    public class LoginRegController : Controller
    {
        private CardsAgainstMadLibsContext dbContext;
        public LoginRegController(CardsAgainstMadLibsContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult LandingPage()
        {
            return View();
        }

        [HttpGet("/loginreg")]
        public IActionResult LoginRegPage()
        {
            return View();
        }


        [HttpPost("/register")]
        public IActionResult RegisterNewUser(LoginRegVM model)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Username == model.User.Username))
                {
                    ModelState.AddModelError("User.Username", "Username already in use");
                    return View("LoginRegPage");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                model.User.Password = Hasher.HashPassword(model.User, model.User.Password);
                dbContext.Add(model.User);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("currentuser", (int)model.User.UserId);
                return RedirectToAction("Welcome", "Game");
            }
            return View("LoginRegPage");
        }

        [HttpPost("/login")]
        public IActionResult LoginUser(LoginRegVM model)
        {
            if(ModelState.IsValid)
            {
                User loggeduser = dbContext.Users.FirstOrDefault(u => u.Username == model.Credentials.Username);
                if(loggeduser == null)
                {
                    ModelState.AddModelError("Credentials.Username", "Username provided is not associated with a user account");
                    return View("LoginRegPage");
                }
                PasswordHasher<Credentials> hasher = new PasswordHasher<Credentials>();
                Microsoft.AspNetCore.Identity.PasswordVerificationResult result = hasher.VerifyHashedPassword(model.Credentials, loggeduser.Password, model.Credentials.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Credentials.Password", "Password provided does not match registered user account");
                    return View("LoginRegPage");
                }
                HttpContext.Session.SetInt32("currentuser", (int)loggeduser.UserId);
                return RedirectToAction("Welcome", "Game");
            }
            return View("LoginRegPage", model);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginRegPage");
        }

    }
}