
using HandShakerAdmin.WebSocket;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HandShakerAdmin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App CurrentApp => (App)Current;

        public IClient Client { get; private set; }
        // public User User { get; set; }

        public int BuffSize => 1 << 16;

        public static int ConnectionId => 5243;
        public static string ConnectionString => $"ws://localhost:{ConnectionId}/send";

        public App()
        {
            Client = new Client();

            Client.ConnectAsync(ConnectionString);

            Client.SendMessageAsync("Admin client wants to enter");
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            // User.IsOnline = false;
        }
    }

}
