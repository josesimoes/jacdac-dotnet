﻿using System;
using System.IO;

namespace Jacdac
{
    public delegate TimeSpan Clock();
    public delegate Clock ClockFactory();
    public delegate ushort Crc16Calculator(byte[] p, int start, int size);
    public delegate short McuTemperatureCalculator();

    public static class Platform
    {
        public static byte[] DeviceId;
        public static string FirmwareVersion;
        public static string DeviceDescription;
        public static RealTimeClockVariant RealTimeClock = 0;
        public static ClockFactory CreateClock;
        public static Crc16Calculator Crc16 = (byte[] p, int start, int size) =>
        {
            ushort crc = 0xffff;
            for (var i = start; i < start + size; ++i)
            {
                var data = p[i];
                var x = (crc >> 8) ^ data;
                x ^= x >> 4;
                crc = (ushort)((crc << 8) ^ (x << 12) ^ (x << 5) ^ x);
                crc &= 0xffff;
            }
            return crc;
        };
        public static McuTemperatureCalculator McuTemperature;
        public static ServiceTwinSpecReader ServiceTwinReader;
        public static HttpWebRequestGet WebGet;
    }

    public interface IKeyStorage
    {
        string[] GetKeys();
        byte[] Read(string key);
        void Write(string key, byte[] buffer);
        void Delete(string key);
        void Clear();
    }

    public delegate byte[] HttpWebRequestGet(string url);
}
