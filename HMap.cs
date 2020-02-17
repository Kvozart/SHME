using System;
using System.Linq;
using System.Drawing;

namespace SHME
{
    class TopologicalMap
    {
        public const int A = -0x01000000; // 0xFF,00,00,00
        public int[] Pixels { get; private set; } // Color map
        public int   Width  { get; private set; }// = 0;
        public int   Height { get; private set; }// = 0;
        public String URL = "";

        public void SetSize(int width, int height)
        {
            Pixels = new int[width * height];
            Width  = width;
            Height = height;
        }
    }

    class HeightMap : TopologicalMap
    {
        public UInt16[,] Levels { get; private set; } // Height map
        public int[] MinLevelAtRow { get; private set; } // Row height minimums
        public int[] AvgLevelAtRow { get; private set; } // Row height average
        public int[] MaxLevelAtRow { get; private set; } // Row height maximums
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
        /// <param name="saveData">If copy data from old array is needed</param>
        /// <returns>Old levels array</returns>
        public UInt16[,] SetSize(int newWidth, int newHeight, UInt16[,] newLevels = null, bool saveData = false)
        {
            MinLevel = 65535;
            MaxLevel = 0;
            AvgLevel = 32767;
            MinLevelAtRow = new int[newHeight];
            MaxLevelAtRow = new int[newHeight];
            AvgLevelAtRow = new int[newHeight];
            UInt16[,] oldLevels = Levels;
            if (newLevels == null)
            {
                newLevels = new UInt16[newWidth, newHeight];
                if (Levels != null && saveData)
                {
                    int x, w = (Width  < newWidth ) ? Width  : newWidth,
                        y, h = (Height < newHeight) ? Height : newHeight;
                    for (y = 0; y < h; y++)
                        for (x = 0; x < w; x++)
                            newLevels[x, y] = oldLevels[x, y];
                }
            }
            Levels = newLevels;
            base.SetSize(newWidth, newHeight);
            return oldLevels;
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
                eulav = (eulav << 1) + (value & 1);
                value >>= 1;
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
            int x, y, i = 0;
            if (bitBlock < 8)
            {
                int mask, pack = 0;
                bool pixelBLI = (loIdx != 0) ^ pixelBLIndian; // Double invert :(
                if (bitBlock == 4)
                    for (y = 0; y < Height; y++)
                        for (x = 0; x < Width;)
                        {
                            pack = (pixelBLIndian) ? buffer[i++] : MirrorBits(buffer[i++], 8);
                            Levels[x, y] = (UInt16)((pixelBLI ? MirrorBits(pack, 4) : pack & 15) * 0x1111);
                            x++;
                            if (x == Width) break;
                            pack >>= 4;
                            Levels[x, y] = (UInt16)((pixelBLI ? MirrorBits(pack, 4) : pack) * 0x1111);
                            x++;
                        }
                else if (bitBlock == 2)
                    for (y = 0; y < Height; y++)
                        for (x = 0; x < Width;)
                        {
                            pack = (pixelBLIndian) ? buffer[i++] : MirrorBits(buffer[i++], 8);
                            Levels[x, y] = (UInt16)((pixelBLI ? MirrorBits(pack, 2) : pack & 3) * 0x5555);
                            x++;
                            if (x == Width) break;
                            pack >>= 2;
                            Levels[x, y] = (UInt16)((pixelBLI ? MirrorBits(pack, 2) : pack & 3) * 0x5555);
                            x++;
                            if (x == Width) break;
                            pack >>= 2;
                            Levels[x, y] = (UInt16)((pixelBLI ? MirrorBits(pack, 2) : pack & 3) * 0x5555);
                            x++;
                            if (x == Width) break;
                            pack >>= 2;
                            Levels[x, y] = (UInt16)((pixelBLI ? MirrorBits(pack, 2) : pack) * 0x5555);
                            x++;
                        }
                else
                    for (y = 0; y < Height; y++)
                    {
                        mask = 256;
                        for (x = 0; x < Width; x++)
                        {
                            if (mask == 256)
                            {
                                mask = 1;
                                pack = (pixelBLIndian) ? buffer[i++] : MirrorBits(buffer[i++], 8);
                            }
                            Levels[x, y] = (UInt16)((0 < (pack & mask)) ? 65535 : 0);
                            mask <<= 1;
                        }
                    }
            }
            else
            {
                int blockSize = bitBlock / 8;
                // =8bit
                if (blockSize < 2)
                    for (y = 0; y < Height; y++)
                        for (x = 0; x < Width; x++)
                            Levels[x, y] = (UInt16)(buffer[i++] * 0x101);
                // >8bit block
                else
                    for (y = 0; y < Height; y++)
                        for (x = 0; x < Width; x++)
                            Levels[x, y] = (UInt16)(
                                (buffer[i * blockSize + hiIdx] << 8) +
                                 buffer[i++ * blockSize + loIdx]
                                );
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
        public static int MixColor(int firstColor, int finalColor, int step, int maxStep) =>
            A
            + (((byte)(firstColor >> 16) * (maxStep - step) + (byte)(finalColor >> 16) * step) / maxStep << 16)
            + (((byte)(firstColor >>  8) * (maxStep - step) + (byte)(finalColor >>  8) * step) / maxStep <<  8)
            + (((byte)(firstColor      ) * (maxStep - step) + (byte)(finalColor      ) * step) / maxStep      );

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
            int x;
            if (right  < 0) right  = Width  + right;
            if (bottom < 0) bottom = Height + bottom;
            float h, k = (stretchMax - stretchMin); // max 255 target in color component
            for (int y = top; y <= bottom; y++)
                for (x = left; x <= right; x++)
                {
                    h = (UInt16)(repeat * (Levels[x, y] - stretchMin)) / k;
                    Pixels[x + y * Width] = A
                        + ((byte)((byte)(color >> 16) * h) << 16)
                        + ((byte)((byte)(color >>  8) * h) <<  8)
                        + ((byte)((byte)(color      ) * h)      );
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
                    h = (UInt16)((Levels[x, y] - stretchMin) * k);
                    Pixels[x + y * Width] = A
                        + ((   (h >> 8) * Hi
                        + (byte)h       * Lo) & 0xFFffFF);
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
            int x, h, segment;
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
            for (int y = top; y <= bottom; y++)
                for (x = left; x <= right; x++)
                {
                    h = (UInt16)((Levels[x, y] - stretchMin) * k);
                    segment = (h >> 13);
                    Pixels[x + y * Width] = MixColor(colors[segment], colors[segment + 1], (byte)(h >> 5), 255);
                }
        }
        #endregion

        public void BuildStatistics(int top, int bottom)
        {
            int x, y, min, max, avg;
            if (bottom < 0) bottom = Height + bottom;
            for (y = top; y <= bottom; y++)
            {
                // Min
                min = Levels[0, y];
                max = Levels[0, y];
                avg = Levels[0, y];
                for (x = 1; x < Width; x++)
                {
                    if (min > Levels[x, y])
                        min = Levels[x, y];
                    if (max < Levels[x, y])
                        max = Levels[x, y];
                    avg += Levels[x, y];
                }
                MinLevelAtRow[y] = min;
                MaxLevelAtRow[y] = max;
                AvgLevelAtRow[y] = avg / Width;
            }
            // Global
            MinLevel = MinLevelAtRow[0];
            MaxLevel = MaxLevelAtRow[0];
            AvgLevel = AvgLevelAtRow[0];
            for (y = 1; y < Height; y++)
            {
                if (MinLevel > MinLevelAtRow[y])
                    MinLevel = MinLevelAtRow[y];
                if (MaxLevel < MaxLevelAtRow[y])
                    MaxLevel = MaxLevelAtRow[y];
                AvgLevel += AvgLevelAtRow[y];
            }
            AvgLevel /= Height;
        }
    }
}
