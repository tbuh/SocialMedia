using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Hubs
{
    public class ChatHub : Hub
    {
        public Task Send(string data)
        {
            return Clients.All.SendAsync("Send", "Send Test Done...");
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
