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
    public class Client
    {
        ClientWebSocket _client;
        Uri _serverUri;
        private readonly CancellationTokenSource _cTS = new CancellationTokenSource();

        private bool _isConnected = false;

        public Client(string uriString)
        {
            _client = new ClientWebSocket();
        }

        public async void Connect(string serverUriString)
        {
            _serverUri = new Uri(serverUriString);

            try
            {
                await _client.ConnectAsync(_serverUri, _cTS.Token);
                _isConnected = true;

            }
            catch (WebSocketException)
            {
                _isConnected = false;
            }
        }

        // method that sends message to the server
        public async void SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (_isConnected && _client.State == WebSocketState.Open)
            {
                var messageBytesSegment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                await _client.SendAsync(messageBytesSegment, WebSocketMessageType.Text, true, _cTS.Token);
            }
        }
    }
}
