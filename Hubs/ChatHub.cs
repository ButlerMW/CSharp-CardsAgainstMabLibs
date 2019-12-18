using System.Collections.Generic;
using System.Threading.Tasks;
using CardsAgainstMadLibs.Models;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
namespace CardsAgainstMadLibs.Hubs {
    public class CardSubmission {
        public string EncodedMsg { get; set; }
        public int VoteCount { get; set; } = 0;
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public class ChatHub : Hub {
        static List<CardSubmission> Submissions = new List<CardSubmission> ();
        public async Task SendMessage (string verb, string msg, string str1, string str2, string str3, int userId) {
            string encodedMsg = str1 + " " + verb + " " + str2 + " " + msg + " " + str3;
            CardSubmission newSubmission = new CardSubmission()
            {
                EncodedMsg = encodedMsg,
                UserId = userId
            };
            ChatHub.Submissions.Add (newSubmission);
            await Clients.All.SendAsync ("ReceiveMessage", Submissions);
        }

        public async Task Vote(CardSubmission CSub)
        {
            int index = Submissions.IndexOf(Submissions.Where(x => x.UserId == CSub.UserId).FirstOrDefault());
            System.Console.WriteLine(index);
            Submissions[index].VoteCount += 1;
            await Clients.All.SendAsync ("ReceiveMessage", Submissions);

        }
    }
}