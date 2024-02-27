using HandShaker.UserLib.Chats;
using HandShaker.UserLib.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using static HandShaker.Assets.IconResources.Icons;
using static HandShaker.Assets.ColorResources.Colors;
using HandShaker.UserLib.Messages;

namespace HandShaker.Assets.UniversalElements
{
    public class ChatMenuItem : MenuItem
    {
        Chat _chat;
        User _user;

        private Image UserPhotoImage => (Image)Template.FindName("UserPhotoImage", this);

        private Ellipse UserOnlineImage => (Ellipse)Template.FindName("UserOnlineImage", this);

        private TextBlock TxtBoxChatName => (TextBlock)Template.FindName("TxtBoxChatName", this);

        private TextBlock TxtBlockLastMessage => (TextBlock)Template.FindName("TxtBlockLastMessage", this);

        private Label ImgReadStatus => (Label)Template.FindName("ImgReadStatus", this);

        private TextBlock TxtBlockLastTime => (TextBlock)Template.FindName("TxtBlockLastTime", this);

        private Border Border => (Border)Template.FindName("Border", this);

        public ChatMenuItem(User user, Chat chat)
        {
            _user = user;
            _chat = chat;
            Template = (ControlTemplate)FindResource("ChatItemTemplate");

            MouseEnter += ChatMenuItem_MouseEnter;
            MouseLeave += ChatMenuItem_MouseLeave;
        }

        private void ChatMenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border.BorderBrush = BorderGray;
            Border.Background = LightGrayFilling;
            TxtBoxChatName.Foreground = Black;
            TxtBlockLastMessage.Foreground = DarkGray;
            TxtBlockLastTime.Foreground = DarkGray;
            ImgReadStatus.Foreground = DarkGreen;
            UserOnlineImage.Fill = LightGreen;
        }

        private void ChatMenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border.BorderBrush = DarkGray;
            Border.Background = DarkGray;
            TxtBoxChatName.Foreground = LightGrayFilling;
            TxtBlockLastMessage.Foreground = LightGrayFilling;
            TxtBlockLastTime.Foreground = LightGrayFilling;
            ImgReadStatus.Foreground = LightGrayFilling;
            UserOnlineImage.Fill = LightGrayFilling;
        }

        public override void OnApplyTemplate()
        {
            UserPhotoImage.Source = _chat.GetImage(_user);

            var chatName = _chat.GetName(_user);

            var shortChatName = (chatName.Length <= 24) ? chatName : (chatName.Substring(0, 21) + "...");
            
            TxtBoxChatName.Text = shortChatName;

            var lastMessage = _chat.LastOrDefault();

            if (lastMessage != null)
            {
                var text = lastMessage.Text;

                var shortText = (text.Length <= 33) ? text : (text.Substring(0,30) + "...");

                TxtBlockLastMessage.Text = shortText;
            }

            if (lastMessage.Status == ReadStatus.Sent)
            {
                ImgReadStatus.Visibility = Visibility.Hidden;
            }
            else
            {
                ImgReadStatus.Visibility = Visibility.Visible;

                if (lastMessage.Status == ReadStatus.Received)
                {
                    ImgReadStatus.Content = Tick;
                }
                else
                {
                    ImgReadStatus.Content = DoubleTick;
                }
            }

            if (!(_chat is ChatForTwo))
            {
                return;
            }

            var thisChatForTwo = ((ChatForTwo)_chat);
            var otherUser = thisChatForTwo.GetOtherUser(_user);

            if (otherUser.IsOnline)
            {
                UserOnlineImage.Visibility = Visibility.Visible;
            }
            else
            {
                var lastSeen = _user.LastSeen;
                var timeSinceLastSeen = DateTime.Now - lastSeen;

                var timeText = string.Empty;
                /*
                if (timeSinceLastSeen.Hours < 24)
                {
                    timeText = lastSeen.ToString("hh:mm");
                }
                else if (timeSinceLastSeen.Days < 365)
                {
                    timeText = lastSeen.ToString("dd MMM");
                }
                else
                {
                    timeText = lastSeen.ToString("dd MMM yyyy");
                }
                */

                TxtBlockLastTime.Text = timeText;
            }
            
        }
    }
}
