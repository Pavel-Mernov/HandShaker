﻿using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static HandShaker.Assets.ColorResources.Colors;

namespace HandShaker.Assets.UniversalElements
{
	public class UserMenuItem : MenuItem
	{
		public User User { get; private set; }

		private Image AvatarImage => (Image)Template.FindName("AvatarImage", this);

		private TextBlock TxtBlockName => (TextBlock)Template.FindName("TxtBlockName", this);

		private Border UserItemBorder => (Border)Template.FindName("UserItemBorder", this);

		public UserMenuItem(User user)
		{
			this.User = user;
			Template = (ControlTemplate)FindResource("UserMenuItemTemplate");

            MouseEnter += UserMenuItem_MouseEnter;
            MouseLeave += UserMenuItem_MouseLeave;

            Click += UserMenuItem_Click;
		}

        private void UserMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void UserMenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (UserItemBorder != null)
            {
                UserItemBorder.BorderBrush = BorderGray;
                UserItemBorder.Background = White;
            }

            if (TxtBlockName != null)
            {
                TxtBlockName.Foreground = BorderGray;
            }
        }

        private void UserMenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (UserItemBorder != null)
			{
				UserItemBorder.BorderBrush = Black;
				UserItemBorder.Background = LightGrayFilling;
			}

			if (TxtBlockName != null)
			{
				TxtBlockName.Foreground = Black;
			}
        }



        public override void OnApplyTemplate()
		{
			AvatarImage.Source = User.ImageSource;

			var localName = string.Empty;
			if (User.UserName.Length > 17)
			{
				localName = User.UserName.Substring(0, 17);
			}
			else
			{
				localName = User.UserName;
			}

			TxtBlockName.Text = localName;
		}
	}
}
