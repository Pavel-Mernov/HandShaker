using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static HandShaker.Assets.ColorResources.Colors;

namespace HandShaker.Assets.UniversalElements
{
    public class MessageView : Control
    {
        private User _user;

        private Message _message;

        private Border mainBorder => Template.FindName("mainBorder", this) as Border;

        private TextBlock tbMessage => Template.FindName("tbMessage", this) as TextBlock;

        public MessageView(User user, Message message)
        {
            _user = user;
            _message = message;
            Template = FindResource("MessageViewTemplate") as ControlTemplate;
        }

        public override void OnApplyTemplate()
        {
            var messageTextBuilder = new StringBuilder();
            var curLineBuilder = new StringBuilder();

            var messageTextSplit = _message.Text.Split(' ', '\n');

            var maxCharCount = 70;

            for (int i = 0; i < messageTextSplit.Length; i++)
            {
                var curWord = messageTextSplit[i];

                if (curWord.Length > maxCharCount && curLineBuilder.ToString().Length > 0) 
                { 
                    messageTextBuilder.AppendLine(curLineBuilder.ToString());
                    curLineBuilder.Clear();
                }
                while (curWord.Length > maxCharCount)
                {
                    messageTextBuilder.AppendLine(curWord.Substring(0, maxCharCount));
                    curWord = curWord.Substring(maxCharCount);
                }
                if (curLineBuilder.ToString().Length + 1 + curWord.Length > maxCharCount)
                {
                    messageTextBuilder.AppendLine(curLineBuilder.ToString());
                    curLineBuilder.Clear();
                }
                curLineBuilder.Append(curWord + ' ');
            }
            messageTextBuilder.AppendLine(curLineBuilder.ToString());

            tbMessage.Text = messageTextBuilder.ToString();

            if (_message.From == _user)
            {
                mainBorder.Background = LightGrayFilling;
                mainBorder.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                mainBorder.Background = MessageViewLightBlue;
                mainBorder.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }
    }
}
