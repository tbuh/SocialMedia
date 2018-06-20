using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class MessagesStorage
    {
        private object _lock = new object();
        private Dictionary<string, List<string>> _messages;
        private Dictionary<string, string> _agent;

        public void AddMessage(string fbUserId, string message)
        {
            lock (_lock)
            {
                if (!_messages.ContainsKey(fbUserId)) _messages.Add(fbUserId, new List<string>());
                _messages[fbUserId].Add(message);
            }
        }

        public List<string> GetMessage(string agentId)
        {
            //lock (_lock)
            //{
            //    if (_agent.ContainsKey(agentId))
            //    {
            //        var tmp = _messages[_agent[agentId]];
            //        var res = new List<string>(tmp);
            //        tmp.Clear();
            //        return res;
            //    }
            //    else
            //    {

            //    }
            //}
            return null;
        }
    }
}
