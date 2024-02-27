using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static HandShaker.Assets.IconResources.Icons;

namespace HandShaker.Assets.UniversalElements
{
    internal class MinimizeButton : IconButton
    {
        public MinimizeButton()
        {
            MouseEnter += MinimizeButton_MouseEnter;
            Click += MinimizeButton_Click;

            Content = Minimize;

            // Template = CreateTemplate();
        }

        private void MinimizeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Window.WindowState != WindowState.Minimized)
            {
                Window.WindowState = WindowState.Minimized;
            }
            
        }

        private void MinimizeButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = ColorResources.Colors.DarkGray;
            Foreground = ColorResources.Colors.BlankFilling;
        }
    }
}
