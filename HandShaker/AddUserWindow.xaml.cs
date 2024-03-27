using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HandShaker
{
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void mainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string company = txtCompany.Text;
            string position = txtPosition.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            string repeatPassword = txtRepeatPassword.Password;

            if (password != repeatPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            string userDetails = $"Username: {username}\nCompany: {company}\nPosition: {position}\nEmail: {email}\nPassword: {password}";
            MessageBox.Show(userDetails, "New User Details");

            Close();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            loginPlaceholder.Visibility = string.IsNullOrEmpty(txtUsername.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtCompany_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyPlaceholder.Visibility = string.IsNullOrEmpty(txtCompany.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            positionPlaceholder.Visibility = string.IsNullOrEmpty(txtPosition.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailPlaceholder.Visibility = string.IsNullOrEmpty(txtEmail.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = string.IsNullOrEmpty(txtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtRepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            repeatPasswordPlaceholder.Visibility = string.IsNullOrEmpty(txtRepeatPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
