﻿using HandShaker.UserLib;
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
    public class MessageInputBox : ContentControl
    {
        private User _user;
        private Chat _chat;

        private Border mainBorder => Template.FindName("mainBorder", this) as Border;

        private Button btnAttach => Template.FindName("btnAttach", this) as Button;

        private TextBox inputMessageTextBox => Template.FindName("inputMessageTextBox", this) as TextBox;

        private Label lblPlaceholder => Template.FindName("lblPlaceholder", this) as Label;

        private StackPanel inputPanel => Template.FindName("inputPanel", this) as StackPanel;

        public MessageInputBox(User user, Chat chat)
        {
            _user = user;
            _chat = chat;
            Template = FindResource("MessageInputBoxTemplate") as ControlTemplate;
        }

        public override void OnApplyTemplate()
        {
            btnAttach.MouseEnter += BtnAttach_MouseEnter;
            btnAttach.MouseLeave += BtnAttach_MouseLeave;

            mainBorder.MouseDown += MainBorder_MouseDown;

            inputMessageTextBox.TextChanged += InputMessageTextBox_TextChanged;

            // inputPanel.Width = mainBorder.ActualWidth;
            // inputMessageTextBox.MaxWidth = inputPanel.Width;
        }

        private void InputMessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputMessageTextBox.Text))
            {
                lblPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                lblPlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void MainBorder_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            inputMessageTextBox.Focus();
        }

        private void BtnAttach_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnAttach.Foreground = DarkGray;
        }

        private void BtnAttach_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnAttach.Foreground = BorderGray;
        }
    }
}