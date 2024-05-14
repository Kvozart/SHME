using System;
using System.Linq;
using System.Drawing;

namespace SHME
{
    public static class ReversBits
    {
        public static int Mirror2(int value) => ((value & 1) << 1) | ((value >> 1) & 1) ;

        public static int Mirror4(int value) => ((value & 1) << 3) | ((value >> 1) & 2) |
                                                ((value & 2) << 1) | ((value >> 3) & 1) ;

        public static byte[] LookUp8 = {
            0x00, 0x80, 0x40, 0xC0, 0x20, 0xA0, 0x60, 0xE0, 0x10, 0x90, 0x50, 0xD0, 0x30, 0xB0, 0x70, 0xF0,
            0x08, 0x88, 0x48, 0xC8, 0x28, 0xA8, 0x68, 0xE8, 0x18, 0x98, 0x58, 0xD8, 0x38, 0xB8, 0x78, 0xF8,
            0x04, 0x84, 0x44, 0xC4, 0x24, 0xA4, 0x64, 0xE4, 0x14, 0x94, 0x54, 0xD4, 0x34, 0xB4, 0x74, 0xF4,
            0x0C, 0x8C, 0x4C, 0xCC, 0x2C, 0xAC, 0x6C, 0xEC, 0x1C, 0x9C, 0x5C, 0xDC, 0x3C, 0xBC, 0x7C, 0xFC,
            0x02, 0x82, 0x42, 0xC2, 0x22, 0xA2, 0x62, 0xE2, 0x12, 0x92, 0x52, 0xD2, 0x32, 0xB2, 0x72, 0xF2,
            0x0A, 0x8A, 0x4A, 0xCA, 0x2A, 0xAA, 0x6A, 0xEA, 0x1A, 0x9A, 0x5A, 0xDA, 0x3A, 0xBA, 0x7A, 0xFA,
            0x06, 0x86, 0x46, 0xC6, 0x26, 0xA6, 0x66, 0xE6, 0x16, 0x96, 0x56, 0xD6, 0x36, 0xB6, 0x76, 0xF6,
            0x0E, 0x8E, 0x4E, 0xCE, 0x2E, 0xAE, 0x6E, 0xEE, 0x1E, 0x9E, 0x5E, 0xDE, 0x3E, 0xBE, 0x7E, 0xFE,
            0x01, 0x81, 0x41, 0xC1, 0x21, 0xA1, 0x61, 0xE1, 0x11, 0x91, 0x51, 0xD1, 0x31, 0xB1, 0x71, 0xF1,
            0x09, 0x89, 0x49, 0xC9, 0x29, 0xA9, 0x69, 0xE9, 0x19, 0x99, 0x59, 0xD9, 0x39, 0xB9, 0x79, 0xF9,
            0x05, 0x85, 0x45, 0xC5, 0x25, 0xA5, 0x65, 0xE5, 0x15, 0x95, 0x55, 0xD5, 0x35, 0xB5, 0x75, 0xF5,
            0x0D, 0x8D, 0x4D, 0xCD, 0x2D, 0xAD, 0x6D, 0xED, 0x1D, 0x9D, 0x5D, 0xDD, 0x3D, 0xBD, 0x7D, 0xFD,
            0x03, 0x83, 0x43, 0xC3, 0x23, 0xA3, 0x63, 0xE3, 0x13, 0x93, 0x53, 0xD3, 0x33, 0xB3, 0x73, 0xF3,
            0x0B, 0x8B, 0x4B, 0xCB, 0x2B, 0xAB, 0x6B, 0xEB, 0x1B, 0x9B, 0x5B, 0xDB, 0x3B, 0xBB, 0x7B, 0xFB,
            0x07, 0x87, 0x47, 0xC7, 0x27, 0xA7, 0x67, 0xE7, 0x17, 0x97, 0x57, 0xD7, 0x37, 0xB7, 0x77, 0xF7,
            0x0F, 0x8F, 0x4F, 0xCF, 0x2F, 0xAF, 0x6F, 0xEF, 0x1F, 0x9F, 0x5F, 0xDF, 0x3F, 0xBF, 0x7F, 0xFF};
    }

