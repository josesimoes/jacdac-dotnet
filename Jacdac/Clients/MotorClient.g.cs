/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A DC motor.
    /// Implements a client for the Motor service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/motor/" />
    public partial class MotorClient : Client
    {
        public MotorClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Motor)
        {
        }

        /// <summary>
        /// Reads the <c>duty</c> register value.
        /// PWM duty cycle of the motor. Use negative/positive values to run the motor forwards and backwards.
        /// Positive is recommended to be clockwise rotation and negative counterclockwise. A duty of ``0`` 
        /// while ``enabled`` acts as brake., _: /
        /// </summary>
        public float Duty
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)MotorReg.Duty, MotorRegPack.Duty);
            }
            set
            {
                
                this.Enabled = true;
                this.SetRegisterValue((ushort)MotorReg.Duty, MotorRegPack.Duty, value);
            }

        }

        /// <summary>
        /// Reads the <c>enabled</c> register value.
        /// Turn the power to the motor on/off., 
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)MotorReg.Enabled, MotorRegPack.Enabled);
            }
            set
            {
                
                this.SetRegisterValue((ushort)MotorReg.Enabled, MotorRegPack.Enabled, value);
            }

        }

        /// <summary>
        /// Tries to read the <c>load_torque</c> register value.
        /// Torque required to produce the rated power of an electrical motor at load speed., _: kg/cm
        /// </summary>
        bool TryGetLoadTorque(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)MotorReg.LoadTorque, MotorRegPack.LoadTorque, out values)) 
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
        /// Tries to read the <c>load_speed</c> register value.
        /// Revolutions per minute of the motor under full load., _: rpm
        /// </summary>
        bool TryGetLoadSpeed(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)MotorReg.LoadSpeed, MotorRegPack.LoadSpeed, out values)) 
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
        /// Tries to read the <c>reversible</c> register value.
        /// Indicates if the motor can run backwards., 
        /// </summary>
        bool TryGetReversible(out bool value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)MotorReg.Reversible, MotorRegPack.Reversible, out values)) 
            {
                value = (bool)values[0];
                return true;
            }
            else
            {
                value = default(bool);
                return false;
            }
        }


    }
}