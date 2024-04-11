using HandShaker.Hash;
using HandShaker.Keys;
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
        private readonly string _key;
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
            _key = KeyGenerator.GenerateKey(16);

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
            var attrKey = "Key".GetSHA256();

            var key = _key;

            var valueId = Id.ToString().EncodeAES(key);
            var valueUserType = UserType.ToString().EncodeAES(key);
            var valueUserName = UserName.EncodeAES(key);
            var valueCompany = Company.EncodeAES(key);
            var valuePosition = Position.EncodeAES(key);
            var valueEmail = Email.EncodeAES(key);
            var valueIsOnline = IsOnline.ToString().EncodeAES(key);
            var valueChats = Chats.Select(chat => chat.Id.ToString().EncodeAES(key)).ToList();
            var valueImageSource = JsonSerializer.Serialize(ImageSource).EncodeAES(key);
            var valueKey = key.EncodeAES(KeyGenerator.GetUniversalKey());

            var dictAttrs = new Dictionary<string, string>
            {
                [attrId] = valueId,
                [userTypeAttr] = valueUserType,
                [userNameAttr] = valueUserName,
                [attrCompany] = valueCompany,
                [attrPosition] = valuePosition,
                [attrEmail] = valueEmail,
                [attrPasswordHash] = PasswordHash.EncodeAES(key),
                [attrIsOnline] = valueIsOnline,
                [attrChats] = JsonSerializer.Serialize(valueChats),
                [attrImageSource] = valueImageSource,
                [attrKey] = valueKey,
            };

            var jsonString = JsonSerializer.Serialize(dictAttrs);

            return jsonString;
        }
    }
}
