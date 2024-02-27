using HandShaker.UserLib.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HandShaker.UserLib.Chats
{
    public class ChatForTwo : Chat
    {
        private readonly User[] _members = new User[2];

        public IReadOnlyCollection<User> Members => _members.ToList().AsReadOnly();

        public ChatForTwo(User user1, User user2) : base($"{user1.UserName} {user2.UserName}")
        {
            if (user1 == user2)
            {
                throw new ArgumentException($"Cannot create a chat for only one user: {user1}.");
            }
            _members = new User[] { user1, user2 };
        }

        public override string GetName(User user)
        {
            return GetOtherUser(user).UserName;
        }

        public User GetOtherUser(User user)
        {
            if (!Members.Contains(user))
            {
                throw new ArgumentException($"Chat {this} does not contain the User {user}.");
            }

            var otherUser = (user == _members[0]) ? _members[1] : _members[0];

            return otherUser;
        }

        public override ImageSource GetImage(User user)
        {
            if (!Members.Contains(user))
            {
                throw new ArgumentException($"Chat {this} does not contain the User {user}.");
            }

            var otherUser = (user == _members[0]) ? _members[1] : _members[0];

            return otherUser.ImageSource;
        }

        /*
        public override void AddUser(User user)
        {
            throw new NotSupportedException("Cannot Add Users to a Chat For two Users.");
        }

        public override void RemoveUser(User user)
        {
            throw new NotSupportedException("Cannot Remove Users from a Chat For two Users.");
        }
        */
    }
}
