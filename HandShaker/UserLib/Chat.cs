using HandShaker.Hash;
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
        public int Id { get; private set; }
        public ImageSource Image { get; set; }
        public List<User> Members { get; private set; } = new List<User>();

        public string Name { get; private set; } = string.Empty;
        public Chat(string name, int id)
        {
            Id = id;
            Name = name;
        }

        private readonly List<Message> messages_ = new List<Message>();
        public Chat(string name, int id, params User[] members)
        {
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
            var attrId = "Id".GetSHA256();
            var attrImage = "Image".GetSHA256();
            var attrMembers = "Members".GetSHA256();
            var attrName = "Name".GetSHA256();
            var attrMessages = "Messages".GetSHA256();

            var dictAttrs = new Dictionary<string, string>();

            var jsonString = JsonSerializer.Serialize(dictAttrs);

            return jsonString;
        }
    }
}