    class TopologicalMap
    {
        public const int A = -0x01000000; // 0xFF,00,00,00
        public int[] Pixels { get; private set; } // Color map
        public int   Width  { get; private set; } // = 0;
        public int   Height { get; private set; } // = 0;
        public int   MaxX   { get; private set; } // = 0;
        public int   MaxY   { get; private set; } // = 0;
        public String URL = "";

        public void SetSize(int width, int height)
        {
            Pixels = new int[width * height];
            MaxX = (Width  = width ) - 1;
            MaxY = (Height = height) - 1;
        }
    }

    class HeightMap : TopologicalMap
    {
        public float [,] Changed;
        public UInt16[,] Levels { get; private set; } // Height map
        int[] AvgLevelAtRow; // Row height average
        public int MinLevel { get; private set; }
        public int AvgLevel { get; private set; }
        public int MaxLevel { get; private set; }

        #region Init
        /// <summary>
        /// Replace owned level map with new and recreate statistic arrays
        /// </summary>
        /// <param name="newWidth">New width</param>
        /// <param name="newHeight">New height</param>
        /// <param name="newLevels">New levels array to adopt</param>
        /// <param name="saveData">If copy data from old arrays is needed</param>
        /// <returns>Old levels arrays</returns>
        public void SetSize(int newWidth, int newHeight, bool saveData = false, UInt16[,] newLevels = null, float[,] newChanged = null)
        {
            MinLevel = 65535;
            MaxLevel = 0;
            AvgLevel = 0;
            AvgLevelAtRow = new int[newHeight];
            if (newLevels == null)
            {
                newLevels  = new UInt16[newWidth, newHeight];
                newChanged = new float [newWidth, newHeight];
                if (Levels != null && saveData)
                {
                    int x, w = (Width  < newWidth ) ? Width  : newWidth,
                        y, h = (Height < newHeight) ? Height : newHeight;
                    for (y = 0; y < h; y++)
                        for (x = 0; x < w; x++)
                        {
                            newLevels [x, y] = Levels [x, y];
                            newChanged[x, y] = Changed[x, y];
                        }
                }
            }
            // Swap arrays
            Levels  = newLevels;
            Changed = newChanged;
            base.SetSize(newWidth, newHeight);
        }

        /// <summary>
        /// Replace owned level map with new and recreate statistic arrays
        /// </summary>
        /// <param name="newWidth">New width</param>
        /// <param name="newHeight">New height</param>
        /// <param name="newLevels">New levels array to adopt</param>
        /// <param name="saveData">If copy data from old arrays is needed</param>
        /// <returns>Old levels arrays</returns>
        public void SwapClips(int newWidth, int newHeight, UInt16[,] newLevels, float[,] newChanged, out UInt16[,] oldLevels, out float[,] oldChanged)
        {
            // Swap arrays
            UInt16[,] oLevels  = Levels;
            float[,]  oChanged = Changed;
            SetSize(newWidth, newHeight, false, newLevels, newChanged);
            oldLevels  = oLevels;
            oldChanged = oChanged;
        }

