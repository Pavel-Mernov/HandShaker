using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HandShakerAdmin.Assets.UniversalElements
{
    public class IconButton : Button
    {
        public IconButton()
        {
            Style = (Style)FindResource("IconButtonStyle");

            MouseLeave += IconButton_MouseLeave;
        }

        private void IconButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Background = new SolidColorBrush(Colors.Transparent);
            Foreground = new SolidColorBrush(Colors.Black);
        }

        public Window Window
        {
            get { return (Window)GetValue(WindowProperty); }
            set { SetValue(WindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Window.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.Register("Window", typeof(Window), typeof(IconButton), null);
    }
}
