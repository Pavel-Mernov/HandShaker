using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static HandShaker.Assets.IconResources.Icons;

namespace HandShaker.Assets.UniversalElements
{
    internal class MaximizeButton : IconButton
    {
        public MaximizeButton()
        {
            Content = Maximize;

            Click += MaximizeButton_Click;
            MouseEnter += MaximizeButton_MouseEnter;

            // Template = CreateTemplate();
        }

        private void MaximizeButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = ColorResources.Colors.DarkGray;
            Foreground = ColorResources.Colors.BlankFilling;
        }



        private void MaximizeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Maximized;
        }


    }
}