        /// <summary>
        /// Copy map of specified sizes with levels from buffer
        /// </summary>
        /// <param name="buffer">
        /// Byte BigLittle/LittleBig indian array of size of width*height*block
        /// </param>
        /// <param name="buffer">Byte scanline</param>
        /// <param name="bitBlock">Count of bits in data block (Channels * BitDepth)</param>
        /// <param name="loIdx"
        /// >Lower byte offset. Also Big-Little indian flag for BitDepth less 8
        /// </param>
        /// <param name="hiIdx">
        /// Higher byte offset
        /// </param>
        /// <param name="pixelBLIndian">
        /// Big-Little indian pixels in byte flag
        /// </param>
        public void SetLevels(byte[] buffer, int bitBlock = 8, int loIdx = 0, int hiIdx = 1, bool pixelBLIndian = false)
        {
            int x, y = 0, i = 0, pack = 0;
            if (bitBlock < 8)
            {
                int mask;
                bool pixelBLI = (loIdx != 0) ^ pixelBLIndian; // Double invert :(
                if (bitBlock == 4)
                    if (pixelBLI)
                        for (; y < Height; y++)
                            for (x = 0; x < Width;)
                            {
                                pack = (pixelBLIndian) ? buffer[i++] : ReversBits.LookUp8[buffer[i++]];
                                                                         mask = ((pack & 1) << 3) | ((pack & 2) << 1) | ((pack >> 1) & 2) | ((pack >> 3) & 1);    Levels[x++, y] = (UInt16)(mask * 0x1111); // 1111 x 00010001,00010001
                                if (x == Width) break;    pack >>= 4;    mask = ((pack & 1) << 3) | ((pack & 2) << 1) | ((pack >> 1) & 2) | ((pack >> 3) & 1);    Levels[x++, y] = (UInt16)(mask * 0x1111);
                            }
                    else
                        for (; y < Height; y++)
                            for (x = 0; x < Width;)
                            {
                                pack = (pixelBLIndian) ? buffer[i++] : ReversBits.LookUp8[buffer[i++]];
                                                                         mask = pack & 15;    Levels[x++, y] = (UInt16)(mask * 0x1111);
                                if (x == Width) break;    pack >>= 4;    mask = pack;         Levels[x++, y] = (UInt16)(mask * 0x1111);
                            }
                else if (bitBlock == 2)
                    if (pixelBLI)
                        for (; y < Height; y++)
                            for (x = 0; x < Width;)
                            {
                                pack = (pixelBLIndian) ? buffer[i++] : ReversBits.LookUp8[buffer[i++]];
                                                                   Levels[x++, y] = (UInt16)((((pack & 1) << 1) | ((pack >> 1) & 1)) * 0x5555); // 11 x 01010101,01010101
                                if (x == Width) break; pack >>= 2; Levels[x++, y] = (UInt16)((((pack & 1) << 1) | ((pack >> 1) & 1)) * 0x5555);
                                if (x == Width) break; pack >>= 2; Levels[x++, y] = (UInt16)((((pack & 1) << 1) | ((pack >> 1) & 1)) * 0x5555);
                                if (x == Width) break; pack >>= 2; Levels[x++, y] = (UInt16)((((pack & 1) << 1) | ((pack >> 1) & 1)) * 0x5555);
                            }
                    else
                        for (; y < Height; y++)
                            for (x = 0; x < Width;)
                            {
                                pack = (pixelBLIndian) ? buffer[i++] : ReversBits.LookUp8[buffer[i++]];
                                                                         Levels[x++, y] = (UInt16)((pack & 3) * 0x5555);
                                if (x == Width) break;    pack >>= 2;    Levels[x++, y] = (UInt16)((pack & 3) * 0x5555);
                                if (x == Width) break;    pack >>= 2;    Levels[x++, y] = (UInt16)((pack & 3) * 0x5555);
                                if (x == Width) break;    pack >>= 2;    Levels[x++, y] = (UInt16)((pack    ) * 0x5555);
                            }
                // 1 bit bitmap unpacking
                else
                    for (; y < Height; y++)
                    {
                        mask = 256;
                        for (x = 0; x < Width; x++)
                        {
                            // Load next block
                            if (mask == 256)
                            {
                                pack = (pixelBLIndian) ? buffer[i++] : ReversBits.LookUp8[buffer[i++]];
                                mask = 1;
                            }
                            Levels[x, y] = (UInt16)((0 < (pack & mask)) ? 65535 : 0);
                            mask <<= 1;
                        }
                    }
            }
            else
            {
                pack = bitBlock >> 3;
                // =8bit
                if (pack == 1)
                    for (; y < Height; y++)
                        for (x = 0; x < Width; x++)
                        {
                            pack = buffer[i++];
                            Levels[x, y] = (UInt16)((pack << 8) | pack); // 11111111 x 00000001,00000001
                        }
                // >8bit block
                else
                    for (; y < Height; y++)
                        for (x = 0; x < Width; x++)
                        {
                            Levels[x, y] = (UInt16)((buffer[i + hiIdx] << 8) |
                                                     buffer[i + loIdx]       );
                            i += pack;
                        }
            }
        }
        #endregion

