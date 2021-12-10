using System;
using System.Runtime.CompilerServices;

namespace Jacdac
{
    internal enum NumberFormat
    {
        Unknown = 0,
        Int8LE = 1,
        UInt8LE = 2,
        Int16LE = 3,
        UInt16LE = 4,
        Int32LE = 5,
        Int8BE = 6,
        UInt8BE = 7,
        Int16BE = 8,
        UInt16BE = 9,
        Int32BE = 10,
        UInt32LE = 11,
        UInt32BE = 12,
        Float32LE = 13,
        Float64LE = 14,
        Float32BE = 15,
        Float64BE = 16,
        UInt64LE = 17,
        UInt64BE = 18,
        Int64LE = 19,
        Int64BE = 20,
    }
    internal static class Util
    {
        public static byte[] Slice(byte[] source, int start, int end = 0)
        {
            if (start < 0)
            {
                start = source.Length + start;
            }

            if (end == 0)
            {

                var dest = new byte[source.Length - start];

                Array.Copy(source, start, dest, 0, dest.Length);

                return dest;

            }
            else
            {
                if (end > 0)
                {
                    var length = end - start;

                    var dest = new byte[length];

                    Array.Copy(source, start, dest, 0, dest.Length);

                    return dest;
                }
                else
                {
                    end = source.Length + end;

                    var length = end - start;

                    var dest = new byte[length];

                    Array.Copy(source, start, dest, 0, dest.Length);

                    return dest;
                }
            }
        }

        public static void Set(byte[] dest, byte[] source, int start)
        {
            var i1 = 0;

            for (var i2 = start; i1 < source.Length;)
            {

                dest[i2] = source[i1];
                i1++;
            }
        }

        public static byte[] BufferConcat(byte[] a, byte[] b)
        {
            var r = new byte[a.Length + b.Length];

            Array.Copy(a, 0, r, 0, a.Length);
            Array.Copy(b, 0, r, a.Length, b.Length);

            return r;
        }

        public static string ToHex(byte[] data)
        {
            var hex = "";
            for (var i = 0; i < data.Length; i++)
            {
                hex += data[i].ToString("x2");
            }

            return hex;

        }

        public static byte[] FromHex(string hex)
        {
            var data = new byte[hex.Length / 2];

            for (var i = 0; i < hex.Length; i += 2)
            {
                var sub = hex.Substring(i, 2);
                data[i >> 1] = (byte)Convert.ToInt32(sub, 16);
            }

            return data;

        }

        public static ushort Read16(byte[] data, int pos) => BitConverter.ToUInt16(data, pos);

        public static uint Read32(byte[] data, int pos) => BitConverter.ToUInt32(data, pos);

        public static void Write16(byte[] data, int pos, ushort v)
        {
            data[pos + 0] = (byte)((v >> 0) & 0xff);
            data[pos + 1] = (byte)((v >> 8) & 0xff);
        }

        public static object GetNumber(byte[] buf, NumberFormat fmt, int offset)
        {
            switch (fmt)
            {
                case NumberFormat.UInt8BE:
                case NumberFormat.UInt8LE:
                    return buf[offset];

                case NumberFormat.Int8BE:
                case NumberFormat.Int8LE:
                    return (uint)(buf[offset] << 24) >> 24;

                case NumberFormat.UInt16LE:
                    return Read16(buf, offset);

                case NumberFormat.Int16LE:
                    return (uint)(Read16(buf, offset) << 16) >> 16;

                case NumberFormat.UInt32LE:
                    return Read32(buf, offset);

                case NumberFormat.Int32LE:
                    return Read32(buf, offset) >> 0;

                default:
                    throw new Exception("unsupported fmt:" + fmt);
            }
        }

        public static int SizeOfNumberFormat(NumberFormat format)
        {
            switch (format)
            {
                case NumberFormat.Int8LE:
                case NumberFormat.UInt8LE:
                case NumberFormat.Int8BE:
                case NumberFormat.UInt8BE:
                    return 1;
                case NumberFormat.Int16LE:
                case NumberFormat.UInt16LE:
                case NumberFormat.Int16BE:
                case NumberFormat.UInt16BE:
                    return 2;
                case NumberFormat.Int32LE:
                case NumberFormat.Int32BE:
                case NumberFormat.UInt32BE:
                case NumberFormat.UInt32LE:
                case NumberFormat.Float32BE:
                case NumberFormat.Float32LE:
                    return 4;
                case NumberFormat.UInt64BE:
                case NumberFormat.Int64BE:
                case NumberFormat.UInt64LE:
                case NumberFormat.Int64LE:
                case NumberFormat.Float64BE:
                case NumberFormat.Float64LE:
                    return 8;
            }
            return 0;
        }
        public static NumberFormat NumberFormatOfType(string tp)
        {
            switch (tp)
            {
                case "u8":
                    return NumberFormat.UInt8LE;
                case "u16":
                    return NumberFormat.UInt16LE;
                case "u32":
                    return NumberFormat.UInt32LE;
                case "i8":
                    return NumberFormat.Int8LE;
                case "i16":
                    return NumberFormat.Int16LE;
                case "i32":
                    return NumberFormat.Int32LE;
                case "f32":
                    return NumberFormat.Float32LE;
                case "f64":
                    return NumberFormat.Float64LE;
                case "i64":
                    return NumberFormat.Int64LE;
                case "u64":
                    return NumberFormat.UInt64LE;
                default:
                    return NumberFormat.Unknown;
            }
        }

        public static ushort CRC(byte[] p) => CRC(p, 0, p.Length);

        public static ushort CRC(byte[] p, int start, int size) => Platform.Crc16(p, start, size);
    }
}
