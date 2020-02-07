using System;
using System.Linq;
using System.Drawing;

namespace SHME
{
    class HeightMap
    {
        public const int A = -0x01000000; // 0xFF,00,00,00
        public int Width;
        public int Height;
        public UInt16[,] Level; // Height map
        public  Int32[,] Pixel { get; private set; } // Color map
        public int[] MinLevelAtRow { get; private set; } // Row height minimums
        public int[] AvgLevelAtRow { get; private set; } // Row height average
        public int[] MaxLevelAtRow { get; private set; } // Row height maximums
        public int MinLevel { get; private set; }
        public int AvgLevel { get; private set; }
        public int MaxLevel { get; private set; }

        #region Constructors
        /// <summary>
        /// Create empty map of specified sizes
        /// </summary>
        public HeightMap(int width, int height) => SetLevelMap(width, height, new UInt16[width, height]);

        /// <summary>
        /// Create 256x256 gradient map from 0 to 65,535
        /// </summary>
        /// <param name="serpantin">
        /// Create gradient in serpantin manner
        /// </param>
        public HeightMap(bool serpantin = false) : this(256, 256)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    Level[x, y] = (UInt16)((y << 8) + x);
                    if (serpantin)
                        Level[x, ++y] = (UInt16)((y << 8) - x + 255);
                }
        }

        /// <summary>
        /// Mirror specified bit count from input value and mirror them to output
        /// </summary>
        /// <param name="value">
        /// Input value with bits to mirror
        /// </param>
        /// <param name="bits">
        /// Count of bits to mirror
        /// </param>
        /// <returns></returns>
        public int  MirrorBits (int  value, byte bits = 32)
        {
            int eulav = 0;
            for (int i = 0; i < bits; i++)
            {
                eulav = (eulav << 1);
                eulav = (eulav | (value & 1));
                value = (value >> 1);
            }
            return eulav;
        }

        /// <summary>
        /// Copy map of specified sizes with levels from buffer
        /// </summary>
        /// <param name="buffer">
        /// Byte BigLittle/LittleBig indian array of size of width*height*block
        /// </param>
        /// <param name="buffer">Byte scanline</param>
        /// <param name="bitDepth">Bit packing</param>
        /// <param name="loIdx"
        /// >Lower byte offset. Also Big-Little indian flag for BitDepth less 8
        /// </param>
        /// <param name="hiIdx">
        /// Higher byte offset
        /// </param>
        /// <param name="pixelBLIndian">
        /// Big-Little indian pixels in byte flag
        /// </param>
        public void Init(byte[] buffer, int bitDepth = 8, int loIdx = 0, int hiIdx = 1, bool pixelBLIndian = false)
        {
            int i = 0;
            if (bitDepth < 8)
            {
                int pack;
                bool pixelBLI = (loIdx != 0) ^ pixelBLIndian; // Double invert :(
                if (bitDepth == 4)
                    for (int y = 0; y < Height; y++)
                        for (int x = 0; x < Width;)
                        {
                            pack = (pixelBLIndian) ? buffer[i++] : MirrorBits(buffer[i++], 8);
                            Level[x, y] = (byte)(pack & 15);
                            Level[x, y] = (UInt16)((pixelBLI ? MirrorBits(Level[x, y], 4) : Level[x, y]) * 0x1111);
                            x++;
                            if (x == Width) break;
                            Level[x, y] = (byte)(pack >> 4);
                            Level[x, y] = (UInt16)((pixelBLI ? MirrorBits(Level[x, y], 4) : Level[x, y]) * 0x1111);
                            x++;
                        }
                else if (bitDepth == 2)
                    for (int y = 0; y < Height; y++)
                        for (int x = 0; x < Width;)
                        {
                            pack = (pixelBLIndian) ? buffer[i++] : MirrorBits(buffer[i++], 8);
                            Level[x, y] = (byte)(pack & 3);
                            Level[x, y] = (UInt16)((pixelBLI ? MirrorBits(Level[x, y], 2) : Level[x, y]) * 0x5555);
                            x++;
                            if (x == Width) break;
                            Level[x, y] = (byte)((pack >> 2) & 3);
                            Level[x, y] = (UInt16)((pixelBLI ? MirrorBits(Level[x, y], 2) : Level[x, y]) * 0x5555);
                            x++;
                            if (x == Width) break;
                            Level[x, y] = (byte)((pack >> 4) & 3);
                            Level[x, y] = (UInt16)((pixelBLI ? MirrorBits(Level[x, y], 2) : Level[x, y]) * 0x5555);
                            x++;
                            if (x == Width) break;
                            Level[x, y] = (byte)(pack >> 6);
                            Level[x, y] = (UInt16)((pixelBLI ? MirrorBits(Level[x, y], 2) : Level[x, y]) * 0x5555);
                            x++;
                        }
                else
                {
                    int mask;
                    pack = 0;
                    for (int y = 0; y < Height; y++)
                    {
                        mask = 256;
                        for (int x = 0; x < Width; x++)
                        {
                            if (mask == 256)
                            {
                                mask = 1;
                                pack = (pixelBLIndian) ? buffer[i++] : MirrorBits(buffer[i++], 8);
                            }
                            Level[x, y] = (UInt16)((0 < (pack & mask)) ? 65535 : 0);
                            mask = mask << 1;
                        }
                    }
                }
            }
            else
            {
                int blockSize = bitDepth / 8;
                // =8bit
                if (blockSize < 2)
                    for (int y = 0; y < Height; y++)
                        for (int x = 0; x < Width; x++)
                            Level[x, y] = (UInt16)(buffer[i++] * 0x101);
                // >8bit
                else
                    for (int y = 0; y < Height; y++)
                        for (int x = 0; x < Width; x++)
                            Level[x, y] = (UInt16)(
                                (buffer[i * blockSize + hiIdx] << 8) +
                                 buffer[i++ * blockSize + loIdx]
                                );
            }
        }
        #endregion

        #region Building
        /// <summary>
        /// Replace owned level map with new and recreate statistic arrays
        /// </summary>
        /// <param name="width">width of new map</param>
        /// <param name="height">height of new map</param>
        /// <param name="newLevel">new level map</param>
        /// <returns></returns>
        public UInt16[,] SetLevelMap(int width, int height, UInt16[,] newLevel)
        {
            Width  = width;
            Height = height;
            UInt16[,] oldLevel = Level;
            Level = newLevel;
            Pixel = new Int32[Width, Height];
            MinLevelAtRow = new int[Height];
            AvgLevelAtRow = new int[Height];
            MaxLevelAtRow = new int[Height];
            return oldLevel;
        }

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
        public static int MixColor(Color firstColor, Color finalColor, byte step, byte maxStep) =>
            A
            + ((firstColor.R * (maxStep - step) + finalColor.R * step) / maxStep << 16)
            + ((firstColor.G * (maxStep - step) + finalColor.G * step) / maxStep <<  8)
            +  (firstColor.B * (maxStep - step) + finalColor.B * step) / maxStep;

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
        public void BuildMonochrome(int left, int top, int right, int bottom, Color color, int stretchMin = 0, int stretchMax = 65535, int repeat = 1)
        {
            int x;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float h, k = repeat / (float)(stretchMax - stretchMin); // max 255 target in color component
            for (int y = top; y <= bottom; y++)
                for (x = left; x <= right; x++)
                {
                    h = (Level[x, y] - stretchMin) * k;
                    Pixel[x, y] = A
                        + ((byte)(color.R * h) << 16)
                        + ((byte)(color.G * h) << 8)
                        +  (byte)(color.B * h);
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
            int x, h;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float k = repeat * 65535 / (float)(stretchMax - stretchMin); // 65535 as max target
            for (int y = top; y <= bottom; y++)
                for (x = left; x <= right; x++)
                {
                    h = (int)((Level[x, y] - stretchMin) * k);
                    Pixel[x, y] = A
                        + ((((h >> 8) & 255) * Hi
                        +   ( h       & 255) * Lo) & 0xFFffFF);
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
        public void BuildSpectrum(int left, int top, int right, int bottom, Color[] colors, int stretchMin = 0, int stretchMax = 65535, int repeat = 1)
        {
            UInt16 h;
            int x, segment;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float k = (repeat * 65535 / (float)(stretchMax - stretchMin)); // 65535 as max target
            // Fill empty
            Color[] color = new Color[9];
            for (x = 0; x < colors.Length; x++)
                color[x] = colors[x];
            // Build
            for (int y = top; y <= bottom; y++)
                for (x = left; x <= right; x++)
                {
                    h = (UInt16)((Level[x, y] - stretchMin) * k);
                    segment = (h >> 13);
                    Pixel[x, y] = MixColor(colors[segment], colors[segment + 1], (byte)(h >> 5), 255);
                }
        }
        #endregion

        #region Max/Min
        public void BuildStatistics(int top, int bottom)
        {
            if (bottom < 0) bottom = Height + bottom;
            for (int y = top; y <= bottom; y++)
            {
                CalculateMinAtRow(y);
                CalculateAvgAtRow(y);
                CalculateMaxAtRow(y);
            }
            CalculateMin();
            CalculateAvg();
            CalculateMax();
        }

        public void CalculateMin() => MinLevel = MinLevelAtRow.Min();
        public void CalculateMinAtRow(int row)
        {
            int min = Level[0, row];
            for (int x = 1; x < Width; x++)
                if (min > Level[x, row])
                    min = Level[x, row];
            MinLevelAtRow[row] = min;
        }

        public void CalculateAvg() => AvgLevel = AvgLevelAtRow.Sum() / Height;
        public void CalculateAvgAtRow(int row)
        {
            int avg = Level[0, row];
            avg = Level[0, row];
            for (int x = 1; x < Width; x++)
                avg += Level[x, row];
            AvgLevelAtRow[row] = avg / Width;
        }

        public void CalculateMax() => MaxLevel = MaxLevelAtRow.Max();
        public void CalculateMaxAtRow(int row)
        {
            int max = Level[0, row];
            max = Level[0, row];
            for (int x = 1; x < Width; x++)
                if (max < Level[x, row])
                    max = Level[x, row];
            MaxLevelAtRow[row] = max;
        }
        #endregion
    }
}
