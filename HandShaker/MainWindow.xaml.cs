using HandShaker.Assets.UniversalElements;
using HandShaker.UserLib;
using HandShaker.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandShaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly User user_;

        public MainWindow(User user)
        {
            InitializeComponent();
            user_ = user;

            foreach (var chat in user.Chats)
            {
                ChatsListPanel.Children.Add(new ChatView(user, chat, () => MakeUserChat(chat)));
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnGoToProfile_Click(object sender, RoutedEventArgs e)
        {
            Window profileWindow;

            profileWindow = new ProfileWindow(user_);

            

            profileWindow.Show();
            this.Close();
        }

        private void IconButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTextBox.Focus();
        }

        private void ChatSearchBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTextBox.Focus();
        }

        private void ChatTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(ChatTextBox.Text))
            {
                LbChatPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                LbChatPlaceHolder.Visibility = Visibility.Hidden;
            }
        }

        private void LbChatPlaceHolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTextBox.Focus();
        }

        private void MakeUserChat(Chat chat)
        {
            ChatPanel.Children.Clear();


        }
    }
}
