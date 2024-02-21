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
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public User User { get; private set; }

        public ProfileWindow(User user)
        {
            InitializeComponent();
            this.User = user;

            tbName.Text = User.UserName;
            tbCompany.Text = User.Company;
            tbPosition.Text = User.Position;
            tbEmail.Text = User.Email;
            passwordBox.Password = User.PasswordHash;
            avatarImage.Source = User.ImageSource;

            /*
            var binding = new Binding()
            {
                ElementName = "user",
                Path = new PropertyPath("ImageSource")
            };

            avatarImage.SetBinding(Image.SourceProperty, binding);
            */
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnChangePhoto_Click(object sender, RoutedEventArgs e)
        {

        }



        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var confirmationCodeWindow = new ConfirmationCodeWindow();
            confirmationCodeWindow.Show();
        }

        // Close this window and go back to messenger window
        private void btnGoToMessages_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(User);
            
            mainWindow.Show();
            Hide();
        }
    }
}
