/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// A device that reads various barcodes, like QR codes. For the web, see [BarcodeDetector](https://developer.mozilla.org/en-US/docs/Web/API/BarcodeDetector).
    /// Implements a client for the Barcode reader service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/barcodereader/" />
    public partial class BarcodeReaderClient : Client
    {
        public BarcodeReaderClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.BarcodeReader)
        {
        }

        /// <summary>
        /// Reads the <c>enabled</c> register value.
        /// Turns on or off the detection of barcodes., 
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (bool)this.GetRegisterValue((ushort)BarcodeReaderReg.Enabled, BarcodeReaderRegPack.Enabled);
            }
            set
            {
                
                this.SetRegisterValue((ushort)BarcodeReaderReg.Enabled, BarcodeReaderRegPack.Enabled, value);
            }

        }

        /// <summary>
        /// Raised when a bar code is detected and decoded. If the reader detects multiple codes, it will issue multiple events.
        /// In case of numeric barcodes, the `data` field should contain the ASCII (which is the same as UTF8 in that case) representation of the number.
        /// </summary>
        public event ClientEventHandler Detect
        {
            add
            {
                this.AddEvent((ushort)BarcodeReaderEvent.Detect, value);
            }
            remove
            {
                this.RemoveEvent((ushort)BarcodeReaderEvent.Detect, value);
            }
        }


    }
}