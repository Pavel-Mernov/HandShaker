using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;

namespace HandShaker.Assets.UniversalElements
{
    public partial class ChatView : ContentControl
    {
        public User User { get; }
        public Chat Chat { get; }

        private Image imgUser => Template.FindName("imgUser", this) as Image;
        private TextBlock lblLastMessage => Template.FindName("lblLastMessage", this) as TextBlock;

        private Ellipse elOnlineIndicator => Template.FindName("elOnlineIndicator", this) as Ellipse;

        public ChatView(User user, Chat chat)
        {
            
            User = user;
            Chat = chat;
            MouseDown += ChatView_MouseDown;
            Template = (ControlTemplate)FindResource("ChatViewTemplate");
        }

        private void ChatView_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Add your logic to handle the click event
            // For demonstration, let's just display a message
            MessageBox.Show($"Clicked chat with user: {User.UserName}");
        }

        public override void OnApplyTemplate()
        {
            var otherUser = Chat.Members.Find(curUser => curUser != User);
            imgUser.Source = Chat.GetImage(otherUser);
            lblLastMessage.Text = TrimLastMessage(Chat);
            if (Chat.Members.Count == 2)
            {
                // Show online indicator if there's only one other user in the chat
                bool isOtherUserOnline = CheckIfUserOnline(otherUser);
                elOnlineIndicator.Visibility = isOtherUserOnline ? Visibility.Visible : Visibility.Hidden;
            }
            else
            {
                // Handle chat with multiple users (e.g., group chat)
                // You can implement this as per your requirements
            }
        }

        private string TrimLastMessage(Chat chat)
        {
            string lastMessage = chat.Count() > 0 ? chat.Last().Text : string.Empty;
            if (lastMessage.Length > 25)
            {
                return lastMessage.Substring(0, 22) + "...";
            }
            return lastMessage;
        }

        private bool CheckIfUserOnline(User user)
        {
            // Check if the user is online based on the IsOnline property
            return user.IsOnline;
        }

    }

}
