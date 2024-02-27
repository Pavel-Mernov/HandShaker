using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HandShaker.Assets.IconResources
{
    public class Icons : FrameworkElement
    {
        private Icons() { }

        private static Icons _instance = new Icons();

        public static PathGeometry Close => (PathGeometry)_instance.FindResource("close");

        public static PathGeometry Minimize => (PathGeometry)_instance.FindResource("minimize");

        public static PathGeometry Maximize => (PathGeometry)_instance.FindResource("maximize");

        public static PathGeometry Tick => (PathGeometry)_instance.FindResource("tick");

        public static PathGeometry DoubleTick => (PathGeometry)_instance.FindResource("doubletick");

        public static PathGeometry Search => (PathGeometry)_instance.FindResource("search");
    }
}
