/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A switch, which keeps its position.
    /// Implements a client for the Switch service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/switch/" />
    public partial class SwitchClient : SensorClient
    {
        public SwitchClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Switch)
        {
        }

        /// <summary>
        /// Reads the <c>active</c> register value.
        /// Indicates whether the switch is currently active (on)., 
        /// </summary>
        public bool Active
        {
            get
            {
                return (bool)this.GetRegisterValueAsBool((ushort)SwitchReg.Active, SwitchRegPack.Active);
            }
        }

        /// <summary>
        /// Tries to read the <c>variant</c> register value.
        /// Describes the type of switch used., 
        /// </summary>
        bool TryGetVariant(out SwitchVariant value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)SwitchReg.Variant, SwitchRegPack.Variant, out values)) 
            {
                value = (SwitchVariant)values[0];
                return true;
            }
            else
            {
                value = default(SwitchVariant);
                return false;
            }
        }

        /// <summary>
        /// Tries to read the <c>auto_off_delay</c> register value.
        /// Specifies the delay without activity to automatically turn off after turning on.
        /// For example, some light switches in staircases have such a capability., _: s
        /// </summary>
        bool TryGetAutoOffDelay(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)SwitchReg.AutoOffDelay, SwitchRegPack.AutoOffDelay, out values)) 
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
        /// Emitted when switch goes from `off` to `on`.
        /// </summary>
        public event ClientEventHandler On
        {
            add
            {
                this.AddEvent((ushort)SwitchEvent.On, value);
            }
            remove
            {
                this.RemoveEvent((ushort)SwitchEvent.On, value);
            }
        }

        /// <summary>
        /// Emitted when switch goes from `on` to `off`.
        /// </summary>
        public event ClientEventHandler Off
        {
            add
            {
                this.AddEvent((ushort)SwitchEvent.Off, value);
            }
            remove
            {
                this.RemoveEvent((ushort)SwitchEvent.Off, value);
            }
        }


    }
}