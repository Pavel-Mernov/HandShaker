using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HandShaker.Assets.ColorResources
{
    internal class Colors : FrameworkElement
    {
        // we need an instance to find resource
        private static readonly Colors _instance = new Colors();

        public static readonly Brush BorderGray = (Brush)_instance.FindResource("BorderGray");

        public static readonly Brush BlankFilling = (Brush)_instance.FindResource("BlankFilling");

        public static readonly Brush LightGrayFilling = (Brush)_instance.FindResource("LightGrayFilling");

        public static readonly Brush DarkGray = (Brush)_instance.FindResource("DarkGray");

        public static readonly Brush ButtonBlue = (Brush)_instance.FindResource("ButtonBlue");

        public static readonly Brush ButtonLightBlue = (Brush)_instance.FindResource("ButtonLightBlue");

        public static readonly Brush ClosingButtonRed = (Brush)_instance.FindResource("ClosingButtonRed");

        public static readonly Brush DarkGreen = (Brush)_instance.FindResource("DarkGreen");

        public static readonly Brush LightGreen = (Brush)_instance.FindResource("LightGreen");

        public static readonly Brush Black = new SolidColorBrush(Color.FromRgb(0, 0, 0));

        public static readonly Brush White = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xff));

        public static readonly Brush Transparent = new SolidColorBrush(Color.FromArgb(0x0, 0xff, 0xff, 0xff));
    }
}
