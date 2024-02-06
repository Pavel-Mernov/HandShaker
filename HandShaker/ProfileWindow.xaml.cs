﻿using HandShaker.UserLib;
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

        public ProfileWindow(User user)
        {
            InitializeComponent();
            this.user = user;

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

        }

        // Close this window and go back to messenger window
        private void btnGoToMessages_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}