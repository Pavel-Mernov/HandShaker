using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandShaker.UserLib
{
    public class User
    {
        public string UserName { get; private set; } = string.Empty;

        public string Company { get; private set; } = string.Empty;

        public string Position { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string PasswordHash { get; private set; } = string.Empty;

        public ImageSource ImageSource { get; private set; }

        public User() { }

        public User(string userName, string company, string position, string email, string passwordHash)
        {
            UserName = userName;
            Company = company;
            Position = position;
            Email = email;
            PasswordHash = passwordHash;
        }

        public User(string userName, string company, string position, string email, string passwordHash, ImageSource imageSource) 
            : this(userName, company, position, email, passwordHash)
        {
            ImageSource = imageSource;
        }

        public User(string userName, string company, string position, string email, string passwordHash, string imageUriString)
            : this(userName, company, position, email, passwordHash)
        {
            var uri = new Uri(imageUriString, UriKind.Relative);
            ImageSource = new BitmapImage(uri);
        }

        public static User ExampleUser { get; } = new User("Павел Мернов", "HandShaker Inc.", "Junior .NET-разработчик", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");
    }
}
