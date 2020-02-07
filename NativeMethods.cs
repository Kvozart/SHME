﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibPNGsharp
{
    /// <summary>
    /// Provides access to native methods for interacting with libpng.
    /// </summary>
    internal class NativeMethods
    {
        #region Main
        /// <summary>
        /// The name of the libpng library, excluding any platform-dependent prefixes (such as <c>lib</c>) and suffixes (such as <c>.so</c>).
        /// </summary>
        private const string Library = "png16";

        /// <summary>
        /// Gets the library version string.
        /// </summary>
        /// <param name="png_ptr">
        /// A pointer to an instance of libpng. This can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// The library version as a short string in the format <c>1.0.0</c> through <c>99.99.99zz</c>
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr png_get_libpng_ver(IntPtr png_ptr);

        /// <summary>
        /// Allocate and initialize a png_info structure
        /// </summary>
        /// <param name="png_ptr">
        /// </param>
        /// <returns>
        /// Returns the pointer to png_info structure. Returns <see cref="IntPtr.Zero"/> if it fails to create the structure.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr png_create_info_struct(IntPtr png_ptr);

        /// <summary>
        /// Set FILE * fp
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="fp"></param>
        /// <returns></returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte png_init_io(IntPtr png_ptr, IntPtr fp);

        /// <summary>
        /// Frees the memory pointed to by <paramref name="png_ptr"/> previously allocated by png_malloc().
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_free(IntPtr png_ptr, IntPtr ptr);
        #endregion

        #region Read
        /// <summary>
        /// Allocate and initialize a png_struct structure for reading PNG file
        /// </summary>
        /// <param name="user_png_ver">
        /// Version string of the library. Must be <c>PNG_LIBPNG_VER_STRING</c>
        /// </param>
        /// <param name="error_ptr">
        /// User-defined struct for error functions.
        /// </param>
        /// <param name="error_fn">
        /// User-defined function for printing errors and aborting.
        /// </param>
        /// <param name="warn_fn">
        /// User-defined function for warnings.
        /// </param>
        /// <returns>
        /// Returns the pointer to png_struct structure. Returns <see cref="IntPtr.Zero"/> if it fails to create the structure.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr png_create_read_struct(IntPtr user_png_ver, IntPtr error_ptr, png_error error_fn, png_error warn_fn);

        /// <summary>
        /// Set user-defined function for reading a PNG stream
        /// </summary>
        /// <param name="png_ptr">
        /// Pointer to input data structure png_struct
        /// </param>
        /// <param name="io_ptr">
        /// Pointer to user-defined structure containing information about the input functions. This value may be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="read_data_fn">
        /// Pointer to new input function that shall take the following arguments:
        /// - a pointer to a png_struct
        /// - a pointer to a structure where input data can be stored
        /// - 32-bit unsigned int to indicate number of bytes to read
        /// The input function should invoke png_error() to handle any fatal errors and png_warning() to handle non-fatal errors.
        /// </param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_read_fn(IntPtr read_ptr, IntPtr read_io_ptr, [MarshalAs(UnmanagedType.FunctionPtr)]png_rw read_data_fn);

        /// <summary>
        /// Reads the information before the actual image data from the PNG file. The function allows reading a file that already has the PNG signature bytes read from the stream.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_read_info(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Updates the structure pointed to by info_ptr to reflect any transformations that have been requested.
        /// For example, rowbytes will be updated to handle expansion of an interlaced image with png_read_update_info().
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_read_update_info(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Read the entire image into memory. For each pass of an interlaced image, use png_read_rows() instead.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="image"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_read_image(IntPtr png_ptr, IntPtr[] row_pointers);

        /// <summary>
        /// Frees the memory associated with the read png_struct struct that holds information from the given PNG file, the associated png_info struct for
        /// holding the image information and png_info struct for holding the information at end of the given PNG file.
        /// </summary>
        /// <param name="png_ptr_ptr"></param>
        /// <param name="info_ptr_ptr"></param>
        /// <param name="end_info_ptr_ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_destroy_read_struct(ref IntPtr png_ptr_ptr, ref IntPtr info_ptr_ptr, ref IntPtr end_info_ptr_ptr);

        /// <summary>
        /// Reads the end of a PNG file after reading the image data, including any comments or time information at the end of the file.
        /// The function shall not read past the end of the file
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_read_end(IntPtr png_ptr, IntPtr info_ptr);
        #endregion

        #region Get_Parameters
        /// <summary>
        /// Returns the image width in pixels.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <returns>
        /// The image width in pixels.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint png_get_image_width(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Returns the image height in pixels.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <returns>
        /// Returns 0 if png_ptr or info_ptr is <see cref="IntPtr.Zero"/>, image_height otherwise.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint png_get_image_height(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Returns the image color type.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <returns>
        /// Returns 0 if png_ptr or info_ptr is NULL, color_type otherwise.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern PngColorType png_get_color_type(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Get number of color channels in image
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <returns>
        /// On success, png_get_channels() shall return the number of channels ranging from 1-4. Otherwise, png_get_channels shall return 0.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte png_get_channels(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Return image bit_depth
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <returns>
        /// Returns 0 if png_ptr or info_ptr is NULL, bit_depth otherwise.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte png_get_bit_depth(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Return number of bytes for a row
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <returns>
        /// Returns 0 if <paramref name="png_ptr"/> or <paramref name="info_ptr"/> is <see cref="IntPtr.Zero"/>, number of bytes otherwise.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint png_get_rowbytes(IntPtr png_ptr, IntPtr info_ptr);
        #endregion

        #region Transforms
        /// <summary>
        /// Transforms paletted images to RGB.
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_palette_to_rgb(IntPtr png_ptr);

        /// <summary>
        /// Transforms grayscale images of less than 8 to 8 bits
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_gray_1_2_4_to_8(IntPtr png_ptr);

        /// <summary>
        /// Removes the alpha channel.
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_strip_alpha(IntPtr png_ptr);

        /// <summary>
        /// Adds a filler byte when an 8-bit grayscale image or 24-bit RGB image is read.
        /// </summary>
        /// <param name="filler">
        /// The filler byte to add.
        /// </param>
        /// <param name="flags">
        /// Flags controlling how to add the filler.
        /// </param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_filler(IntPtr png_ptr, uint filler, PngFillerFlags flags);

        /// <summary>
        /// Expands to 1 pixel per byte.
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_packing(IntPtr png_ptr);

        /// <summary>
        /// Changes the pixel byte order for 16-bit pixels from bit-endian to little-endian.
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_swap(IntPtr png_ptr);

        /// <summary>
        /// Swaps the onder in which pixels are packed into bytes.
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_packswap(IntPtr png_ptr);
        #endregion

        #region Write
        /// <summary>
        /// Allocate and initialize a png_struct structure for writeing PNG file
        /// </summary>
        /// <param name="user_png_ver">
        /// Version string of the library. Must be <c>PNG_LIBPNG_VER_STRING</c>
        /// </param>
        /// <param name="error_ptr">
        /// User-defined struct for error functions.
        /// </param>
        /// <param name="error_fn">
        /// User-defined function for printing errors and aborting.
        /// </param>
        /// <param name="warn_fn">
        /// User-defined function for warnings.
        /// </param>
        /// <returns>
        /// Returns the pointer to png_struct structure. Returns <see cref="IntPtr.Zero"/> if it fails to create the structure.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr png_create_write_struct(IntPtr user_png_ver, IntPtr error_ptr, png_error error_fn, png_error warn_fn);

        /// <summary>
        /// This call is equivalent to png_write_info(), followed the set of transformations indicated by the transform mask, then png_write_image(), and finally png_write_end()
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        /// <param name="png_transforms">
        /// an integer containing the logical OR of some set of transformation flags
        /// </param>
        /// <param name="png_unused"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_write_png(IntPtr png_ptr, IntPtr info_ptr, int png_transforms, IntPtr png_unused);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_IHDR(IntPtr png_ptr, IntPtr info_ptr, int width, int height, int bit_depth,
            PngColorType color_type, PngInterlaceType PNG_INTERLACE_NONE, PngCompressionType PNG_COMPRESSION_TYPE_BASE, PngFillerFlags PNG_FILTER_TYPE_BASE);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_set_write_fn(IntPtr write_ptr, IntPtr write_io_ptr,
            [MarshalAs(UnmanagedType.FunctionPtr)]png_rw write_data_fn,
            [MarshalAs(UnmanagedType.FunctionPtr)]png_flush output_flush_fn);

        /// <summary>
        /// Writes the information before the actual image data in the PNG file
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_write_info(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Write the entire image into file. For each pass of an interlaced image, use png_write_rows() instead.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="image"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_write_image(IntPtr png_ptr, IntPtr[] row_pointers);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_write_rows(IntPtr png_ptr, IntPtr[] row_pointers, int number_of_rows);

        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_write_row(IntPtr png_ptr, IntPtr row_pointer);

        /// <summary>
        /// Set the scheme to interlacing for writing an image and return the number of sub-images required to write the image.
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <returns>
        /// 7 if the image is interlaced, otherwise 1.
        /// </returns>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern int png_set_interlace_handling(IntPtr png_ptr);

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="png_ptr"></param>
        /// <param name="info_ptr"></param>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_write_end(IntPtr png_ptr, IntPtr info_ptr);

        /// <summary>
        /// Frees the memory associated with the write png_struct struct that holds information, the associated png_info struct for
        /// holding the image information and png_info struct for holding the information at end of the PNG file
        /// </summary>
        [DllImport(Library, CallingConvention = CallingConvention.Cdecl)]
        public static extern void png_destroy_write_struct(ref IntPtr png_ptr_ptr, ref IntPtr info_ptr_ptr);
        #endregion

        public unsafe delegate void png_rw(IntPtr png_ptr, IntPtr outBytes, uint byteCountToRead);
        public unsafe delegate void png_flush(IntPtr png_ptr);
        public delegate void png_error(IntPtr png_structp, IntPtr png_const_charp);
    }
}
