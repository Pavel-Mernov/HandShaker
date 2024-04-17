using HandShakerAdmin.Hash;
using HandShakerAdmin.Request;
using HandShakerAdmin.UserLib;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandShakerAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void BtnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string company = txtCompany.Text;
            string position = "Администратор";
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            string repeatPassword = txtRepeatPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(company) || string.IsNullOrEmpty (position) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(repeatPassword))
            {
                MessageBox.Show("All fields must me filled!");
                return;
            }
            if (password != repeatPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            string userDetails = $"Username: {username}\nCompany: {company}\nPosition: {position}\nEmail: {email}\n";
            MessageBox.Show(userDetails, "New Admin Details");



            var admin = new User(UserType.Admin, username, company, position, email, password.GetSHA256());
            var addUserRequest = new AddUserRequest(admin);

            App.CurrentApp.Client.SendMessageAsync(addUserRequest.Serialize());

            txtUsername.Text = string.Empty; 
            txtCompany.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtRepeatPassword.Password = string.Empty;

            //App.CurrentApp.Shutdown();
        }

        private void TxtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            loginPlaceholder.Visibility = string.IsNullOrEmpty(txtUsername.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TxtCompany_TextChanged(object sender, TextChangedEventArgs e)
        {
            companyPlaceholder.Visibility = string.IsNullOrEmpty(txtCompany.Text) ? Visibility.Visible : Visibility.Collapsed;
        }


        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailPlaceholder.Visibility = string.IsNullOrEmpty(txtEmail.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = string.IsNullOrEmpty(txtPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TxtRepeatPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            repeatPasswordPlaceholder.Visibility = string.IsNullOrEmpty(txtRepeatPassword.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}