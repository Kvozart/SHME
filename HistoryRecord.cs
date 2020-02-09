using System;

namespace SHME
{
    class HistoryRecord
    {
        public static byte ActionEdit   = 1;
        public static byte ActionResize = 2;

        public byte Action;
        public int Left, Top, Right, Bottom, Width, Height;
        UInt16[,] Clip;

        public HistoryRecord(HeightMap HMap, int left, int top, int right, int bottom)
        {
            int x;
            Left = left;   Right  = right;
            Top  = top;    Bottom = bottom;
            Width  = Right  - Left + 1;
            Height = Bottom - Top  + 1;
            Clip = new UInt16[HMap.Width, HMap.Height];
            for (int y = 0; y < HMap.Height; y++)
                for (x = 0; x < HMap.Width; x++)
                    Clip[x, y] = HMap.Level[x, y];
        }

        public void Check(int left, int top, int right, int bottom)
        {
            if (left < Left) Left = left;
            if (top  < Top ) Top  = top;
            if (Right  < right ) Right  = right;
            if (Bottom < bottom) Bottom = bottom;
        }

        public void Finish(byte action, bool fullMap = false)
        {
            int x;
            Width  = Right  - Left + 1;
            Height = Bottom - Top  + 1;
            Action = action;
            if (fullMap) return;
            UInt16[,] buffer = Clip;
            Clip = new UInt16[Width, Height];
            for (int y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                    Clip[x, y] = buffer[x + Left, y + Top];
        }

        public void Rollback(ref HeightMap HMap)
        {
            int x;
            UInt16[,] buffer = Clip;
            // Edit back
            if (Action == ActionEdit)
            {
                Clip = new UInt16[Width, Height];
                for (int y = 0; y < Height; y++)
                    for (x = 0; x < Width; x++)
                    {
                        Clip[x, y] = HMap.Level[x + Left, y + Top];
                        HMap.Level[x + Left, y + Top] = buffer[x, y];
                    }
            }
            else if (Action == ActionResize)
            {
                // Remember corner
                Right  = HMap.Width  - 1;
                Bottom = HMap.Height - 1;
                // Switch arrays
                Clip = HMap.SetLevelMap(Width, Height, buffer);
                // Update sizes
                Width  = Right  - Left + 1;
                Height = Bottom - Top  + 1;
            }
        }
    }
}
