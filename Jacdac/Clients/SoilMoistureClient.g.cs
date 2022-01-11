/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A soil moisture sensor.
    /// Implements a client for the Soil moisture service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/soilmoisture/" />
    public partial class SoilMoistureClient : SensorClient
    {
        public SoilMoistureClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.SoilMoisture)
        {
        }

        /// <summary>
        /// Reads the <c>moisture</c> register value.
        /// Indicates the wetness of the soil, from `dry` to `wet`., _: /
        /// </summary>
        public float Moisture
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)SoilMoistureReg.Moisture, SoilMoistureRegPack.Moisture);
            }
        }

        /// <summary>
        /// Tries to read the <c>moisture_error</c> register value.
        /// The error on the moisture reading., _: /
        /// </summary>
        bool TryGetMoistureError(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)SoilMoistureReg.MoistureError, SoilMoistureRegPack.MoistureError, out values)) 
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
        /// Describe the type of physical sensor., 
        /// </summary>
        bool TryGetVariant(out SoilMoistureVariant value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)SoilMoistureReg.Variant, SoilMoistureRegPack.Variant, out values)) 
            {
                value = (SoilMoistureVariant)values[0];
                return true;
            }
            else
            {
                value = default(SoilMoistureVariant);
                return false;
            }
        }


    }
}