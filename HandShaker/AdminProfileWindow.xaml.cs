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
    /// Логика взаимодействия для AdminProfileWindow.xaml
    /// </summary>
    public partial class AdminProfileWindow : Window
    {
        public User Admin { get; private set; }

        public AdminProfileWindow(User admin)
        {
            InitializeComponent();
            Admin = admin;

            tbName.Text = Admin.UserName;
            tbCompany.Text = Admin.Company;
            tbPosition.Text = Admin.Position;
            tbEmail.Text = Admin.Email;
            passwordBox.Password = Admin.PasswordHash;
            avatarImage.Source = Admin.ImageSource;
        }

        private void btnChangePhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var confirmationCodeWindow = new ConfirmationCodeWindow();
            confirmationCodeWindow.Show();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnGoToMessages_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(Admin);
            this.Hide();
            mainWindow.Show();
        }

        private void userAddPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            txtSearchUser.Focus();
        }

        private void userAddPanel_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void userAddPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void borderSearchUserPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtSearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchUser.Text))
            {
                lblSearchUser.Visibility = Visibility.Visible;
            }
            else
            {
                lblSearchUser.Visibility = Visibility.Hidden;
            }
        }
    }
}
