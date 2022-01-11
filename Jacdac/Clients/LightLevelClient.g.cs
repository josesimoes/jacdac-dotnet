/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A sensor that measures luminosity level.
    /// Implements a client for the Light level service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/lightlevel/" />
    public partial class LightLevelClient : SensorClient
    {
        public LightLevelClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.LightLevel)
        {
        }

        /// <summary>
        /// Reads the <c>light_level</c> register value.
        /// Detect light level, _: /
        /// </summary>
        public float LightLevel
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)LightLevelReg.LightLevel, LightLevelRegPack.LightLevel);
            }
        }

        /// <summary>
        /// Tries to read the <c>light_level_error</c> register value.
        /// Absolute estimated error of the reading value, _: /
        /// </summary>
        bool TryGetLightLevelError(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LightLevelReg.LightLevelError, LightLevelRegPack.LightLevelError, out values)) 
            {
                value = (float)values[0];
                return true;
            }
            else
            {
                value = default(float);
                return false;
            }
        }

        /// <summary>
        /// Tries to read the <c>variant</c> register value.
        /// The type of physical sensor., 
        /// </summary>
        bool TryGetVariant(out LightLevelVariant value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)LightLevelReg.Variant, LightLevelRegPack.Variant, out values)) 
            {
                value = (LightLevelVariant)values[0];
                return true;
            }
            else
            {
                value = default(LightLevelVariant);
                return false;
            }
        }


    }
}