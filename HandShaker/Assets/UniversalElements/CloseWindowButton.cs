using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static HandShaker.Assets.IconResources.Icons;

namespace HandShaker.Assets.UniversalElements
{
    internal class CloseWindowButton : IconButton
    {
        public CloseWindowButton()
        {
            Content = Close;

            Click += CloseWindowButton_Click;
            MouseEnter += CloseWindowButton_MouseEnter;
        }

        private void CloseWindowButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = ColorResources.Colors.ClosingButtonRed;
            Foreground = new SolidColorBrush(Colors.White);
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window.Hide();
        }
    }
}
