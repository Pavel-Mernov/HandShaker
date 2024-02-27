using HandShaker.UserLib.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.UserLib.Messages
{
    public sealed partial class Message : IEquatable<Message>
    {

        public string Text { get; private set; }

        public User From { get; private set; }

        // public Chat Chat {  get; private set; }

        public ReadStatus Status { get; set; }

        public DateTime DateTime { get; private set; }

        public static Builder CreateBuilder()
        {
            return new Builder();
        }

        public Message() { }

        public Message(string text, User from, ReadStatus status, DateTime dateTime)
        {
            Text = text;
            From = from;
            // Chat = chat;
            Status = status;
            DateTime = dateTime;
        }

        public Message(string text, User from, DateTime dateTime)
        {
            Text = text;
            From = from;
            // Chat = chat;
            Status = ReadStatus.Sent;
            DateTime = dateTime;
        }

        public Message(string text, User from)
        {
            Text = text;
            From = from;
            // Chat = chat;
            Status = ReadStatus.Sent;
            DateTime = DateTime.Now;
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
