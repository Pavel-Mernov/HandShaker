using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace HandShaker.Assets.UniversalElements
{
    public class ChatPanel : ContentControl
    {
        public User User { get; }
        public Chat Chat { get; }

        private Image imgChat => Template.FindName("imgChat", this) as Image;

        private TextBlock txtChatName => Template.FindName("txtChatName", this) as TextBlock;

        private Ellipse elOnlineIndicator => Template.FindName("elOnlineIndicator", this) as Ellipse;

        private StackPanel itemsPanel => Template.FindName("itemsPanel", this) as StackPanel;

        public ChatPanel(User user, Chat chat)
        {
            User = user;
            Chat = chat;
            Style = (Style)FindResource("ChatPanelStyle"); 
            
        }

        public override void OnApplyTemplate()
        {
            // Check if there are only 2 members in the chat
            if (Chat.Members.Count == 2)
            {
                var otherUser = Chat.Members.Find(curUser => curUser != User);
                // Set chat image
                imgChat.Source = Chat.GetImage(otherUser);
                // Set chat name
                txtChatName.Text = Chat.GetName(otherUser);
                // Check if the other user is online and show the online indicator
                bool isOtherUserOnline = otherUser.IsOnline;
                elOnlineIndicator.Visibility = isOtherUserOnline ? Visibility.Visible : Visibility.Collapsed;


                // Set up IconButton for call
                var btnCall = new IconButton
                {
                    Content = FindResource("call")
                };
                btnCall.Click += BtnCall_Click;
                // Add IconButton to the panel
                itemsPanel.Children.Add(btnCall);
            }
        }

        private void BtnCall_Click(object sender, RoutedEventArgs e)
        {
            // Handle the call button click event
        }
    }
}
