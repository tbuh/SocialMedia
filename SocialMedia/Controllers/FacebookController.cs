using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Services;

namespace SocialMedia.Controllers
{
    public class FacebookController : Controller
    {
        private SocialAPISettings _socialAPISettings;
        private ChatService _chatService;
        public FacebookController(SocialAPISettings socialAPISettings, ChatService chatService)
        {
            _chatService = chatService;
            _socialAPISettings = socialAPISettings;
        }

        [HttpGet]
        public ActionResult Receive()
        {
            var query = Request.Query;

            //_logWriter.WriteLine(Request.RawUrl);

            if (query["hub.mode"] == "subscribe" &&
                query["hub.verify_token"] == _socialAPISettings.Facebook_verify_token)
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

        [HttpPost]
        public async Task<ActionResult> Receive(BotRequest data)
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
                        await _chatService.MessageFromFB(message.sender.id, fbmsg);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Test(string data)
        {
            try
            {
                await _chatService.MessageFromFB(null, data);
            }
            catch (Exception ex)
            {
            }
            return Ok();
        }
    }
}
