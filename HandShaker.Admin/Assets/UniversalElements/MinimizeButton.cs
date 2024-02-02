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
    internal class MinimizeButton : IconButton
    {
        public MinimizeButton()
        {
            MouseEnter += MinimizeButton_MouseEnter;
            Click += MinimizeButton_Click;

            Content = FindResource("minimize");

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
            Background = (Brush)FindResource("DarkGray");
            Foreground = (Brush)FindResource("BlankFilling");
        }
    }
}
