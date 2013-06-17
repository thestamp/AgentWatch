using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Watch.Face.Common;
using Watch.Face.Fuzzy.WatchFace;

namespace Watch.Face.Fuzzy
{
    public class Program : Microsoft.SPOT.Application
    {


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

            watchFace = new WatchFaceFuzzy();
            watchFace.DrawWatchFace();

        }

    }
}
