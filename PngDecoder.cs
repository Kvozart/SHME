// C# equivalent of:
// http://zarb.org/~gc/html/libpng.html
// http://pulsarengine.com/2009/01/reading-png-images-from-memory/

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibPNGsharp
{
    /// <summary>
    /// Decodes PNG images using the libpng library.
    /// </summary>
    public unsafe class PngReader : IDisposable
    {
        IntPtr verPtr;
        IntPtr pngPtr;
        IntPtr infoPtr;
        IntPtr endInfoPtr = IntPtr.Zero;
        NativeMethods.png_rw readCallback;
        NativeMethods.png_error errorCallback;
        NativeMethods.png_error warningCallback;

        public byte[] ScanLine;
        byte[] buffer = new byte[32];

        /// <summary>
        /// Initializes a new instance of the <see cref="PngReader"/> class.
        /// </summary>
        /// <param name="stream">
        /// A <see cref="pngStream"/> which contains a PNG image.
        /// </param>
        public PngReader(String FileName)
        {
            using (Stream stream = File.OpenRead(FileName))
            {
                pngStream = stream ?? throw new ArgumentNullException(nameof(stream));

                Version = Marshal.PtrToStringAnsi(verPtr = NativeMethods.png_get_libpng_ver(IntPtr.Zero));
                errorCallback   = new NativeMethods.png_error(OnError);
                warningCallback = new NativeMethods.png_error(OnWarning);

                // Creat structures
                ThrowOnZero(pngPtr  = NativeMethods.png_create_read_struct(verPtr, IntPtr.Zero, errorCallback, warningCallback)); // ?IntPtr(1)?
                ThrowOnZero(infoPtr = NativeMethods.png_create_info_struct(pngPtr));

                // Set the callback function
                NativeMethods.png_set_read_fn(pngPtr, IntPtr.Zero, readCallback = new NativeMethods.png_rw(ReadBlock));

                // Get basic image properties
                try
                {
                    NativeMethods.png_read_info(pngPtr, infoPtr);
                    Width       = (int)NativeMethods.png_get_image_width(pngPtr, infoPtr);
                    Height      = (int)NativeMethods.png_get_image_height(pngPtr, infoPtr);
                    BitDepth    =      NativeMethods.png_get_bit_depth(pngPtr, infoPtr);
                    Channels    =      NativeMethods.png_get_channels(pngPtr, infoPtr);
                    BytesPerRow = (int)NativeMethods.png_get_rowbytes(pngPtr, infoPtr);
                    ColorType   =      NativeMethods.png_get_color_type(pngPtr, infoPtr);
                    DecompressedSize = BytesPerRow * Height;

                    // Get image data
                    ScanLine = new byte[DecompressedSize];
                    fixed (byte* ptr = ScanLine)
                    {
                        IntPtr[] rowPtrs = new IntPtr[Height];
                        IntPtr rowPtr = (IntPtr)ptr;
                        for (int i = 0; i < Height; i++)
                        {
                            rowPtrs[i] = rowPtr;
                            rowPtr += BytesPerRow;
                        }
                        NativeMethods.png_read_image(pngPtr, rowPtrs);
                    }

                    // Read the end_info data
                    NativeMethods.png_read_end(pngPtr, endInfoPtr);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }

        private void ReadBlock(IntPtr png_ptr, IntPtr outBytes, uint byteCountToRead)
        {
            if (buffer.Length < byteCountToRead)
                buffer = new byte[(int)byteCountToRead];
            pngStream.Read(buffer, 0, (int)byteCountToRead);
            Marshal.Copy(buffer, 0, outBytes, (int)byteCountToRead);
        }

        #region Parameter methods
        /// <summary>
        /// Gets the version of libpng.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// The <see cref="pngStream"/> from which to read the PNG image.
        /// </summary>
        public Stream pngStream { get; private set; }

        /// <summary>
        /// Gets the image width in pixels.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the image height in pixels.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the image color type.
        /// </summary>
        public PngColorType ColorType { get; private set; }

        /// <summary>
        /// Gets the number of color channels in the image.
        /// </summary>
        public int Channels { get; private set; }

        /// <summary>
        /// Gets the image bit depth.
        /// </summary>
        public int BitDepth { get; private set; }

        /// <summary>
        /// Gets the number of bytes in a row.
        /// </summary>
        public int BytesPerRow { get; private set; }

        /// <summary>
        /// Gets the size of the decompressed image.
        /// </summary>
        public int DecompressedSize { get; private set; }
        #endregion

        #region Error Handlers
        private void OnError  (IntPtr png_structp, IntPtr png_const_charp) { throw new ArgumentException(Marshal.PtrToStringAnsi(png_const_charp)); }
        private void OnWarning(IntPtr png_structp, IntPtr png_const_charp) { throw new ArgumentException(Marshal.PtrToStringAnsi(png_const_charp)); }

        private void ThrowOnZero(IntPtr value)
        {
            if (value == IntPtr.Zero)
                throw new Exception();
        }
        #endregion

        /// <inheritdoc/>
        public void Dispose()
        {
            //NativeMethods.png_free(IntPtr.Zero, verPtr);
            NativeMethods.png_destroy_read_struct(ref pngPtr, ref infoPtr, ref endInfoPtr);
        }
    }
}