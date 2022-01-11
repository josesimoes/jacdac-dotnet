/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// Controls a mini traffic with a red, orange and green LED.
    /// Implements a client for the Traffic Light service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/trafficlight/" />
    public partial class TrafficLightClient : Client
    {
        public TrafficLightClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.TrafficLight)
        {
        }

        /// <summary>
        /// Reads the <c>red</c> register value.
        /// The on/off state of the red light., 
        /// </summary>
        public bool Red
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)TrafficLightReg.Red, TrafficLightRegPack.Red);
            }
            set
            {
                
                this.SetRegisterValue((ushort)TrafficLightReg.Red, TrafficLightRegPack.Red, value);
            }

        }

        /// <summary>
        /// Reads the <c>orange</c> register value.
        /// The on/off state of the red light., 
        /// </summary>
        public bool Orange
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)TrafficLightReg.Orange, TrafficLightRegPack.Orange);
            }
            set
            {
                
                this.SetRegisterValue((ushort)TrafficLightReg.Orange, TrafficLightRegPack.Orange, value);
            }

        }

        /// <summary>
        /// Reads the <c>green</c> register value.
        /// The on/off state of the red light., 
        /// </summary>
        public bool Green
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)TrafficLightReg.Green, TrafficLightRegPack.Green);
            }
            set
            {
                
                this.SetRegisterValue((ushort)TrafficLightReg.Green, TrafficLightRegPack.Green, value);
            }

        }


    }
}