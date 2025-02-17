﻿#region namespaces
using Jacdac;
using Jacdac.Clients;
using System.Threading;
#endregion

namespace Jacdac.Samples
{
    internal class SlidyBlinky : ISample
    {
        public void Run(JDBus bus)
        {
            #region sources
            var led = new LedClient(bus, "led");
            var slider = new PotentiometerClient(bus, "slider");
            var speed = 64u;
            led.Connected += (s, e) =>
            {
                while (led.IsConnected)
                {
                    // grab brightness
                    var brightness = (uint)(slider.Position * 100);
                    // blue
                    led.Animate(0, 0, brightness, speed);
                    Thread.Sleep(500);
                    // red
                    led.Animate(brightness, 0, 0, speed);
                    Thread.Sleep(500);
                }
            };
            #endregion
        }
    }
}
