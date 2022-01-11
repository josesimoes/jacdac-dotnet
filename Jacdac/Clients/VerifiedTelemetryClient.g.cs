/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A mixin service that exposes verified telemetry information for a sensor (see https://github.com/Azure/Verified-Telemetry/tree/main/PnPModel).
    /// Implements a client for the Verified Telemetry service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/verifiedtelemetrysensor/" />
    public partial class VerifiedTelemetryClient : Client
    {
        public VerifiedTelemetryClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.VerifiedTelemetry)
        {
        }

        /// <summary>
        /// Reads the <c>telemetry_status</c> register value.
        /// Reads the telemetry working status, where ``true`` is working and ``false`` is faulty., 
        /// </summary>
        public VerifiedTelemetryStatus TelemetryStatus
        {
            get
            {
                return (VerifiedTelemetryStatus)this.GetRegisterValue((ushort)VerifiedTelemetryReg.TelemetryStatus, VerifiedTelemetryRegPack.TelemetryStatus);
            }
        }

        /// <summary>
        /// Tries to read the <c>telemetry_status_interval</c> register value.
        /// Specifies the interval between computing the fingerprint information., _: ms
        /// </summary>
        bool TryGetTelemetryStatusInterval(out uint value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)VerifiedTelemetryReg.TelemetryStatusInterval, VerifiedTelemetryRegPack.TelemetryStatusInterval, out values)) 
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
        /// Sets the telemetry_status_interval value
        /// </summary>
        public void SetTelemetryStatusInterval(uint value)
        {
            this.SetRegisterValue((ushort)VerifiedTelemetryReg.TelemetryStatusInterval, VerifiedTelemetryRegPack.TelemetryStatusInterval, value);
        }


        /// <summary>
        /// Reads the <c>fingerprint_type</c> register value.
        /// Type of the fingerprint., 
        /// </summary>
        public VerifiedTelemetryFingerprintType FingerprintType
        {
            get
            {
                return (VerifiedTelemetryFingerprintType)this.GetRegisterValue((ushort)VerifiedTelemetryReg.FingerprintType, VerifiedTelemetryRegPack.FingerprintType);
            }
        }

        /// <summary>
        /// Reads the <c>fingerprint_template</c> register value.
        /// Template Fingerprint information of a working sensor., confidence: %
        /// </summary>
        public object[] /*(uint, byte[])*/ FingerprintTemplate
        {
            get
            {
                return (object[] /*(uint, byte[])*/)this.GetRegisterValues((ushort)VerifiedTelemetryReg.FingerprintTemplate, VerifiedTelemetryRegPack.FingerprintTemplate);
            }
        }

        /// <summary>
        /// The telemetry status of the device was updated.
        /// </summary>
        public event ClientEventHandler TelemetryStatusChange
        {
            add
            {
                this.AddEvent((ushort)VerifiedTelemetryEvent.TelemetryStatusChange, value);
            }
            remove
            {
                this.RemoveEvent((ushort)VerifiedTelemetryEvent.TelemetryStatusChange, value);
            }
        }

        /// <summary>
        /// The fingerprint template was updated
        /// </summary>
        public event ClientEventHandler FingerprintTemplateChange
        {
            add
            {
                this.AddEvent((ushort)VerifiedTelemetryEvent.FingerprintTemplateChange, value);
            }
            remove
            {
                this.RemoveEvent((ushort)VerifiedTelemetryEvent.FingerprintTemplateChange, value);
            }
        }


        
        /// <summary>
        /// This command will clear the template fingerprint of a sensor and collect a new template fingerprint of the attached sensor.
        /// </summary>
        public void ResetFingerprintTemplate()
        {
            this.SendCmd((ushort)VerifiedTelemetryCmd.ResetFingerprintTemplate);
        }

        
        /// <summary>
        /// This command will append a new template fingerprint to the `fingerprintTemplate`. Appending more fingerprints will increase the accuracy in detecting the telemetry status.
        /// </summary>
        public void RetrainFingerprintTemplate()
        {
            this.SendCmd((ushort)VerifiedTelemetryCmd.RetrainFingerprintTemplate);
        }

    }
}