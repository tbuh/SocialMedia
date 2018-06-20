using Microsoft.AspNetCore.SignalR;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Hubs
{
    public class ChatHub : Hub
    {
        private ChatService _chatService;
        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }

        public void SendMessage(ChatMessage message)
        {
            _chatService.MessageFromAgent(message);
        }

        public override Task OnConnectedAsync()
        {
            _chatService.InitAgent(this.Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
