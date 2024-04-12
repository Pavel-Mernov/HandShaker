using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows;

namespace HandShaker.Assets.UniversalElements
{
    public class MessagesListView : Control
    {
        private readonly User _user;
        private readonly Chat _chat;

        public MessagesListView(User user, Chat chat)
        {
            _user = user;
            _chat = chat;

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            VerticalContentAlignment = VerticalAlignment.Bottom;
            Height = SystemParameters.PrimaryScreenHeight - 300;
            Template = FindResource("MessagesViewTemplate") as ControlTemplate;
        }

        public override void OnApplyTemplate()
        {
            var scrollViewer = Template.FindName("scrollViewer", this) as ScrollViewer;
            scrollViewer.Height = this.Height;

            var messagesPanel = Template.FindName("messagesPanel", this) as StackPanel;

            foreach (var message in _chat)
            {
                messagesPanel.Children.Add(new MessageView(_user, message));
            }
        }
    }
}
