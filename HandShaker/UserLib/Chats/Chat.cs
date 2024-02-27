using HandShaker.UserLib.Messages;
using HandShaker.UserLib.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandShaker.UserLib.Chats
{
    public class Chat : IEnumerable<Message>
    {
        // protected List<User> _members = new List<User>();
        // public IReadOnlyCollection<User> Members => _members.AsReadOnly();

        protected readonly List<Message> messages_ = new List<Message>();

        public ImageSource ImageSource { get; set; }

        public string ChatName { get; set; } = string.Empty;

        public virtual ImageSource GetImage(User user)
        {
            return ImageSource;
        }



        public virtual string GetName(User user)
        {
            return ChatName;
        }

        /*
        public Chat(params User[] members)
        {
            ImageSource = new BitmapImage()
            {
                UriSource = new Uri("/UserLib/PhotoDefaultChat.jpg", UriKind.Relative),
            };
            _members = members.ToList();
        }

        public Chat(IEnumerable<User> members)
        {
            ImageSource = new BitmapImage()
            {
                UriSource = new Uri("/UserLib/PhotoDefaultChat.jpg", UriKind.Relative),
            };
            _members = members.ToList();
        }
        */

        public Chat(string chatName, ImageSource image = null)
        {
            ChatName = chatName;
            ImageSource = image;
            // _members = members.ToList();
        }

        /*
        public Chat(string chatName, ImageSource image)
        {
            ChatName = chatName;
            ImageSource = image;
            // _members = members.ToList();
        }
        */

        public Chat(ImageSource image)
        {
            ImageSource = image;
            // _members = members.ToList();
        }

        /*
        public Chat(ImageSource image, IEnumerable<User> members)
        {
            ImageSource = image;
            _members = members.ToList();
        }
        */

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

        public override string ToString()
        {
            return this.GetName(null);
        }
    }
}
