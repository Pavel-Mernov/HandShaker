using HandShaker.Assets.ColorResources;
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

namespace HandShaker.Assets.Windows
{
    /// <summary>
    /// Логика взаимодействия для SetCompanyWindow.xaml
    /// </summary>
    public partial class SetCompanyWindow : Window
    {
        User _user;
        Action _onHide;
        public SetCompanyWindow(User user, Action onHideAction)
        {
            InitializeComponent();
            _user = user;
            _onHide = onHideAction;

            TxtCompany.Text = _user.Company;

            closeButton.Click += (s, e) => { _onHide(); };
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
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
