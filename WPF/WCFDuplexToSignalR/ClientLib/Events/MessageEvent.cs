using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Events
{
    public class MessageEvent : PubSubEvent<string>
    {
        public string Message { get; set; }
    }
}
