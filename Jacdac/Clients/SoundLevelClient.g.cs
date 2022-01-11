/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A sound level detector sensor, gives a relative indication of the sound level.
    /// Implements a client for the Sound level service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/soundlevel/" />
    public partial class SoundLevelClient : SensorClient
    {
        public SoundLevelClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.SoundLevel)
        {
        }

        /// <summary>
        /// Reads the <c>sound_level</c> register value.
        /// The sound level detected by the microphone, _: /
        /// </summary>
        public float SoundLevel
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)SoundLevelReg.SoundLevel, SoundLevelRegPack.SoundLevel);
            }
        }

        /// <summary>
        /// Reads the <c>enabled</c> register value.
        /// Turn on or off the microphone., 
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)SoundLevelReg.Enabled, SoundLevelRegPack.Enabled);
            }
            set
            {
                
                this.SetRegisterValue((ushort)SoundLevelReg.Enabled, SoundLevelRegPack.Enabled, value);
            }

        }

        /// <summary>
        /// Reads the <c>loud_threshold</c> register value.
        /// The sound level to trigger a loud event., _: /
        /// </summary>
        public float LoudThreshold
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)SoundLevelReg.LoudThreshold, SoundLevelRegPack.LoudThreshold);
            }
            set
            {
                
                this.SetRegisterValue((ushort)SoundLevelReg.LoudThreshold, SoundLevelRegPack.LoudThreshold, value);
            }

        }

        /// <summary>
        /// Reads the <c>quiet_threshold</c> register value.
        /// The sound level to trigger a quiet event., _: /
        /// </summary>
        public float QuietThreshold
        {
            get
            {
                return (float)this.GetRegisterValue((ushort)SoundLevelReg.QuietThreshold, SoundLevelRegPack.QuietThreshold);
            }
            set
            {
                
                this.SetRegisterValue((ushort)SoundLevelReg.QuietThreshold, SoundLevelRegPack.QuietThreshold, value);
            }

        }

        /// <summary>
        /// Raised when a loud sound is detected
        /// </summary>
        public event ClientEventHandler Loud
        {
            add
            {
                this.AddEvent((ushort)SoundLevelEvent.Loud, value);
            }
            remove
            {
                this.RemoveEvent((ushort)SoundLevelEvent.Loud, value);
            }
        }

        /// <summary>
        /// Raised when a period of quietness is detected
        /// </summary>
        public event ClientEventHandler Quiet
        {
            add
            {
                this.AddEvent((ushort)SoundLevelEvent.Quiet, value);
            }
            remove
            {
                this.RemoveEvent((ushort)SoundLevelEvent.Quiet, value);
            }
        }


    }
}