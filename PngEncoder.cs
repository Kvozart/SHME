using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibPNGsharp
{
    public unsafe class PngWriter : IDisposable
    {
        IntPtr verPtr;
        IntPtr pngPtr;
        IntPtr infoPtr;
        IntPtr endInfoPtr = IntPtr.Zero;
        NativeMethods.png_rw writeCallback;
        NativeMethods.png_flush flushCallback;
        NativeMethods.png_error errorCallback;
        NativeMethods.png_error warningCallback;
        byte[] buffer = new byte[32];

        public PngWriter(String FileName, byte[] ScanLine, int Width, int Height, int Channels, int BitDepth, PngColorType ColorType)
        {
            if (ScanLine == null) throw
                    new ArgumentNullException(nameof(ScanLine));
            using (Stream stream = File.OpenWrite(FileName))
            {
                BytesPerRow = Width * Channels * BitDepth / 8;
                pngStream = stream ?? throw new ArgumentNullException(nameof(stream));

                Version = Marshal.PtrToStringAnsi(verPtr = NativeMethods.png_get_libpng_ver(IntPtr.Zero));
                errorCallback   = new NativeMethods.png_error(OnError);
                warningCallback = new NativeMethods.png_error(OnWarning);

                // Creat structures
                ThrowOnZero(pngPtr  = NativeMethods.png_create_write_struct(verPtr, IntPtr.Zero, errorCallback, warningCallback));
                ThrowOnZero(infoPtr = NativeMethods.png_create_info_struct(pngPtr));

                // Set the callback function
                NativeMethods.png_set_write_fn(pngPtr, IntPtr.Zero, writeCallback = new NativeMethods.png_rw(WriteBlock), flushCallback = new NativeMethods.png_flush(FlushBlock));

                // Init image
                NativeMethods.png_set_IHDR(pngPtr, infoPtr, Width, Height, BitDepth, ColorType, PngInterlaceType.None, PngCompressionType.Base, PngFillerFlags.Before);

                // Write basic image properties
                NativeMethods.png_write_info(pngPtr, infoPtr);

                // Write image data
                fixed (byte* ptr = ScanLine)
                {
                    IntPtr[] rowPtrs = new IntPtr[Height];
                    IntPtr rowPtr = (IntPtr)ptr;
                    for (int i = 0; i < Height; i++)
                    {
                        rowPtrs[i] = rowPtr;
                        rowPtr += BytesPerRow;
                    }
                    NativeMethods.png_write_image(pngPtr, rowPtrs);
                }

                // Write end_info data
                NativeMethods.png_write_end(pngPtr, endInfoPtr);
            }
        }

        private void WriteBlock(IntPtr png_ptr, IntPtr outBytes, uint byteCountToRead)
        {
            if (buffer.Length < byteCountToRead)
                buffer = new byte[(int)byteCountToRead];
            Marshal.Copy(outBytes, buffer, 0, (int)byteCountToRead);
            pngStream.Write(buffer, 0, (int)byteCountToRead);
        }

        private void FlushBlock(IntPtr png_ptr) {}

        /// <summary>
        /// Version of libpng.
        /// </summary>
        public string Version { get; private set; }

        public Stream pngStream { get; private set; }

        /// <summary>
        /// Gets the number of bytes in a row.
        /// </summary>
        public int BytesPerRow { get; private set; }

        private void OnError  (IntPtr png_structp, IntPtr png_const_charp) { throw new ArgumentException(Marshal.PtrToStringAnsi(png_const_charp)); }
        private void OnWarning(IntPtr png_structp, IntPtr png_const_charp) { throw new ArgumentException(Marshal.PtrToStringAnsi(png_const_charp)); }

        private void ThrowOnZero(IntPtr value)
        {
            if (value == IntPtr.Zero)
                throw new Exception();
        }

        /// <inheritdoc/>
        public void Dispose() => NativeMethods.png_destroy_write_struct(ref pngPtr, ref infoPtr);
    }
}