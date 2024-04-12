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
    /// Логика взаимодействия для CallWindow.xaml
    /// </summary>
    public partial class CallWindow : Window
    {
        User _fromUser;
        User _toUser;

        public CallWindow(User fromUser, User toUser)
        {
            InitializeComponent();

            _fromUser = fromUser;
            _toUser = toUser;

            tbChatName.Text = _toUser.UserName;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCancel.Background = ClosingButtonPink;
        }

        private void btnCancel_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCancel.Background = ClosingButtonRed;
        }

        private void titleBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }
}
