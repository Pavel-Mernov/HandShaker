using HandShaker.UserLib.Users;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using HandShaker.Assets.ColorResources;

namespace HandShaker.Assets.Windows
{
    /// <summary>
    /// Логика взаимодействия для SetUserNameWindow.xaml
    /// </summary>
    public partial class SetUserNameWindow : Window
    {
        User _user;
        Action _onHide;
        public SetUserNameWindow(User user, Action onHide)
        {
            InitializeComponent();
            _user = user;
            _onHide = onHide;

            closeButton.Click += (s, e) => { onHide(); };

            var splitName = _user.UserName.Split(' ');

            NameTextBox.Text = splitName[0]; // user first name
            SurnameTextBox.Text = splitName[1]; // user last name
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void NameTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            NameTextBox.BorderBrush = Colors.Black;
        }

        private void NameTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            NameTextBox.BorderBrush = Colors.BorderGray;
        }

        public new void Hide()
        {
            _onHide();
            base.Hide();
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }
    }
}
