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
        public UInt16[,] Clip    { get; private set; }
        public float [,] Changed { get; private set; }

        public HistoryRecord(HeightMap HMap, int left, int top, int right, int bottom, bool resizeAction = false)
        {
            int x, y;
            Left = left;   Right  = right;
            Top  = top;    Bottom = bottom;
            Width  = Right  - Left + 1;
            Height = Bottom - Top  + 1;
            ResizeAction = resizeAction;
            Clip    = HMap.Levels.Clone() as ushort[,];
            Changed = HMap.Changed.Clone() as float[,];
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
            UInt16[,] newClip    = new UInt16[Width, Height];
            float [,] newChanged = new float [Width, Height];
            for (int y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                {
                    newClip[x, y]    = Clip   [x + Left, y + Top];
                    newChanged[x, y] = Changed[x + Left, y + Top];
                }
            Clip    = newClip;
            Changed = newChanged;
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
                UInt16[,] oldClip;
                float[,]  oldChanged;
                HMap.SwapClips(Width, Height, Clip, Changed, out oldClip, out oldChanged);
                Clip    = oldClip;
                Changed = oldChanged;
                // Update sizes
                Width  = Right  - Left + 1;
                Height = Bottom - Top  + 1;
            }
            // Edit back
            else
            {
                int x, y;
                UInt16 v;
                float f;
                for (y = 0; y < Height; y++)
                    for (x = 0; x < Width; x++)
                    {
                        v = HMap.Levels [x + Left, y + Top];
                        f = HMap.Changed[x + Left, y + Top];
                        HMap.Levels [x + Left, y + Top] = Clip   [x, y];
                        HMap.Changed[x + Left, y + Top] = Changed[x, y];
                        Clip   [x, y] = v;
                        Changed[x, y] = f;
                    }
            }
        }
    }
}
