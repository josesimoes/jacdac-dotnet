/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A sensor measuring air pressure of outside environment.
    /// Implements a client for the Barometer service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/barometer/" />
    public partial class BarometerClient : SensorClient
    {
        public BarometerClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Barometer)
        {
        }

        /// <summary>
        /// Reads the <c>pressure</c> register value.
        /// The air pressure., _: hPa
        /// </summary>
        public float Pressure
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)BarometerReg.Pressure, BarometerRegPack.Pressure);
            }
        }

        /// <summary>
        /// Tries to read the <c>pressure_error</c> register value.
        /// The real pressure is between `pressure - pressure_error` and `pressure + pressure_error`., _: hPa
        /// </summary>
        bool TryGetPressureError(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)BarometerReg.PressureError, BarometerRegPack.PressureError, out values)) 
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


    }
}