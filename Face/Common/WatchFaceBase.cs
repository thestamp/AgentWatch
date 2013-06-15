using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace Watch.Face.Common
{
    public class WatchFaceBase
    {
        const int SCREEN_WIDTH = 128;
        const int SCREEN_HEIGHT = 128;
        const bool DISPLAY_BORDER_BOX = true;

        protected Bitmap bitmap = new Bitmap(Bitmap.MaxWidth, Bitmap.MaxHeight);

        public void ClearWatchFace()
        {
            bitmap.Clear();
        }

        public virtual void DrawWatchFace()
        {
            if (DISPLAY_BORDER_BOX)
            {
                bitmap.DrawRectangle(Color.White, 1, 0, 0, SCREEN_WIDTH, SCREEN_HEIGHT, 0, 0, Color.White, 0, 0, Color.White, 0, 0, 0);
            }
            bitmap.Flush();
        }
    }
}
