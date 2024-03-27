using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HandShaker.UserLib
{
    public class Chat : IEnumerable<Message>
    {
        public ImageSource Image { get; set; }
        public List<User> Members { get; private set; } = new List<User>();

        private readonly List<Message> messages_ = new List<Message>();
        public Chat(params User[] members)
        {
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


    }
}
