/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A two axis directional joystick with optional buttons.
    /// Implements a client for the Gamepad service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/gamepad/" />
    public partial class GamepadClient : SensorClient
    {
        public GamepadClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Gamepad)
        {
        }

        /// <summary>
        /// Reads the <c>direction</c> register value.
        /// If the joystick is analog, the directional buttons should be "simulated", based on joystick position
        /// (`Left` is `{ x = -1, y = 0 }`, `Up` is `{ x = 0, y = -1}`).
        /// If the joystick is digital, then each direction will read as either `-1`, `0`, or `1` (in fixed representation).
        /// The primary button on the joystick is `A`., x: /,y: /
        /// </summary>
        public object[] /*(GamepadButtons, float, float)*/ Direction
        {
            get
            {
                return (object[] /*(GamepadButtons, float, float)*/)this.GetRegisterValues((ushort)GamepadReg.Direction, GamepadRegPack.Direction);
            }
        }

        /// <summary>
        /// Tries to read the <c>variant</c> register value.
        /// The type of physical joystick., 
        /// </summary>
        bool TryGetVariant(out GamepadVariant value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)GamepadReg.Variant, GamepadRegPack.Variant, out values)) 
            {
                value = (GamepadVariant)values[0];
                return true;
            }
            else
            {
                value = default(GamepadVariant);
                return false;
            }
        }

        /// <summary>
        /// Reads the <c>buttons_available</c> register value.
        /// Indicates a bitmask of the buttons that are mounted on the joystick.
        /// If the `Left`/`Up`/`Right`/`Down` buttons are marked as available here, the joystick is digital.
        /// Even when marked as not available, they will still be simulated based on the analog joystick., 
        /// </summary>
        public GamepadButtons ButtonsAvailable
        {
            get
            {
                return (GamepadButtons)this.GetRegisterValue((ushort)GamepadReg.ButtonsAvailable, GamepadRegPack.ButtonsAvailable);
            }
        }

        /// <summary>
        /// Emitted whenever the state of buttons changes.
        /// </summary>
        public event ClientEventHandler ButtonsChanged
        {
            add
            {
                this.AddEvent((ushort)GamepadEvent.ButtonsChanged, value);
            }
            remove
            {
                this.RemoveEvent((ushort)GamepadEvent.ButtonsChanged, value);
            }
        }


    }
}