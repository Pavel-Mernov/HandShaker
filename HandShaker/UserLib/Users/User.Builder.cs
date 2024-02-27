using HandShaker.UserLib.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandShaker.UserLib.Users
{
    public partial class User : IEquatable<User>
    {
        public class Builder
        {
            private readonly User _user = new User();
            internal Builder()
            {
            }

            public Builder SetId(int id)
            {
                if (id < 0)
                {
                    throw new ArgumentOutOfRangeException("ID cannot be less than zero.");
                }

                _user.UserId = id;
                return this;
            }

            public Builder SetOnline(bool isOnline)
            {
                _user.IsOnline = isOnline;
                return this;
            }

            public Builder SetUserName(string userName) 
            { 
                _user.UserName = userName; 
                return this;
            }

            public Builder SetStatus(UserType status)
            {
                _user.UserType = status;
                return this;
            }

            public Builder SetCompany(string company)
            {
                _user.Company = company;
                return this;
            }

            public Builder SetPosition(string position)
            {
                _user.Position = position;
                return this;
            }

            public Builder SetLastTime(DateTime lastTime)
            {
                _user.LastSeen = lastTime;
                return this;
            }

            public Builder SetEmail(string email)
            {
                _user.Email = email;
                return this;
            }

            public Builder SetPassword(string passwordHash)
            {
                _user.PasswordHash = passwordHash;
                return this;
            }

            public Builder SetImage(string imageSourceString)
            {
                var uri = new Uri(imageSourceString, UriKind.RelativeOrAbsolute);
                var source = new BitmapImage(uri);

                _user.ImageSource = source;
                return this;
            }

            public Builder SetImage(ImageSource imageSource)
            {
                _user.ImageSource = imageSource;
                return this;
            }

            /*
            public Builder AddChats(IEnumerable<Chat> chats)
            {
                // var localChats = chats.Where(chat => chat != null && chat.Members.Contains(_user));

                foreach (var chat in chats)
                {
                    _user.Chats.Add(chat);
                }

                return this;
            }

            public Builder AddChats(params Chat[] chats)
            {
                IEnumerable<Chat> chatsAsEnumerable = chats;
                return AddChats(chatsAsEnumerable);
            }
            */

            public User Build() => _user;
        }
    }
}
