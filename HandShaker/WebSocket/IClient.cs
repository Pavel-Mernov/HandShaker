using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.WebSocket
{
    public interface IClient
    {
        void Connect(string serverUriString);

        // method that sends message to the server
        void SendMessage(string message);
    }
}
