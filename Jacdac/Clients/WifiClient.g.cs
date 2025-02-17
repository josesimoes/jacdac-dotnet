/** Autogenerated file. Do not edit. */
using Jacdac;
using System;

namespace Jacdac.Clients 
{
    /// <summary>
    /// Discovery and connection to WiFi networks. Separate TCP service can be used for data transfer.
    /// Implements a client for the WIFI service.
    /// </summary>
    /// <seealso cref="https://microsoft.github.io/jacdac-docs/services/wifi/" />
    public partial class WifiClient : Client
    {
        public WifiClient(JDBus bus, string name)
            : base(bus, name, ServiceClasses.Wifi)
        {
        }

        /// <summary>
        /// Reads the <c>enabled</c> register value.
        /// Determines whether the WiFi radio is enabled. It starts enabled upon reset., 
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (bool)this.GetRegisterValueAsBool((ushort)WifiReg.Enabled, WifiRegPack.Enabled);
            }
            set
            {
                
                this.SetRegisterValue((ushort)WifiReg.Enabled, WifiRegPack.Enabled, value);
            }

        }

        /// <summary>
        /// Reads the <c>ip_address</c> register value.
        /// 0, 4 or 16 byte buffer with the IPv4 or IPv6 address assigned to device if any., 
        /// </summary>
        public byte[] IpAddress
        {
            get
            {
                return (byte[])this.GetRegisterValue((ushort)WifiReg.IpAddress, WifiRegPack.IpAddress);
            }
        }

        /// <summary>
        /// Reads the <c>eui_48</c> register value.
        /// The 6-byte MAC address of the device. If a device does MAC address randomization it will have to "restart"., 
        /// </summary>
        public byte[] Eui48
        {
            get
            {
                return (byte[])this.GetRegisterValue((ushort)WifiReg.Eui48, WifiRegPack.Eui48);
            }
        }

        /// <summary>
        /// Reads the <c>ssid</c> register value.
        /// SSID of the access-point to which device is currently connected.
        /// Empty string if not connected., 
        /// </summary>
        public string Ssid
        {
            get
            {
                return (string)this.GetRegisterValue((ushort)WifiReg.Ssid, WifiRegPack.Ssid);
            }
        }

        /// <summary>
        /// Reads the <c>rssi</c> register value.
        /// Current signal strength. Returns -128 when not connected., _: dB
        /// </summary>
        public int Rssi
        {
            get
            {
                return (int)this.GetRegisterValue((ushort)WifiReg.Rssi, WifiRegPack.Rssi);
            }
        }

        /// <summary>
        /// Emitted upon successful join and IP address assignment.
        /// </summary>
        public event ClientEventHandler GotIp
        {
            add
            {
                this.AddEvent((ushort)WifiEvent.GotIp, value);
            }
            remove
            {
                this.RemoveEvent((ushort)WifiEvent.GotIp, value);
            }
        }

        /// <summary>
        /// Emitted when disconnected from network.
        /// </summary>
        public event ClientEventHandler LostIp
        {
            add
            {
                this.AddEvent((ushort)WifiEvent.LostIp, value);
            }
            remove
            {
                this.RemoveEvent((ushort)WifiEvent.LostIp, value);
            }
        }

        /// <summary>
        /// A WiFi network scan has completed. Results can be read with the `last_scan_results` command.
        /// The event indicates how many networks where found, and how many are considered
        /// as candidates for connection.
        /// </summary>
        public event ClientEventHandler ScanComplete
        {
            add
            {
                this.AddEvent((ushort)WifiEvent.ScanComplete, value);
            }
            remove
            {
                this.RemoveEvent((ushort)WifiEvent.ScanComplete, value);
            }
        }

        /// <summary>
        /// Emitted whenever the list of known networks is updated.
        /// </summary>
        public event ClientEventHandler NetworksChanged
        {
            add
            {
                this.AddEvent((ushort)WifiEvent.NetworksChanged, value);
            }
            remove
            {
                this.RemoveEvent((ushort)WifiEvent.NetworksChanged, value);
            }
        }

        /// <summary>
        /// Emitted when when a network was detected in scan, the device tried to connect to it
        /// and failed.
        /// This may be because of wrong password or other random failure.
        /// </summary>
        public event ClientEventHandler ConnectionFailed
        {
            add
            {
                this.AddEvent((ushort)WifiEvent.ConnectionFailed, value);
            }
            remove
            {
                this.RemoveEvent((ushort)WifiEvent.ConnectionFailed, value);
            }
        }


        
        /// <summary>
        /// Automatically connect to named network if available. Also set password if network is not open.
        /// </summary>
        public void AddNetwork(string ssid, string password)
        {
            this.SendCmdPacked((ushort)WifiCmd.AddNetwork, WifiCmdPack.AddNetwork, new object[] { ssid, password });
        }

        
        /// <summary>
        /// Enable the WiFi (if disabled), initiate a scan, wait for results, disconnect from current WiFi network if any,
        /// and then reconnect (using regular algorithm, see `set_network_priority`).
        /// </summary>
        public void Reconnect()
        {
            this.SendCmd((ushort)WifiCmd.Reconnect);
        }

        
        /// <summary>
        /// Prevent from automatically connecting to named network in future.
        /// Forgetting a network resets its priority to `0`.
        /// </summary>
        public void ForgetNetwork(string ssid)
        {
            this.SendCmdPacked((ushort)WifiCmd.ForgetNetwork, WifiCmdPack.ForgetNetwork, new object[] { ssid });
        }

        
        /// <summary>
        /// Clear the list of known networks.
        /// </summary>
        public void ForgetAllNetworks()
        {
            this.SendCmd((ushort)WifiCmd.ForgetAllNetworks);
        }

        
        /// <summary>
        /// Set connection priority for a network.
        /// By default, all known networks have priority of `0`.
        /// </summary>
        public void SetNetworkPriority(int priority, string ssid)
        {
            this.SendCmdPacked((ushort)WifiCmd.SetNetworkPriority, WifiCmdPack.SetNetworkPriority, new object[] { priority, ssid });
        }

        
        /// <summary>
        /// Initiate search for WiFi networks. Generates `scan_complete` event.
        /// </summary>
        public void Scan()
        {
            this.SendCmd((ushort)WifiCmd.Scan);
        }

    }
}