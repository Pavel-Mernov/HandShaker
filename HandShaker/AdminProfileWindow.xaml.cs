using HandShaker.Assets.UniversalElements;
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

            var userList = Examples.Users.Where(user => user != admin);

            foreach (var user in userList)
            {
                UsersMenuPanel.Children.Add(new UserMenuItem(user));
            }

            // UserSearchBox.MouseDown += UserSearchBox_MouseDown;
            UserSearchBox.BorderMouseDown += UserSearchBox_MouseDown;
            UserSearchBox.BorderMouseDown += (s, e) => UserSearchBox.Focus();
        }

        private void UserSearchBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MenuBorder.Visibility == Visibility.Visible)
            {
                MenuBorder.Visibility = Visibility.Collapsed;
                UsersMenuPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                MenuBorder.Visibility = Visibility.Visible;
                UsersMenuPanel.Visibility = Visibility.Visible;
            }
        }

        public override void OnApplyTemplate()
        {
            UserSearchBox = new SearchBox();
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
                try
                {
                    DragMove();
                }
                catch (InvalidOperationException)
                {

                }
            }
        }

        private void btnGoToMessages_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(Admin);

            mainWindow.Show();
            this.Hide();
            
        }

        private void userAddPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void userAddPanel_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void userAddPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MenuBorder.Visibility == Visibility.Visible)
            {
                MenuBorder.Visibility = Visibility.Hidden;
                UsersMenuPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                MenuBorder.Visibility = Visibility.Visible;
                UsersMenuPanel.Visibility = Visibility.Visible;
            }
        }

        /*
		private void SearchBox_MouseDown(object sender, MouseButtonEventArgs e)
		{
            var txtSearch = (TextBox)UserSearchBox.
                Template.FindName("TxtSearch", UserSearchBox);

            txtSearch.Focus();
		}
        */
	}
}
