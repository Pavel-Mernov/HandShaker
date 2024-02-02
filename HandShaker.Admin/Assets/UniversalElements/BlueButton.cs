using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace HandShaker.Admin.Assets.UniversalElements
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
            border.Background = (Brush)FindResource("ButtonBlue");
            border.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void BlueButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var border = (Border)Template.FindName("Border", this);
            border.Background = (Brush)FindResource("ButtonLightBlue");
            border.BorderBrush = (Brush)FindResource("DarkGray");
        }
    }
}
