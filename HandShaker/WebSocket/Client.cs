using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandShaker.WebSocket
{
    // Class for websocket client
    public class Client : IClient
    {
        readonly ClientWebSocket _client;

        private bool _isConnected = false;

        public Client()
        {
            _client = new ClientWebSocket();
        }

        public async Task ConnectAsync(string serverUri)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(60));

            try
            {
                await _client.ConnectAsync(new Uri(serverUri), cts.Token);
                _isConnected = true;
            }
            catch (WebSocketException)
            {
                _isConnected = false;
            }
        }

        // method that sends message to the server
        public async Task SendMessageAsync(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var buffer = new ArraySegment<byte>(messageBytes);

            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(60));

            if (_isConnected)
            {
                await _client.SendAsync(buffer, WebSocketMessageType.Text, endOfMessage: true, cts.Token);
            }
            // Console.WriteLine($"Sent message: {message}");

            await ReceiveMessageAsync();
        }

        public async Task ReceiveMessageAsync()
        {
            var buffer = new ArraySegment<byte>(new byte[App.CurrentApp.BuffSize]);

            var result = await _client.ReceiveAsync(buffer, CancellationToken.None);
            var receivedMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);

            
        }

    }
}
