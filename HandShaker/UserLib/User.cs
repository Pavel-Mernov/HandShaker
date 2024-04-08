using HandShaker.Hash;
using HandShaker.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandShaker.UserLib
{
    public class User : IJsonSerializable
    {
        public int Id { get; private set; }
        public UserType UserType { get; private set; }
        public string UserName { get; protected set; } = string.Empty;

        public string Company { get; protected set; } = string.Empty;

        public string Position { get; protected set; } = string.Empty;

        public string Email { get; protected set; } = string.Empty;

        public string PasswordHash { get; protected set; } = string.Empty;

        public bool IsOnline { get; set; } = false;

        public ImageSource ImageSource { get; set; }

        public List<Chat> Chats { get; } = new List<Chat>();

        public User() { }

        public User(int id, UserType userType, string userName, string company, string position, string email, string passwordHash)
        {
            Id = id;
            UserType = userType;
            UserName = userName;
            Company = company;
            Position = position;
            Email = email;
            PasswordHash = passwordHash;
        }

        public User(int id, UserType userType, string userName, string company, string position, string email, string passwordHash, ImageSource imageSource) 
            : this(id, userType, userName, company, position, email, passwordHash)
        {
            ImageSource = imageSource;
        }

        public User(int id, UserType userType, string userName, string company, string position, string email, string passwordHash, string imageUriString)
            : this(id, userType, userName, company, position, email, passwordHash)
        {
            var uri = new Uri(imageUriString, UriKind.Relative);
            ImageSource = new BitmapImage(uri);
        }

        public static User ExampleUser { get; } 
            = new User(1, UserType.User, "Павел Мернов", "HandShaker Inc.", "Junior .NET-разработчик", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");

        public static User ExampleAdmin { get; }
            = new User(0, UserType.Admin, "Павел Мернов", "HandShaker Inc.", "Администратор", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");


        public override string ToString()
        {
            return string.Join(".", UserType, UserName, Company, Position);
        }

        public string Serialize()
        {
            var attrId = "Id".GetSHA256();
            var userTypeAttr = "UserType".GetSHA256();
            var userNameAttr = "UserName".GetSHA256();
            var attrCompany = "Company".GetSHA256();
            var attrPosition = "Position".GetSHA256();
            var attrEmail = "Email".GetSHA256();
            var attrPasswordHash = "PasswordHash".GetSHA256();
            var attrIsOnline = "IsOnline".GetSHA256();
            var attrChats = "Chats".GetSHA256();
            var attrImageSource = "ImageSource".GetSHA256();

            var passwordHash = PasswordHash;

            var valueId = Id.ToString().EncodeAES(passwordHash);
            var valueUserType = UserType.ToString().EncodeAES(passwordHash);
            var valueUserName = UserName.EncodeAES(passwordHash);
            var valueCompany = Company.EncodeAES(passwordHash);
            var valuePosition = Position.EncodeAES(passwordHash);
            var valueEmail = Email.EncodeAES(passwordHash);
            var valueIsOnline = IsOnline.ToString().EncodeAES(passwordHash);
            

            var dictAttrs = new Dictionary<string, string>
            {
                [attrId] = valueId,
                [userTypeAttr] = valueUserType,
                [userNameAttr] = valueUserName,
                [attrCompany] = valueCompany,
                [attrPosition] = valuePosition,
                [attrEmail] = valueEmail,
                [attrPasswordHash] = passwordHash,
                [attrIsOnline] = valueIsOnline,
            };

            var jsonString = JsonSerializer.Serialize(dictAttrs);

            return jsonString;
        }
    }
}
