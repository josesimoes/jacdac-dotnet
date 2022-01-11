/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A MIDI output device.
    /// Implements a client for the MIDI output service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/midioutput/" />
    public partial class MidiOutputClient : Client
    {
        public MidiOutputClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.MidiOutput)
        {
        }

        /// <summary>
        /// Reads the <c>enabled</c> register value.
        /// Opens or closes the port to the MIDI device, 
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)MidiOutputReg.Enabled, MidiOutputRegPack.Enabled);
            }
            set
            {
                
                this.SetRegisterValue((ushort)MidiOutputReg.Enabled, MidiOutputRegPack.Enabled, value);
            }

        }


        
        /// <summary>
        /// Clears any pending send data that has not yet been sent from the MIDIOutput's queue.
        /// </summary>
        public void Clear()
        {
            this.SendCmd((ushort)MidiOutputCmd.Clear);
        }

        
        /// <summary>
        /// Enqueues the message to be sent to the corresponding MIDI port
        /// </summary>
        public void Send(byte[] data)
        {
            this.SendCmdPacked((ushort)MidiOutputCmd.Send, MidiOutputCmdPack.Send, new object[] { data });
        }

    }
}