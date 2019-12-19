using System.Collections.Generic;
using System.Threading.Tasks;
using CardsAgainstMadLibs.Models;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CardsAgainstMadLibs.Hubs {
    public class CardSubmission {
        public string EncodedMsg { get; set; }
        public int VoteCount { get; set; } = 0;
        public int UserId { get; set; }
        public string Username { get; set; }
    }
    public class ChatHub : Hub {
        static List<CardSubmission> Submissions = new List<CardSubmission> ();
        public async Task SendMessage (string verb, string msg, string str1, string str2, string str3, int userId, string Username) {
            string encodedMsg = str1 + " " + verb + " " + str2 + " " + msg + " " + str3;
            CardSubmission newSubmission = new CardSubmission()
            {
                EncodedMsg = encodedMsg,
                UserId = userId,
                Username = Username
            };
            ChatHub.Submissions.Add (newSubmission);
            await Clients.All.SendAsync ("ReceiveMessage", Submissions);
        }

        public async Task Vote(CardSubmission CSub)
        {
            // int? loggeduserId = HttpContext.Session.GetInt32("currentuser");

            // if(CSub.UserId == (int)HttpContext.Session.GetInt32("currentuser"))
            int index = Submissions.IndexOf(Submissions.Where(x => x.UserId == CSub.UserId).FirstOrDefault());
            // System.Console.WriteLine(index);
            Submissions[index].VoteCount += 1;
            await Clients.All.SendAsync ("ReceiveMessage", Submissions);

        }

        public async Task<string> CalculateWinner()
        {
            // System.Console.WriteLine("*********%%%%%%%%%%%*********%%%%%%%%%%%*********%%%%%%%%%%%");
            List<CardSubmission> winnercard = Submissions.OrderByDescending(User => User.VoteCount ).Take(1).ToList();
            // System.Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(winnercard));
            // System.Console.WriteLine("######################################");
            string winnernametodisplay = winnercard[0].Username;
            
            // List<CardSubmission> listwinner = (List<CardSubmission>)winner;
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(winnercard));


            // System.Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            // int winningvotes = winner.VoteCount;
            // System.Console.WriteLine($"{winnernametodisplay} is the winner with {winningvotes} votes!");
            // // await Clients.All.SendAsync ("ReceiveMessage", Submissions);
            // System.Console.WriteLine("******************************************************");
            System.Console.WriteLine($"{winnernametodisplay} is the WINNER!!!!!!!!!!!!!!");

            // System.Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            return await Task.FromResult<string>(winnernametodisplay);
        }

        public void PlayAgain()
        {
            ChatHub.Submissions.Clear();
            System.Console.WriteLine("*********************");
            // await Clients.All.SendAsync ("ReceiveMessage", Submissions);
        }
    }
}