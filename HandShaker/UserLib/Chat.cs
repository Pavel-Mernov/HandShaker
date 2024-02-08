using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.UserLib
{
    public class Chat : IEnumerable<Message>
    {
        public List<User> Members { get; private set; } = new List<User>();

        private List<Message> messages_ = new List<Message>();
        public Chat(params User[] members)
        {
            Members = members.ToList();
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
