﻿using HandShaker.UserLib.Users;
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

namespace HandShaker.Assets.Windows
{
    /// <summary>
    /// Логика взаимодействия для OtherUserWindow.xaml
    /// </summary>
    public partial class OtherUserWindow : Window
    {
        readonly User _fromUser;
        readonly User _viewedUser;
        public OtherUserWindow(User fromUser, User viewedUser)
        {
            InitializeComponent();
            _fromUser = fromUser;
            _viewedUser = viewedUser;

            tbName.Text = _viewedUser.UserName;
            tbCompany.Text = _viewedUser.Company;
            tbPosition.Text = _viewedUser.Position;
            tbEmail.Text = _viewedUser.Email;
            passwordBox.Password = new string(new char[_viewedUser.PasswordHash.Length]);
            avatarImage.Source = _viewedUser.ImageSource;

            if (_fromUser.UserType == UserType.Admin)
            {
                btnChangeCompany.Visibility = Visibility.Visible;
                btnChangePosition.Visibility = Visibility.Visible;
                btnChangeEmail.Visibility = Visibility.Visible;
                btnChangeName.Visibility = Visibility.Visible;
            }
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }

        private void btnGoToMessages_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(_fromUser);
            mainWindow.Show();
            Hide();
        }

        private void btnChangeCompany_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangePosition_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangeEmail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChangeName_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
