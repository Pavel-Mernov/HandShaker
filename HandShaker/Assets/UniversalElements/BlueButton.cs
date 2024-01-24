using HandShaker.Assets.ColorResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HandShaker.Assets.UniversalElements
{
    internal class BlueButton : Button
    {
        public BlueButton()
        {
            Style = (Style)FindResource("BlueButtonStyle");

            MouseEnter += BlueButton_MouseEnter;
            MouseLeave += BlueButton_MouseLeave;
        }

        private void BlueButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var border = (Border)Template.FindName("Border", this);
            border.Background = Colors.ButtonBlue;
            border.BorderBrush = Colors.Black;
        }

        private void BlueButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var border = (Border)Template.FindName("Border", this);
            border.Background = Colors.ButtonLightBlue;
            border.BorderBrush = Colors.DarkGray;
        }
    }
}
