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
    /// Логика взаимодействия для ConfirmationCodeWindow.xaml
    /// </summary>
    public partial class ConfirmationCodeWindow : Window
    {
        public ConfirmationCodeWindow()
        {
            InitializeComponent();
        }

        private void codeBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtConfirmationCode.Focus();
        }

        private void txtConfirmationCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtConfirmationCode.Text == string.Empty)
            {
                loginPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                loginPlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void mainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
