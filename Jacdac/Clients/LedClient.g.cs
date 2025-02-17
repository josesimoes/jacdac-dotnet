/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A controller for 1 or more monochrome or RGB LEDs connected in parallel.
    /// Implements a client for the LED service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/led/" />
    public partial class LedClient : Client
    {
        public LedClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Led)
        {
        }

        /// <summary>
        /// Reads the <c>color</c> register value.
        /// The current color of the LED., 
        /// </summary>
        public object[] /*(uint, uint, uint)*/ Color
        {
            get
            {
                return (object[] /*(uint, uint, uint)*/)this.GetRegisterValues((ushort)LedReg.Color, LedRegPack.Color);
            }
        }

        /// <summary>
        /// Tries to read the <c>max_power</c> register value.
        /// Limit the power drawn by the light-strip (and controller)., _: mA
        /// </summary>
        bool TryGetMaxPower(out uint value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LedReg.MaxPower, LedRegPack.MaxPower, out values)) 
            {
                value = (uint)values[0];
                return true;
            }
            else
            {
                value = default(uint);
                return false;
            }
        }
        
        /// <summary>
        /// Sets the max_power value
        /// </summary>
        public void SetMaxPower(uint value)
        {
            this.SetRegisterValue((ushort)LedReg.MaxPower, LedRegPack.MaxPower, value);
        }


        /// <summary>
        /// Tries to read the <c>led_count</c> register value.
        /// If known, specifies the number of LEDs in parallel on this device., 
        /// </summary>
        bool TryGetLedCount(out uint value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LedReg.LedCount, LedRegPack.LedCount, out values)) 
            {
                value = (uint)values[0];
                return true;
            }
            else
            {
                value = default(uint);
                return false;
            }
        }

        /// <summary>
        /// Tries to read the <c>wave_length</c> register value.
        /// If monochrome LED, specifies the wave length of the LED., _: nm
        /// </summary>
        bool TryGetWaveLength(out uint value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LedReg.WaveLength, LedRegPack.WaveLength, out values)) 
            {
                value = (uint)values[0];
                return true;
            }
            else
            {
                value = default(uint);
                return false;
            }
        }

        /// <summary>
        /// Tries to read the <c>luminous_intensity</c> register value.
        /// The luminous intensity of the LED, at full value, in micro candella., _: mcd
        /// </summary>
        bool TryGetLuminousIntensity(out uint value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LedReg.LuminousIntensity, LedRegPack.LuminousIntensity, out values)) 
            {
                value = (uint)values[0];
                return true;
            }
            else
            {
                value = default(uint);
                return false;
            }
        }

        /// <summary>
        /// Tries to read the <c>variant</c> register value.
        /// The physical type of LED., 
        /// </summary>
        bool TryGetVariant(out LedVariant value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LedReg.Variant, LedRegPack.Variant, out values)) 
            {
                value = (LedVariant)values[0];
                return true;
            }
            else
            {
                value = default(LedVariant);
                return false;
            }
        }


        
        /// <summary>
        /// This has the same semantics as `set_status_light` in the control service.
        /// </summary>
        public void Animate(uint to_red, uint to_green, uint to_blue, uint speed)
        {
            this.SendCmdPacked((ushort)LedCmd.Animate, LedCmdPack.Animate, new object[] { to_red, to_green, to_blue, speed });
        }

    }
}