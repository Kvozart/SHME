using System;

namespace LibPNGsharp
{
    /// <summary>
    /// These are for the interlacing type.
    /// </summary>
    public enum PngInterlaceType : int
    {
        /// <summary>
        /// Non-interlaced image.
        /// </summary>
        None = 0,

        /// <summary>
        /// Adam7 interlacing.
        /// </summary>
        ADAM7 = 1
    }

    /// <summary>
    /// This is for compression type. PNG 1.0-1.2 only define the single type.
    /// </summary>
    public enum PngCompressionType : int
    {
        /// <summary>
        /// Deflate method 8, 32K window.
        /// </summary>
        Base = 0
    }

    /// <summary>
    /// Specifies options for adding a filler byte to a pixel.
    /// </summary>
    public enum PngFillerFlags : int
    {
        /// <summary>
        /// Adds the filler at the start of the pixel array.
        /// </summary>
        Before = 0,

        /// <summary>
        /// Adds the filler at the end of the pixel array.
        /// </summary>
        After = 1
    }

    /// <summary>
    /// The color types of a PNG image.
    /// </summary>
    [Flags]
    public enum PngColorType : int
    {
        /// <summary>
        /// The image uses a color palette.
        /// </summary>
        Palette = 1,

        /// <summary>
        /// The image uses true colors.
        /// </summary>
        Color = 2,

        /// <summary>
        /// The image has an alpha channel.
        /// </summary>
        Alpha = 4,

        /// <summary>
        /// The image is a grayscale image.
        /// </summary>
        Gray = 0,

        /// <summary>
        /// The image uses a color palette.
        /// </summary>
        ColorPalette = (Color | Palette),

        /// <summary>
        /// The image uses a RGB pixel format.
        /// </summary>
        RGB = Color,

        /// <summary>
        /// The image uses a RGBA pixel format.
        /// </summary>
        RGBA = (Color | Alpha),

        /// <summary>
        /// The image uses a grayscale and has an alpha channel.
        /// </summary>
        GrayAlpha = (Alpha),
    }
}
