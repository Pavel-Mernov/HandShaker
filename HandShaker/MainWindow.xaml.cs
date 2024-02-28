using HandShaker.Assets.UniversalElements;
using HandShaker.UserLib;
using HandShaker.UserLib.Users;
using System;
using System.Collections;
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
        private User user_;



        public IEnumerable UserChats
        {
            get { return (IEnumerable)GetValue(UserChatsProperty); }
            private set { SetValue(UserChatsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserChatsProperty =
            DependencyProperty.Register("UserChats", typeof(IEnumerable), typeof(MainWindow), null);



        public MainWindow(User user)
        {
            InitializeComponent();

            //ChatsPanelScrollViewer.Height = Height - 60;

            user_ = user;
            

            UserChats = user.Chats.Select(chat => new ChatMenuItem(user, chat));

            foreach (var chat in UserChats)
            {
                ChatListMenu.Children.Add((MenuItem)chat);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGoToProfile_Click(object sender, RoutedEventArgs e)
        {
            Window profileWindow;

            if (user_.UserType == UserType.User)
            {
                profileWindow = new ProfileWindow(user_);
            }
            else
            {
                profileWindow = new AdminProfileWindow(user_);
            }

            profileWindow.Show();
            this.Hide();
        }

        


    }
}
