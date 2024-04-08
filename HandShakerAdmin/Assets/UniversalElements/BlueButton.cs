using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using HandShakerAdmin.Assets.ColorResources;

namespace HandShakerAdmin.Assets.UniversalElements
{
    public class BlueButton : Button
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
