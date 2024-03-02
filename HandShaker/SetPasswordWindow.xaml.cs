using HandShaker.UserLib.Users;
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
using System.Windows.Shapes;

namespace HandShaker
{
    /// <summary>
    /// Логика взаимодействия для SetPasswordWindow.xaml
    /// </summary>
    public partial class SetPasswordWindow : Window
    {
        User _user;
        public SetPasswordWindow(User user)
        {
            InitializeComponent();

            _user = user;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void enterPasswordBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            enterPasswordBox.Focus();
        }

        private void enterPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(enterPasswordBox.Password))
            {
                enterPasswordPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                enterPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void repeatPasswordBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            repeatPasswordBox.Focus();
        }

        private void repeatPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(repeatPasswordBox.Password))
            {
                repeatPasswordPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                repeatPasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void mainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
