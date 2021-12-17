namespace Jacdac {
    // Service: Gamepad
    public static class GamepadConstants
    {
        public const uint ServiceClass = 0x108f7456;
    }

    [System.Flags]
    public enum GamepadButtons: uint { // uint32_t
        Left = 0x1,
        Up = 0x2,
        Right = 0x4,
        Down = 0x8,
        A = 0x10,
        B = 0x20,
        Menu = 0x40,
        Select = 0x80,
        Reset = 0x100,
        Exit = 0x200,
        X = 0x400,
        Y = 0x800,
    }


    public enum GamepadVariant: byte { // uint8_t
        Thumb = 0x1,
        ArcadeBall = 0x2,
        ArcadeStick = 0x3,
        Gamepad = 0x4,
    }

    public enum GamepadReg {
        /**
         * If the joystick is analog, the directional buttons should be "simulated", based on joystick position
         * (`Left` is `{ x = -1, y = 0 }`, `Up` is `{ x = 0, y = -1}`).
         * If the joystick is digital, then each direction will read as either `-1`, `0`, or `1` (in fixed representation).
         * The primary button on the joystick is `A`.
         *
         * ```
         * const [buttons, x, y] = jdunpack<[GamepadButtons, number, number]>(buf, "u32 i1.15 i1.15")
         * ```
         */
        Direction = 0x101,

        /**
         * Constant Variant (uint8_t). The type of physical joystick.
         *
         * ```
         * const [variant] = jdunpack<[GamepadVariant]>(buf, "u8")
         * ```
         */
        Variant = 0x107,

        /**
         * Constant Buttons (uint32_t). Indicates a bitmask of the buttons that are mounted on the joystick.
         * If the `Left`/`Up`/`Right`/`Down` buttons are marked as available here, the joystick is digital.
         * Even when marked as not available, they will still be simulated based on the analog joystick.
         *
         * ```
         * const [buttonsAvailable] = jdunpack<[GamepadButtons]>(buf, "u32")
         * ```
         */
        ButtonsAvailable = 0x180,
    }

    public static class GamepadRegPack {
        /**
         * Pack format for 'direction' register data.
         */
        public const string Direction = "u32 i1.15 i1.15";

        /**
         * Pack format for 'variant' register data.
         */
        public const string Variant = "u8";

        /**
         * Pack format for 'buttons_available' register data.
         */
        public const string ButtonsAvailable = "u32";
    }

    public enum GamepadEvent {
        /**
         * Argument: buttons Buttons (uint32_t). Emitted whenever the state of buttons changes.
         *
         * ```
         * const [buttons] = jdunpack<[GamepadButtons]>(buf, "u32")
         * ```
         */
        ButtonsChanged = 0x3,
    }

    public static class GamepadEventPack {
        /**
         * Pack format for 'buttons_changed' register data.
         */
        public const string ButtonsChanged = "u32";
    }

}
