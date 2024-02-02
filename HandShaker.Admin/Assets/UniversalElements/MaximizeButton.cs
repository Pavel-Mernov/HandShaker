using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HandShaker.Admin.Assets.UniversalElements
{
    internal class MaximizeButton : IconButton
    {
        public MaximizeButton()
        {
            Content = FindResource("maximize");

            Click += MaximizeButton_Click;
            MouseEnter += MaximizeButton_MouseEnter;

            // Template = CreateTemplate();
        }

        private void MaximizeButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = (Brush)FindResource("DarkGray");
            Foreground = (Brush)FindResource("BlankFilling");
        }



        private void MaximizeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Window.WindowState == WindowState.Normal)
            {
                Window.WindowState = WindowState.Maximized;
            }
            else
            {
                Window.WindowState = WindowState.Normal;
            }
        }
    }
}
