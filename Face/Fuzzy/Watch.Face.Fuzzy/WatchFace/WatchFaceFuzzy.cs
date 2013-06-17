using System;
using Microsoft.SPOT.Presentation.Media;
using Watch.Face.Common;

namespace Watch.Face.Fuzzy.WatchFace
{
    class WatchFaceFuzzy:WatchFaceBase
    {

        private string GetRandomSmall(bool before)
        {
           
            if (before)
            {
                switch (new Random(DateTime.Now.Millisecond).Next(4))
                {
                    case 0:
                        return "just before";
                    case 1:
                        return "a little before";
                    case 2:
                        return "a bit before";
                    case 3:
                        return "almost";
                    default:
                        return "easing into";
                }

            }
            else
            {
                switch (new Random(DateTime.Now.Millisecond).Next(2))
                {
                    case 0:
                        return "just after";
                    case 1:
                        return "a little after";
                    default:
                        return "a pinch after";
                }
            }
        
        }

        private string GetTen(bool before)
        {
            return before ? "ten to": "ten after";
        }

        private string GetHalfPast()
        {
            return "half past";
        }

        private string GetHour(DateTime time)
        {
            switch (time.Hour)
            {
                case 0:
                    return "midnight";
                case 1:
                case 13:
                    return "one";
                case 2:
                case 14:
                    return "two";
                case 3:
                case 15:
                    return "three";
                case 4:
                case 16:
                    return "four";
                case 5:
                case 17:
                    return "five";
                case 6:
                case 18:
                    return "six";
                case 7:
                case 19:
                    return "seven";
                case 8:
                case 20:
                    return "eight";
                case 9:
                case 21:
                    return "nine";
                case 10:
                case 22:
                    return "ten";
                case 11:
                case 23:
                    return "eleven";
                case 12:
                default:
                    return "noon";
            }
          
        }


        private string[] GetFuzzyText(DateTime time)
        {
            time = time.AddMinutes(17);
            var minuteStart = "";
            var minuteMiddle = "";
            var minuteEnd = "";

            if (time.Minute < 4)
                minuteEnd = "o'clock";
            if (time.Minute < 9)
            {
                minuteMiddle = GetRandomSmall(false);
                minuteEnd = "o'clock";
            }
            else if (time.Minute < 13)
                minuteMiddle = GetTen(false);
            else if (time.Minute < 20)
                minuteMiddle = "quarter past";
            else if (time.Minute < 27)
            {
                minuteStart = GetRandomSmall(true);
                minuteMiddle = GetHalfPast();
            }
            else if (time.Minute < 34)
                minuteMiddle = GetHalfPast();
            else if (time.Minute < 41)
            {
                minuteStart = GetRandomSmall(false);
                minuteMiddle = GetHalfPast();
            }
            else
            {
                if (time.Minute < 48)
                    minuteMiddle = "quarter to";
                else if (time.Minute < 53)
                    minuteMiddle = GetTen(true);
                else if (time.Minute < 57)
                {
                    minuteMiddle = GetRandomSmall(true);
                    minuteEnd = "o'clock";
                }
                else
                    minuteEnd = "o'clock";

                time = time.AddHours(1);
            }

            string hour = GetHour(time);

            //return new string[4] { "a little before", "two", "three", "four" };
            return new[]{minuteStart, minuteMiddle, hour, minuteEnd};
        }



        public override void DrawWatchFace()
        {
            base.ClearWatchFace();
   
            var minuteFont = Resources.GetFont(Resources.FontResources.SegoeUi16);
            var hourFont = Resources.GetFont(Resources.FontResources.SegoeUi20);
            var currentTime = DateTime.Now.ToLocalTime();
            var strings = GetFuzzyText(currentTime);

            const int yOffset = 5;
            const int xOffset = 2;

            bitmap.DrawText(strings[0], minuteFont, Color.White, xOffset, 0 + yOffset);
            bitmap.DrawText(strings[1], minuteFont, Color.White, xOffset, 25 + yOffset);
            bitmap.DrawText(strings[2], hourFont, Color.White, xOffset, 47 + yOffset);
            bitmap.DrawText(strings[3], minuteFont, Color.White, xOffset, 79 + yOffset);

 	        base.DrawWatchFace();
        }
    }
}
