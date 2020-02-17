using System;

namespace SHME
{
    class HistoryRecord
    {
        public bool ResizeAction { get; private set; }
        public int Left   { get; private set; }
        public int Top    { get; private set; }
        public int Right  { get; private set; }
        public int Bottom { get; private set; }
        public int Width  { get; private set; }
        public int Height { get; private set; }
        private UInt16[,] Clip;

        public HistoryRecord(HeightMap HMap, int left, int top, int right, int bottom, bool resizeAction = false)
        {
            int x, y;
            Left = left;   Right  = right;
            Top  = top;    Bottom = bottom;
            Width  = Right  - Left + 1;
            Height = Bottom - Top  + 1;
            ResizeAction = resizeAction;
            Clip = new UInt16[HMap.Width, HMap.Height];
            for (y = 0; y < HMap.Height; y++)
                for (x = 0; x < HMap.Width; x++)
                    Clip[x, y] = HMap.Levels[x, y];
        }

        public void Check(int left, int top, int right, int bottom)
        {
            if (left < Left) Left = left;
            if (top  < Top ) Top  = top;
            if (Right  < right ) Right  = right;
            if (Bottom < bottom) Bottom = bottom;
        }

        public void Crop()
        {
            int x;
            Width  = Right  - Left + 1;
            Height = Bottom - Top  + 1;
            UInt16[,] newClip = new UInt16[Width, Height];
            for (int y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                    newClip[x, y] = Clip[x + Left, y + Top];
            Clip = newClip;
        }

        public void Rollback(HeightMap HMap)
        {
            // Swap back
            if (ResizeAction)
            {
                // Remember corner
                Right  = HMap.Width  - 1;
                Bottom = HMap.Height - 1;
                // Switch arrays
                Clip = HMap.SetSize(Width, Height, Clip);
                // Update sizes
                Width  = Right  - Left + 1;
                Height = Bottom - Top  + 1;
            }
            // Edit back
            else
            {
                int x, y;
                UInt16 v;
                for (y = 0; y < Height; y++)
                    for (x = 0; x < Width; x++)
                    {
                        v = HMap.Levels[x + Left, y + Top];
                        HMap.Levels[x + Left, y + Top] = Clip[x, y];
                        Clip[x, y] = v;
                    }
            }
        }
    }
}
