/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A screen with indexed colors.
     /// 
     /// This is often run over an SPI connection, not regular single-wire Jacdac.
    /// Implements a client for the Indexed screen service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/indexedscreen/" />
    public partial class IndexedScreenClient : Client
    {
        public IndexedScreenClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.IndexedScreen)
        {
        }

        /// <summary>
        /// Reads the <c>brightness</c> register value.
        /// Set backlight brightness.
        /// If set to `0` the display may go to sleep., _: /
        /// </summary>
        public float Brightness
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)IndexedScreenReg.Brightness, IndexedScreenRegPack.Brightness);
            }
            set
            {
                
                this.SetRegisterValue((ushort)IndexedScreenReg.Brightness, IndexedScreenRegPack.Brightness, value);
            }

        }

        /// <summary>
        /// Reads the <c>bits_per_pixel</c> register value.
        /// Determines the number of palette entries.
        /// Typical values are 1, 2, 4, or 8., _: bit
        /// </summary>
        public uint BitsPerPixel
        {
            get
            {
                return (uint)this.GetRegisterValue((ushort)IndexedScreenReg.BitsPerPixel, IndexedScreenRegPack.BitsPerPixel);
            }
        }

        /// <summary>
        /// Reads the <c>width</c> register value.
        /// Screen width in "natural" orientation., _: px
        /// </summary>
        public uint Width
        {
            get
            {
                return (uint)this.GetRegisterValue((ushort)IndexedScreenReg.Width, IndexedScreenRegPack.Width);
            }
        }

        /// <summary>
        /// Reads the <c>height</c> register value.
        /// Screen height in "natural" orientation., _: px
        /// </summary>
        public uint Height
        {
            get
            {
                return (uint)this.GetRegisterValue((ushort)IndexedScreenReg.Height, IndexedScreenRegPack.Height);
            }
        }

        /// <summary>
        /// Reads the <c>width_major</c> register value.
        /// If true, consecutive pixels in the "width" direction are sent next to each other (this is typical for graphics cards).
        /// If false, consecutive pixels in the "height" direction are sent next to each other.
        /// For embedded screen controllers, this is typically true iff `width < height`
        /// (in other words, it's only true for portrait orientation screens).
        /// Some controllers may allow the user to change this (though the refresh order may not be optimal then).
        /// This is independent of the `rotation` register., 
        /// </summary>
        public bool WidthMajor
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)IndexedScreenReg.WidthMajor, IndexedScreenRegPack.WidthMajor);
            }
            set
            {
                
                this.SetRegisterValue((ushort)IndexedScreenReg.WidthMajor, IndexedScreenRegPack.WidthMajor, value);
            }

        }

        /// <summary>
        /// Reads the <c>up_sampling</c> register value.
        /// Every pixel sent over wire is represented by `up_sampling x up_sampling` square of physical pixels.
        /// Some displays may allow changing this (which will also result in changes to `width` and `height`).
        /// Typical values are 1 and 2., _: px
        /// </summary>
        public uint UpSampling
        {
            get
            {
                return (uint)this.GetRegisterValue((ushort)IndexedScreenReg.UpSampling, IndexedScreenRegPack.UpSampling);
            }
            set
            {
                
                this.SetRegisterValue((ushort)IndexedScreenReg.UpSampling, IndexedScreenRegPack.UpSampling, value);
            }

        }

        /// <summary>
        /// Reads the <c>rotation</c> register value.
        /// Possible values are 0, 90, 180 and 270 only.
        /// Write to this register do not affect `width` and `height` registers,
        /// and may be ignored by some screens., _: °
        /// </summary>
        public uint Rotation
        {
            get
            {
                return (uint)this.GetRegisterValue((ushort)IndexedScreenReg.Rotation, IndexedScreenRegPack.Rotation);
            }
            set
            {
                
                this.SetRegisterValue((ushort)IndexedScreenReg.Rotation, IndexedScreenRegPack.Rotation, value);
            }

        }


        
        /// <summary>
        /// Sets the update window for subsequent `set_pixels` commands.
        /// </summary>
        public void StartUpdate(uint x, uint y, uint width, uint height)
        {
            this.SendCmdPacked((ushort)IndexedScreenCmd.StartUpdate, IndexedScreenCmdPack.StartUpdate, new object[] { x, y, width, height });
        }

        
        /// <summary>
        /// Set pixels in current window, according to current palette.
        /// Each "line" of data is aligned to a byte.
        /// </summary>
        public void SetPixels(byte[] pixels)
        {
            this.SendCmdPacked((ushort)IndexedScreenCmd.SetPixels, IndexedScreenCmdPack.SetPixels, new object[] { pixels });
        }

    }
}