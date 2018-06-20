using Microsoft.AspNetCore.SignalR;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ChatService
    {
        private IHubContext<Hubs.ChatHub> _chatHub;
        private FacebookApi _facebookApi;

        private string _fbUserId;
        private string _agentId;

        public ChatService(IHubContext<Hubs.ChatHub> chatHub, FacebookApi facebookApi)
        {
            _chatHub = chatHub;
            _facebookApi = facebookApi;
        }

        public async Task MessageFromFB(string userId, string message)
        {
            _fbUserId = userId;
            ChatMessage chatMessage = new ChatMessage
            {
                message = message,
            };

            await (Task)_chatHub.Clients.Client(_agentId).SendAsync("Send", chatMessage);
        }

        public void MessageFromAgent(ChatMessage message)
        {
            _facebookApi.Send(_fbUserId, message.message);
        }

        public void InitAgent(string agentId)
        {
            _agentId = agentId;
        }
    }
}
