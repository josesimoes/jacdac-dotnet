/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients {

    /// <summary>
    /// A record and replay module. You can record a few seconds of audio and play it back.
    /// Implements a client for the Sound Recorder with Playback service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/soundrecorderwithplayback/" />
    public partial class SoundRecorderWithPlaybackClient : Client
    {
        public SoundRecorderWithPlaybackClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.SoundRecorderWithPlayback)
        {
        }

        /// <summary>
        /// Reads the <c>status</c> register value.
        /// Indicate the current status, 
        /// </summary>
        public SoundRecorderWithPlaybackStatus Status
        {
            get
            {
                return (SoundRecorderWithPlaybackStatus)this.GetRegisterValue((ushort)SoundRecorderWithPlaybackReg.Status, SoundRecorderWithPlaybackRegPack.Status);
            }
        }

        /// <summary>
        /// Reads the <c>time</c> register value.
        /// Milliseconds of audio recorded., _: ms
        /// </summary>
        public uint Time
        {
            get
            {
                return (uint)this.GetRegisterValue((ushort)SoundRecorderWithPlaybackReg.Time, SoundRecorderWithPlaybackRegPack.Time);
            }
        }

        /// <summary>
        /// Tries to read the <c>volume</c> register value.
        /// Playback volume control, _: /
        /// </summary>
        bool TryGetVolume(out float value)
        {
            object[] values;
            if (this.TryGetRegisterValues((ushort)SoundRecorderWithPlaybackReg.Volume, SoundRecorderWithPlaybackRegPack.Volume, out values)) 
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
        /// Sets the volume value
        /// </summary>
        public void SetVolume(float value)
        {
            this.SetRegisterValue((ushort)SoundRecorderWithPlaybackReg.Volume, SoundRecorderWithPlaybackRegPack.Volume, value);
        }



        
        /// <summary>
        /// Replay recorded audio.
        /// </summary>
        public void Play()
        {
            this.SendCmd((ushort)SoundRecorderWithPlaybackCmd.Play);
        }

        
        /// <summary>
        /// Record audio for N milliseconds.
        /// </summary>
        public void Record(uint duration)
        {
            this.SendCmdPacked((ushort)SoundRecorderWithPlaybackCmd.Record, SoundRecorderWithPlaybackCmdPack.Record, new object[] { duration });
        }

        
        /// <summary>
        /// Cancel record, the `time` register will be updated by already cached data.
        /// </summary>
        public void Cancel()
        {
            this.SendCmd((ushort)SoundRecorderWithPlaybackCmd.Cancel);
        }

    }
}