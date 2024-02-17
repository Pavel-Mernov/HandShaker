using HandShaker.Properties;
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
using System.Windows.Shapes;

namespace HandShaker
{
    /// <summary>
    /// Логика взаимодействия для MessengerWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        // string constants
        // private static readonly string _enterLoginText = "Введите логин";
        // private static readonly string _enterPasswordText = "Введите пароль";



        public EnterWindow()
        {
            InitializeComponent();


            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        // Click here if you forgot password
        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            var confirmationCodeWindow = new ConfirmationCodeWindow();
            confirmationCodeWindow.Show();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLogin.Text == string.Empty)
            {
                loginPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                loginPlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password))
            {
                passwordPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = User.ExampleAdmin;

            var mainWindow = new MainWindow(user);
            this.Hide();

            mainWindow.Show();
        }

        private void loginBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtLogin.Focus();
        }

        private void passwordBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }
    }
}
