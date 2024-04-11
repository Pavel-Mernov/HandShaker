using HandShaker.Hash;
using HandShaker.Keys;
using HandShaker.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HandShaker.UserLib
{
    public class Chat : IEnumerable<Message>, IJsonSerializable
    {
        private string _keyHint;

        private string _key;

        private void InitializeKeys()
        {
            var universalKey = KeyGenerator.GetUniversalKey();
            var keyHint = KeyGenerator.GenerateKey(12, 16);
            var key = KeyGenerator.GenerateKey(16, 32);

            _keyHint = keyHint.EncodeAES(universalKey);
            _key = key.EncodeAES(keyHint);
        }

        public int Id { get; private set; }
        public ImageSource Image { get; set; }
        public List<User> Members { get; private set; } = new List<User>();

        public string Name { get; private set; } = string.Empty;
        public Chat(string name, int id)
        {
            InitializeKeys();

            this.Id = id;
            Name = name;
        }

        private readonly List<Message> messages_ = new List<Message>();
        public Chat(string name, int id, params User[] members)
        {
            InitializeKeys();

            Id = id;
            Name = name;
            Members = members.ToList();
        }

        public ImageSource GetImage(User user)
        {
            if (Members.Count == 2)
            {
                var otherUser = Members.Find(curUser => curUser != user);
                return otherUser.ImageSource;
            }
            else
            {
                return Image;
            }
        }

        public string GetName(User user)
        {
            if (Members.Count == 2)
            {
                var otherUser = Members.Find(curUser => curUser != user);
                return otherUser.UserName;
            }
            else
            {
                return Name;
            }
        }

        public Chat(IEnumerable<User> members)
        {
            Members = members.ToList();
        }

        public IEnumerator<Message> GetEnumerator()
        {
            return messages_.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddMessage(Message message)
        {
            messages_.Add(message);
        }

        public void RemoveMessage(Message message)
        {
            messages_.Remove(message);
        }

        public string Serialize()
        {
            var attrKeyHint = "KeyHint".GetSHA256();
            var attrKey = "Key".GetSHA256();
            var attrId = "Id".GetSHA256();
            var attrImage = "Image".GetSHA256();
            var attrMembers = "Members".GetSHA256();
            var attrName = "Name".GetSHA256();
            var attrMessages = "Messages".GetSHA256();

            var valueKeyHint = _keyHint;
            var valueKey = _key;

            var keyHint = _keyHint.DecodeAES(KeyGenerator.GetUniversalKey());
            var key = _key.DecodeAES(KeyGenerator.GetUniversalKey());

            var valueId = Id.ToString().EncodeAES(key);
            var valueImage = JsonSerializer.Serialize(Image).EncodeAES(key);
            var membersList = Members.Select(member => member.Id.ToString().EncodeAES(key));
            var valueName = Name.EncodeAES(key);

            var messageList = new List<string>();

            foreach (var message in this)
            {
                var messageAttrs = new Dictionary<string, string>
                {
                    ["Text".GetSHA256()] = message.Text.EncodeAES(key),
                    ["From".GetSHA256()] = message.From.Id.ToString().EncodeAES(key),
                    ["Stattus".GetSHA256()] = message.Status.ToString().EncodeAES(key),
                    ["DateTime".GetSHA256()] = JsonSerializer.Serialize(message.DateTime).EncodeAES(key)
                };

                messageList.Add(JsonSerializer.Serialize(messageAttrs));
            }

            var dictAttrs = new Dictionary<string, string>
            {
                [attrKeyHint] = valueKeyHint,
                [attrKey] = valueKey,
                [attrId] = valueId,
                [attrImage] = valueImage,
                [attrMembers] = JsonSerializer.Serialize(membersList),
                [attrName] = valueName,
                [attrMessages] = JsonSerializer.Serialize(messageList),
            };
            
            var jsonString = JsonSerializer.Serialize(dictAttrs);

            return jsonString;
        }
    }
}
