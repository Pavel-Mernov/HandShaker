using HandShaker.UserLib;
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
        private User user_;

        public MainWindow(User user)
        {
            InitializeComponent();
            user_ = user;
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

        private void btnGoToProfile_Click(object sender, RoutedEventArgs e)
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

            this.Hide();
            profileWindow.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchChat.Text))
            {
                lblSearch.Visibility = Visibility.Visible;
            }
            else
            {
                lblSearch.Visibility = Visibility.Hidden;
            }
        }

        private void lblSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSearchChat.Focus();
        }

        private void borderSearchPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtSearchChat.Focus();
        }


    }
}
