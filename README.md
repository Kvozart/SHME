# SHME
Spectrum Height Map Editor.

Can import/load images:
 - 1/2/4/8/16 bit gray or 24/32 bit [A]RGB (1 or combined 2 channels) PNG (LibPNG);
 - 1/4/8/24/32 bit [A]RGB (1 or combined 2 channels) BMP, JPEG, GIF, TIFF;
 - For [A]RGB: choosable 1/2 color component to represent height value;
 - For 1/2/4 bit: choosable pixel pack order;
 - For 16 bit: choosable byte pack order.
 
View as:
 - Monochrome - Classic one color (choosable color);
 - 2Bytes - gradient like result of combining 2 color component multipliers (i.e. 0x010101 - white) for Higher and Lower bytes;
 - Spectrum - choose 9 colors (8 ranges) to spread layout visually from 8 to 11 bit like classic height topographic map.
 
Additionaly:
 - In all layouts color spectrum can be looped up to 32 times to better cover 16 bit range;
 - Height values can be visualy stretched to 16 bit limits;
 - Two switchable height/topological map layers (assignable to mouse button).
 
Editing (assignable to Left, Middle and Right mouse buttons):
 - Five mouse buttons for instruments and thee slots for value/force, shape, form and size of brush;
 - Three value slots;
 - Grid (from x8);
 - Pencil;
 - Probe;
 - Level;
 - Add/Sub level;
 - Smooth;
 
Export:
 - Height map as 8/16 bit gray PNG (LibPNG);
 - Spectrum view as 24 bit RGB BMP, JPEG, GIF, TIFF.

Code reference: read 1/2/4/8/16 bit and write 8/16 bit with LibPNG DLL in C#
