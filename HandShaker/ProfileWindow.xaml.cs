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
using static HandShaker.Assets.ColorResources.Colors;

namespace HandShaker
{
    /// <summary>
    /// Логика взаимодействия для AdminProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public User User { get; private set; }

        public ProfileWindow(User user)
        {
            InitializeComponent();
            User = user;

            tbName.Text = User.UserName;
            tbCompany.Text = User.Company;
            tbPosition.Text = User.Position;
            tbEmail.Text = User.Email;
            passwordBox.Password = User.PasswordHash;
            avatarImage.Source = User.ImageSource;

            if (user.UserType != UserType.Admin)
            {
                userAddPanel.Visibility = Visibility.Hidden;
                UserSearchBorder.Visibility = Visibility.Hidden;
                UserListBorder.Visibility = Visibility.Hidden;
            }
            else
            {
                // Get All Users from DB and make view for all of them
                UserListBorder.Visibility = Visibility.Visible;
                UserListPanel.Children.Add(new UserItemView(Examples.OtherUser));
                
            }

            // TODO : Add all users from dataBase
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
            var mainWindow = new MainWindow(User);
            this.Hide();
            mainWindow.Show();
        }

        private void userAddPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            ImgAddUser.Foreground = LightGreen;
            TbAddUser.Foreground = DarkGray;
        }

        private void userAddPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            ImgAddUser.Foreground = DarkGreen;
            TbAddUser.Foreground = Black;
        }

        private void userAddPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var userAddWindow = new AddUserWindow();
            userAddWindow.Show();
            
        }

        private void UserSearchBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserSearchTextBox.Focus();
        }

        private void BtnImgSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserSearchTextBox.Focus();
        }

        private void UserSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserSearchTextBox.Text))
            {
                LbUserSearchPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                LbUserSearchPlaceHolder.Visibility = Visibility.Hidden;
            }
        }

        private void LbUserSearchPlaceHolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserSearchTextBox.Focus();
        }
    }
}
