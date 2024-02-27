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
        // Builder for the message
        public class Builder
        {
            private readonly Message _message;
            internal Builder()
            {
                _message = new Message();
            }


            public Builder SetText(string text)
            {
                _message.Text = text;
                return this;
            }

            public Builder SetFrom(User user)
            {
                _message.From = user;
                return this;
            }

            public Builder SetDateTime(DateTime dateTime)
            {
                _message.DateTime = dateTime;
                return this;
            }

            public Message Build()
            {
                return _message;
            }
        }
    }
}
