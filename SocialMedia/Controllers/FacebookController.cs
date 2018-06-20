using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class FacebookController : Controller
    {
        [HttpGet]
        public ActionResult Receive()
        {
            var query = Request.Query;

            //_logWriter.WriteLine(Request.RawUrl);

            if (query["hub.mode"] == "subscribe" &&
                query["hub.verify_token"] == "verify_token")
            {
                //string type = Request.QueryString["type"];
                var retVal = query["hub.challenge"];
                return Json(int.Parse(retVal));
            }
            else
            {
                return NotFound("Receive Failed");
            }
        }

        [HttpPost("Receive")]
        public async Task<ActionResult> ReceivePost(BotRequest data)
        {
            foreach (var entry in data.entry)
            {
                foreach (var message in entry.messaging)
                {
                    if (string.IsNullOrWhiteSpace(message?.message?.text))
                        continue;

                    var fbmsg = message.message.text;
                    try
                    {
                        //var chatMessage = chatService.AddFBMessage(message.sender.id, fbmsg);

                        //if (chatMessage.ChatRoom.AgentId != null)
                        //{
                        //    //var chatUser = chatService.GetChatUserByAgentId(chatMessage.ChatRoom.AgentId);
                        //    //if (chatUser != null)
                        //    //{
                        //    var notificationHub = GlobalHost.ConnectionManager.GetHubContext<Hubs.Chat>();
                        //    //foreach (var connectedClient in chatUser.ConnectedClients)
                        //    //{
                        //    //    await (Task)notificationHub.Clients.Client(connectedClient.ConnectionId).addNewMessageToPage("Facebook User", chatMessage.Text);
                        //    //}
                        //    await (Task)notificationHub.Clients.Client(chatMessage.ChatRoom.ConnectionId).addNewMessageToPage("Facebook User", chatMessage.Text);
                        //    //}
                        //}
                    }
                    catch (Exception ex)
                    {
                        //fBService.Send(message.sender.id, $"Error: {ex.Message}. Please wait few minutes!");
                    }
                }
            }

            return Ok();
        }
    }
}
