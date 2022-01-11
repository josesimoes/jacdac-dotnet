/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A thermometer measuring outside or inside environment.
    /// Implements a client for the Temperature service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/temperature/" />
    public partial class TemperatureClient : SensorClient
    {
        public TemperatureClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Temperature)
        {
        }

        /// <summary>
        /// Reads the <c>temperature</c> register value.
        /// The temperature., _: °C
        /// </summary>
        public float Temperature
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)TemperatureReg.Temperature, TemperatureRegPack.Temperature);
            }
        }

        /// <summary>
        /// Reads the <c>min_temperature</c> register value.
        /// Lowest temperature that can be reported., _: °C
        /// </summary>
        public float MinTemperature
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)TemperatureReg.MinTemperature, TemperatureRegPack.MinTemperature);
            }
        }

        /// <summary>
        /// Reads the <c>max_temperature</c> register value.
        /// Highest temperature that can be reported., _: °C
        /// </summary>
        public float MaxTemperature
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)TemperatureReg.MaxTemperature, TemperatureRegPack.MaxTemperature);
            }
        }

        /// <summary>
        /// Tries to read the <c>temperature_error</c> register value.
        /// The real temperature is between `temperature - temperature_error` and `temperature + temperature_error`., _: °C
        /// </summary>
        bool TryGetTemperatureError(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)TemperatureReg.TemperatureError, TemperatureRegPack.TemperatureError, out values)) 
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
        /// Specifies the type of thermometer., 
        /// </summary>
        bool TryGetVariant(out TemperatureVariant value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)TemperatureReg.Variant, TemperatureRegPack.Variant, out values)) 
            {
                value = (TemperatureVariant)values[0];
                return true;
            }
            else
            {
                value = default(TemperatureVariant);
                return false;
            }
        }


    }
}