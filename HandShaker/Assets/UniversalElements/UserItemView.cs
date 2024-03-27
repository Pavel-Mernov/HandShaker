using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HandShaker.Assets.UniversalElements
{

    public class UserItemView : ContentControl
    {
        private readonly User _user;
        private Image _userImage;
        private TextBlock _userNameText;

        public UserItemView(User user)
        {
            _user = user;
            Style = FindResource("UserItemViewStyle") as Style;
        }

        public UserItemView(User user, Action clickedAction) : this(user)
        {
            MouseDown += (sender, e) => clickedAction?.Invoke();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _userImage = Template.FindName("UserImage", this) as Image;
            _userNameText = Template.FindName("UserNameText", this) as TextBlock;
            if (_userImage != null)
                _userImage.Source = _user.ImageSource;
            if (_userNameText != null)
                _userNameText.Text = _user.UserName;
        }
    }

}
