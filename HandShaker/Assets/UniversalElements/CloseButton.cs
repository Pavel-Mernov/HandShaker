using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HandShaker.Assets.UniversalElements
{
    internal class CloseButton : IconButton
    {
        public CloseButton()
        {
            Content = FindResource("close");

            Click += onClick;
            MouseEnter += onMouseEnter;

            // Template = CreateTemplate();
        }

        private void onClick(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }

        private void onMouseEnter(object sender, MouseEventArgs args)
        {
            Background = ColorResources.Colors.ClosingButtonRed;
            Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
