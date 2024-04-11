using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;

using static HandShaker.Assets.ColorResources.Colors;
using System.Xml;

namespace HandShaker.Assets.UniversalElements
{
    public partial class ChatView : Control
    {
        public User User { get; }
        public Chat Chat { get; }

        private Action _onClick;

        private Image imgUser => Template.FindName("imgUser", this) as Image;
        private TextBlock lblLastMessage => Template.FindName("lblLastMessage", this) as TextBlock;

        private Ellipse elOnlineIndicator => Template.FindName("elOnlineIndicator", this) as Ellipse;

        private TextBlock txtChatName => Template.FindName("txtChatName", this) as TextBlock;

        private Border mainBorder => Template.FindName("mainBorder", this) as Border;

        public ChatView(User user, Chat chat, Action onClick)
        {
            _onClick = onClick;
            User = user;
            Chat = chat;
            MouseDown += ChatView_MouseDown;
            Template = (ControlTemplate)FindResource("ChatViewTemplate");
            MouseEnter += ChatView_MouseEnter;
            MouseLeave += ChatView_MouseLeave;
        }

        private void ChatView_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mainBorder.Background = Transparent;
            lblLastMessage.Foreground = DarkGray;
        }

        private void ChatView_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mainBorder.Background = LightGrayFilling;
            lblLastMessage.Foreground = Black;
        }

        private void ChatView_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _onClick();
        }

        public override void OnApplyTemplate()
        {
            var otherUser = Chat.Members.Find(curUser => curUser != User);
            imgUser.Source = Chat.GetImage(User);
            lblLastMessage.Text = TrimLastMessage(Chat);
            txtChatName.Text = Chat.GetName(User);

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
                elOnlineIndicator.Visibility = Visibility.Hidden;
            }
        }

        private string TrimLastMessage(Chat chat)
        {
            string lastMessage = chat.Count() > 0 ? chat.Last().Text : string.Empty;
            if (lastMessage.Length > 35)
            {
                return lastMessage.Substring(0, 32) + "...";
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
