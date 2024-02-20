using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandShaker.UserLib
{
    public class User : IEquatable<User>
    {
        public UserType UserType { get; private set; }

        public int UserId { get; private set; }
        public string UserName { get; protected set; } = string.Empty;

        public string Company { get; protected set; } = string.Empty;

        public string Position { get; protected set; } = string.Empty;

        public string Email { get; protected set; } = string.Empty;

        public string PasswordHash { get; protected set; } = string.Empty;

        public ImageSource ImageSource { get; set; }

        public List<Chat> Chats { get; set; }

        public User() { }

        public User(UserType userType, int userId, string userName, string company, string position, string email, string passwordHash)
        {
            UserType = userType;
            UserId = userId;
            UserName = userName;
            Company = company;
            Position = position;
            Email = email;
            PasswordHash = passwordHash;
        }

        public User(UserType userType, int userId, string userName, string company, string position, string email, string passwordHash, ImageSource imageSource) 
            : this(userType, userId, userName, company, position, email, passwordHash)
        {
            ImageSource = imageSource;
        }

        public User(UserType userType, int userId, string userName, string company, string position, string email, string passwordHash, string imageUriString)
            : this(userType, userId, userName, company, position, email, passwordHash)
        {
            var uri = new Uri(imageUriString, UriKind.Relative);
            ImageSource = new BitmapImage(uri);
        }

        public static User ExampleUser { get; } 
            = new User(UserType.User, 0, "Павел Мернов", "HandShaker Inc.", "Junior .NET-разработчик", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");

        public static User ExampleAdmin { get; }
            = new User(UserType.Admin, 0, "Павел Мернов", "HandShaker Inc.", "Администратор", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");


        public override string ToString()
        {
            return string.Join(".", UserId, UserType, UserName, Company, Position);
        }

        public bool Equals(User other)
        {
            return UserId == other.UserId && UserType == other.UserType;
        }

		public override int GetHashCode()
		{
            return UserId.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return (obj is User) && Equals((User)obj);
		}

        public static bool operator ==(User left, User right)
        {
            return left.Equals(right);
        }

		public static bool operator !=(User left, User right)
		{
			return !left.Equals(right);
		}
	}
}
