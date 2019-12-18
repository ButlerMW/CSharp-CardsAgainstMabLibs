using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CardsAgainstMadLibs.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string str1, string str2, string str3)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, str1, str2, str3);
        }
    }
}