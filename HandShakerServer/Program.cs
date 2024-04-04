using HandShakerServer.Requests;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace HandShakerServer
{
    public static class Program
    {
        static int BuffSize => 1 << 16;

        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.UseRouting();

            var wsOptions = new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120) };
            app.UseWebSockets(wsOptions);

            app.Use(async (HttpContext context, Func<Task> next) =>
            { 
                if (context.Request.Path == "/send")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await SendAsync(context, webSocket);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                }
            });

            // app.MapGet("/", () => "Hello World!");

            app.Run();
        }

        private static async Task SendAsync(HttpContext context, WebSocket webSocket)
        {
            byte[] buffer = new byte[BuffSize];

            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            WebSocketReceiveResult? result = null;

            do
            {
                try
                {
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var message = Encoding.UTF8.GetString(buffer, 0, result == null ? 0 : result.Count);

                if (!string.IsNullOrEmpty(message))
                {
                    var request = message.ParseRequest(); 
                }

                var response = "Server: OK";
                var responseBytes = Encoding.UTF8.GetBytes(response);
                var responceBuffer = new ArraySegment<byte>(responseBytes);

                await webSocket.SendAsync(responceBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
            while (result != null && !result.CloseStatus.HasValue);

            await webSocket.CloseAsync(webSocket.CloseStatus.Value, result?.CloseStatusDescription, CancellationToken.None);
        }
    }
}
