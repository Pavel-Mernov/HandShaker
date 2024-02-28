using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static HandShaker.Assets.IconResources.Icons;

namespace HandShaker.UserLib.Messages
{
    public enum ReadStatus
    {
        Sent,
        Received,
        Seen,
    }

    static class ReadStatusExtensions
    {
        public static PathGeometry GetIcon(this ReadStatus status)
        {
            switch (status)
            {
                case ReadStatus.Received:
                    return Tick;
                case ReadStatus.Seen:
                    return DoubleTick;
                default: 
                    return null;
            }
        }

        public static Visibility GetVisibility(this ReadStatus status)
        {
            switch (status)
            {
                case ReadStatus.Seen:
                case ReadStatus.Received:
                    return Visibility.Visible;
                default:
                    return Visibility.Hidden;
            }
        }
    }
}
