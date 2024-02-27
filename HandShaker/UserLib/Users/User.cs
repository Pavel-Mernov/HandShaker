using HandShaker.UserLib.Chats;
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

namespace HandShaker.UserLib.Users
{
    public partial class User : IEquatable<User>
    {
        // private static Builder builder = null;

        private ImageSource imageSource = null;



        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public UserType UserType { get; private set; }

        public int UserId { get; private set; }

        public bool IsOnline { get; set; } = false;

        public DateTime LastSeen { get; set; }

        public string UserName { get; protected set; } = string.Empty;

        public string Company { get; protected set; } = string.Empty;

        public string Position { get; protected set; } = string.Empty;

        public string Email { get; protected set; } = string.Empty;

        public string PasswordHash { get; protected set; } = string.Empty;

        public ImageSource ImageSource 
        {
            get => imageSource;
            set
            {
                if (imageSource == value)
                {
                    return;
                }

                if (imageSource == null)
                {
                    imageSource = value;
                    return;
                }

                imageSource = value;
            }
        }

        public List<Chat> Chats { get; } = new List<Chat>();

        public User() { }

        /*
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
        */

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