        #region Build spectrum
        /// <summary>
        /// Returns mixed color between two
        /// </summary>
        /// <param name="firstColor">
        /// First color
        /// </param>
        /// <param name="c1">
        /// Final color
        /// </param>
        /// <param name="step">
        /// Step from first color
        /// </param>
        /// <param name="maxStep">
        /// Devider of "step"
        /// </param>
        /// <returns>
        /// Integer of a resulting color
        /// </returns>
        public static int MixColor(int firstColor, int finalColor, int step, int maxStep)
        {
            int delta = maxStep - step;
            return A
                + (((byte)(firstColor >> 16) * delta + (byte)(finalColor >> 16) * step) / maxStep << 16)
                + (((byte)(firstColor >>  8) * delta + (byte)(finalColor >>  8) * step) / maxStep <<  8)
                + (((byte)(firstColor      ) * delta + (byte)(finalColor      ) * step) / maxStep      );
        }

        /// <summary>
        /// Build map based on color specific color
        /// </summary>
        /// <param name="color">
        /// Color for maximum level of 65,535
        /// </param>
        /// <param name="stretchMin">
        /// Stretch range by flooring mininmum level to 0
        /// </param>
        /// <param name="stretchMax">
        /// Stretch range by ceiling maximum level to 65,535
        /// </param>
        /// <param name="repeat">
        /// Repeat count on range 0 - 65,535. Default = 1
        /// </param>
        public void BuildMonochrome(int left, int top, int right, int bottom, int color, int stretchMin = 0, int stretchMax = 65535, int repeat = 1)
        {
            int x, offset;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float h, k = (stretchMax - stretchMin); // max 255 target in color component
            offset = top * Width;
            for (int y = top; y <= bottom; y++)
            {
                for (x = left; x <= right; x++)
                {
                    h = (UInt16)(repeat * (Levels[x, y] - stretchMin)) / k;
                    Pixels[x + offset] = A
                        + ((byte)((byte)(color >> 16) * h) << 16)
                        + ((byte)((byte)(color >>  8) * h) <<  8)
                        + ((byte)((byte)(color      ) * h)      );
                }
                offset += Width;
            }
        }

        /// <summary>
        ///  Build color map based on multipliers for Higher and Lower byte
        /// </summary>
        /// <param name="Hi">
        /// Multiplier for High byte
        /// </param>
        /// <param name="Lo">
        /// Multiplier for Low byte
        /// </param>
        /// <param name="stretchMin">
        /// Stretch range by flooring mininmum level to 0
        /// </param>
        /// <param name="stretchMax">
        /// Stretch range by ceiling maximum level to 65,535
        /// </param>
        /// <param name="repeat">
        /// Repeat count on range 0 - 65,535. Default = 1
        /// </param>
        public void BuildHLBytes(int left, int top, int right, int bottom, int Hi, int Lo, int stretchMin = 0, int stretchMax = 65535, int repeat = 1)
        {
            int x, h, offset;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float k = repeat * 65535 / (float)(stretchMax - stretchMin); // 65535 as max target
            offset = top * Width;
            for (int y = top; y <= bottom; y++)
            {
                for (x = left; x <= right; x++)
                {
                    h = (UInt16)((Levels[x, y] - stretchMin) * k);
                    Pixels[x + offset] = A
                        + (((h >>  8) * Hi
                        +   (h & 255) * Lo) & 0xFFffFF);
                }
                offset += Width;
            }
        }

        /// <summary>
        /// Build color map in spectrum of eight ranges (from - to)
        /// </summary>
        /// <param name="colors">
        /// Nine color array for eight ranges. Less will be completed with black
        /// </param>
        /// <param name="stretchMin">
        /// Stretch range by flooring mininmum level to 0
        /// </param>
        /// <param name="stretchMax">
        /// Stretch range by ceiling maximum level to 65,535
        /// </param>
        /// <param name="repeat">
        /// Repeat count on range 0 - 65,535. Default = 1
        /// </param>
        public void BuildSpectrum(int left, int top, int right, int bottom, int[] colors, int stretchMin = 0, int stretchMax = 65535, int repeat = 1)
        {
            int x, h, offset;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float k = (repeat * 65535 / (float)(stretchMax - stretchMin)); // 65535 as max target
            // Fill empty
            if (colors.Length < 9)
            {
                int[] c = new int[9];
                for (x = colors.Length - 1; 0 <= x; x--)
                    c[x] = colors[x];
                colors = c;
            }
            // Build
            int step, delta, color0, color1;
            offset = top * Width;
            for (int y = top; y <= bottom; y++)
            {
                for (x = left; x <= right; x++)
                {
                    //h = (UInt16)((65535*Changed[x, y] - stretchMin) * k); // Display states instead of levels
                    h = (UInt16)((Levels[x, y] - stretchMin) * k);
                    step = (byte)(h >> 5);
                    delta = 255 - step;
                    color0 = colors[(h >> 13)    ];
                    color1 = colors[(h >> 13) + 1];
                    Pixels[x + offset] = A
                        + (((byte)(color0 >> 16) * delta + (byte)(color1 >> 16) * step) / 255 << 16)
                        + (((byte)(color0 >>  8) * delta + (byte)(color1 >>  8) * step) / 255 <<  8)
                        + (((byte)(color0      ) * delta + (byte)(color1      ) * step) / 255      );
                }
                offset += Width;
            }
        }
        #endregion

