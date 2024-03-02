using HandShaker.UserLib.Chats;
using HandShaker.UserLib.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HandShaker.Assets.UniversalElements
{
    public class ChatViewPanel : StackPanel
    {
        public User CurrentUser { get; private set; }

        public Chat Chat { get; private set; }

        

        public ChatViewPanel(User currentUser, Chat chat)
        {
            CurrentUser = currentUser;
            Chat = chat;

            
        }


    }
}
