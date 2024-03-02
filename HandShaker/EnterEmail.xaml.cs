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
    /// Логика взаимодействия для EnterEmail.xaml
    /// </summary>
    public partial class EnterEmail : Window
    {
        public EnterEmail()
        {
            InitializeComponent();
        }

        private void emailBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                emailPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                emailPlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var admin = Examples.Admin;

            var newWindow = new ConfirmationCodeWindow(admin);
            newWindow.Show();
            Hide();
        }

        private void mainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }
    }
}