        public void BuildStatistics(int top, int bottom)
        {
            int x, y, avg, value;
            if (bottom < 0) bottom = Height + bottom;
            for (y = top; y <= bottom; y++)
            {
                // Min
                avg = 0;
                for (x = MaxX; 0 <= x; x--)
                {
                    avg += value = Levels[x, y];
                    if (MinLevel > value) MinLevel = value;
                    if (MaxLevel < value) MaxLevel = value;
                }
                AvgLevelAtRow[y] = avg / Width;
            }
            // Global
            AvgLevel = 0;
            for (y = MaxY; 0 <= y; y--)
                AvgLevel += AvgLevelAtRow[y];
            AvgLevel /= Height;
        }
    }

    class HistoryRecord
    {
        public bool MultiTouch { get; private set; }
        public bool ResizeAction { get; private set; }
        public int Left { get; private set; }
        public int Top { get; private set; }
        public int Right { get; private set; }
        public int Bottom { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public UInt16[,] Clip { get; private set; }
        public float[,] Changed { get; private set; }

        public HistoryRecord(HeightMap HMap, int left, int top, int right, int bottom, bool multiTouch, bool resizeAction = false)
        {
            Width = (Right = right) - (Left = left) + 1;
            Height = (Bottom = bottom) - (Top = top) + 1;
            Clip = HMap.Levels.Clone() as ushort[,];
            Changed = HMap.Changed.Clone() as float[,];
            ResizeAction = resizeAction;
            MultiTouch = multiTouch;
        }

        public void Check(int left, int top, int right, int bottom)
        {
            if (left < Left) Left = left;
            if (top < Top) Top = top;
            if (Right < right) Right = right;
            if (Bottom < bottom) Bottom = bottom;
        }

        public void Crop()
        {
            int x;
            Width = Right - Left + 1;
            Height = Bottom - Top + 1;
            UInt16[,] newClip = new UInt16[Width, Height];
            float[,] newChanged = new float[Width, Height];
            for (int y = 0; y < Height; y++)
                for (x = 0; x < Width; x++)
                {
                    newClip[x, y] = Clip[x + Left, y + Top];
                    newChanged[x, y] = Changed[x + Left, y + Top];
                }
            Clip = newClip;
            Changed = newChanged;
        }

        public void Rollback(HeightMap HMap)
        {
            // Swap back
            if (ResizeAction)
            {
                // Remember corner
                Right = HMap.Width - 1;
                Bottom = HMap.Height - 1;
                // Switch arrays
                UInt16[,] oldClip;
                float[,] oldChanged;
                HMap.SwapClips(Width, Height, Clip, Changed, out oldClip, out oldChanged);
                Clip = oldClip;
                Changed = oldChanged;
                // Update sizes
                Width = Right - Left + 1;
                Height = Bottom - Top + 1;
            }
            // Edit back
            else
            {
                int x, y, sx, sy;
                UInt16 v;
                float f;
                for (y = 0; y < Height; y++)
                    for (x = 0; x < Width; x++)
                    {
                        sx = x + Left;
                        sy = y + Top;
                        v = HMap.Levels[sx, sy];
                        f = HMap.Changed[sx, sy];
                        HMap.Levels[sx, sy] = Clip[x, y];
                        HMap.Changed[sx, sy] = Changed[x, y];
                        Clip[x, y] = v;
                        Changed[x, y] = f;
                    }
            }
        }
    }
}