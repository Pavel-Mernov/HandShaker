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

using System.Xml.Linq;
using HandShaker.UserLib;

    

    /// <summary>
    /// Логика взаимодействия для OtherUserWindow.xaml
    /// </summary>
    

namespace HandShaker
{
    public partial class OtherUserWindow : Window
    {
        private readonly User fromUser;
        private readonly User viewedUser;

        public OtherUserWindow(User fromUser, User viewedUser)
        {
            InitializeComponent();

            this.fromUser = fromUser;
            this.viewedUser = viewedUser;

            // Customize the window based on user type
            if (fromUser.UserType == UserType.Admin)
            {
                // Enable fields for editing
                tbName.IsEnabled = true;
                tbCompany.IsEnabled = true;
                tbPosition.IsEnabled = true;
                tbEmail.IsEnabled = true;
                passwordBox.IsEnabled = true;
                btnChangePhoto.IsEnabled = true;
                btnChangePassword.IsEnabled = true;
            }
            else
            {
                // Disable fields for editing
                tbName.IsEnabled = false;
                tbCompany.IsEnabled = false;
                tbPosition.IsEnabled = false;
                tbEmail.IsEnabled = false;
                passwordBox.IsEnabled = false;
                btnChangePhoto.IsEnabled = false;
                btnChangePassword.IsEnabled = false;
            }

            // Initialize user information
            InitializeUserInfo();
        }

        private void InitializeUserInfo()
        {
            // Set user information in UI elements
            tbName.Text = viewedUser.UserName;
            tbCompany.Text = viewedUser.Company;
            tbPosition.Text = viewedUser.Position;
            tbEmail.Text = viewedUser.Email;
        // Set user photo
            avatarImage.Source = viewedUser.ImageSource;
        }

        // Event handler for changing the user photo
        private void btnChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for changing user photo
            // For example, show a file dialog to select a new photo
        }

        // Event handler for changing the user password
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic for changing user password
            // For example, show a dialog to enter a new password
        }

        private void BtnGoToMessages_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(fromUser);

            mainWindow.Show();
            this.Close();
        }
    }
}

