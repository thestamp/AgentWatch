using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using System.Threading;
using Microsoft.SPOT.Presentation.Shapes;
using Watch.Face.Common;
using Watch.Face.Scroll.WatchFace;

namespace Watch.Face.Scroll
{
    public class Program
    {

        // set the following to true for 24-hour time (00-23 instead of 1-12)
        // set the following to true to outline screen in emulator
        

        static Timer _updateClockTimer;

        static object _updateTimeLock = new object();

        static DateTime _startTime = new DateTime(2013, 01, 01, 09, 00, 00);
        private static WatchFaceBase watchFace;
        public static void Main()
        {
     

            // optionally set time; comment out the following line to use the current system time
            //Microsoft.SPOT.Hardware.Utility.SetLocalTime(_startTime);
           
            // display the time immediately
            UpdateTime(null);

            // set up timer to refresh time every minute
            var currentTime = DateTime.Now;
            var dueTime = new TimeSpan(0, 0, 0, 59 - currentTime.Second, 1000 - currentTime.Millisecond); // beginning of next minute
            var period = new TimeSpan(0, 0, 1, 0, 0); // update time every minute
            _updateClockTimer = new Timer(UpdateTime, null, dueTime, period); // start our minute timer

            // go to sleep; time updates will happen automatically every minute
            Thread.Sleep(Timeout.Infinite);
        }

        static void UpdateTime(object state)
        {

            watchFace = new WatchFaceScroll();
            watchFace.DrawWatchFace();
           
        }

    /*static Bitmap GetDigit(int digitNumber)
        {
            switch (digitNumber)
            {
                case 0:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._0), Bitmap.BitmapImageType.Gif);
                case 1:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._1), Bitmap.BitmapImageType.Gif);
                case 2:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._2), Bitmap.BitmapImageType.Gif);
                case 3:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._3), Bitmap.BitmapImageType.Gif);
                case 4:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._4), Bitmap.BitmapImageType.Gif);
                case 5:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._5), Bitmap.BitmapImageType.Gif);
                case 6:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._6), Bitmap.BitmapImageType.Gif);
                case 7:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._7), Bitmap.BitmapImageType.Gif);
                case 8:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._8), Bitmap.BitmapImageType.Gif);
                case 9:
                    return new Bitmap(Resources.GetBytes(Resources.BinaryResources._9), Bitmap.BitmapImageType.Gif);
                default:
                    return null;
            }
        }*/
    }
}
