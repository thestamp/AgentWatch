using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;
using Watch.Face.Common;

using Watch.Face.Scroll.Properties;

namespace Watch.Face.Scroll.WatchFace
{
    class WatchFaceScroll:WatchFaceBase
    {
       
        public override void DrawWatchFace()
        {
            base.ClearWatchFace();
   
            var largeFont = Resources.GetFont(Resources.FontResources.OldEnglish16);
            var smallFont = Resources.GetFont(Resources.FontResources.OldEnglish09);
            var tinyFont = Resources.GetFont(Resources.FontResources.OldEnglish10);
            var currentTime = DateTime.Now.ToLocalTime();

            bitmap.DrawImage(0, 0, new Bitmap(Resources.GetBytes(Resources.BinaryResources.scroll), Bitmap.BitmapImageType.Gif), 0, 0, 128, 128);
            bitmap.DrawText("Hear Ye,", largeFont, Color.Black, 35, 18);
            bitmap.DrawText("Hear Ye.", largeFont, Color.Black, 28, 38);

            bitmap.DrawText("The time is", smallFont, Color.Black, 35, 61);

            bitmap.DrawText(currentTime.ToString("h:mm"), largeFont, Color.Black, 39, 70);

            bitmap.DrawText("In the year of", tinyFont, Color.Black, 15, 90);
            bitmap.DrawText("our Lord", tinyFont, Color.Black, 42, 103);

 	         base.DrawWatchFace();
        }
    }
}
