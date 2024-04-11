using HandShaker.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.UserLib
{
    public sealed class Message : IEquatable<Message>
    {
        public string Text { get; private set; }

        public User From { get; private set; }

        public ReadStatus Status { get; private set; }

        public DateTime DateTime { get; private set; }



        public Message(string text, User from, DateTime dateTime)
        {
            Text = text;
            From = from;
            DateTime = dateTime;
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }

        public bool Equals(Message other)
        {
            return From.Equals(other.From) && DateTime.Equals(other.DateTime);
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Message && Equals((Message)obj);
        }

    }
}
