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
        public UserType UserType { get; private set; }
        public string UserName { get; protected set; } = string.Empty;

        public string Company { get; protected set; } = string.Empty;

        public string Position { get; protected set; } = string.Empty;

        public string Email { get; protected set; } = string.Empty;

        public string PasswordHash { get; protected set; } = string.Empty;

        public bool IsOnline { get; set; } = false;

        public ImageSource ImageSource { get; set; }

        public List<Chat> Chats { get; protected set; }

        public User() { }

        public User(UserType userType, string userName, string company, string position, string email, string passwordHash)
        {
            UserType = userType;
            UserName = userName;
            Company = company;
            Position = position;
            Email = email;
            PasswordHash = passwordHash;
        }

        public User(UserType userType, string userName, string company, string position, string email, string passwordHash, ImageSource imageSource) 
            : this(userType, userName, company, position, email, passwordHash)
        {
            ImageSource = imageSource;
        }

        public User(UserType userType, string userName, string company, string position, string email, string passwordHash, string imageUriString)
            : this(userType, userName, company, position, email, passwordHash)
        {
            var uri = new Uri(imageUriString, UriKind.Relative);
            ImageSource = new BitmapImage(uri);
        }

        public static User ExampleUser { get; } 
            = new User(UserType.User, "Павел Мернов", "HandShaker Inc.", "Junior .NET-разработчик", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");

        public static User ExampleAdmin { get; }
            = new User(UserType.Admin, "Павел Мернов", "HandShaker Inc.", "Администратор", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");


        public override string ToString()
        {
            return string.Join(".", UserType, UserName, Company, Position);
        }
    }
}
