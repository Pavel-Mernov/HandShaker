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
        Task ConnectAsync(string serverUriString);

        // method that sends message to the server
        Task SendMessageAsync(string message);

        // method that receives message from the server
        Task ReceiveMessageAsync();
    }
}
