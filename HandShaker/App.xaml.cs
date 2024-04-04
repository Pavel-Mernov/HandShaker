using HandShaker.UserLib;
using HandShaker.WebSocket;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace HandShaker
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IClient Client { get; private set; }
        public User User {  get; set; }

        public int BuffSize => 1 << 16;

        public static int ConnectionId => 5243;
        public static string ConnectionString => $"ws://localhost:{ConnectionId}/send";

        public static App CurrentApp => (App)Current;
        public App()
        {
            Client = new Client();

            Client.ConnectAsync(ConnectionString);

            Client.SendMessageAsync("Client entered");
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            User.IsOnline = false;
        }
    }
}
