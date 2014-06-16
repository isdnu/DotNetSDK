using System;
using System.Diagnostics;

namespace HashLib
{
    public static class Converters
    {
        public static void ConvertBytesToUIntsSwapOrder(byte[] a_in, int a_index, int a_length, uint[] a_result, int a_index_out)
        {
            Check(a_in, 1, a_result, 4, a_index, a_length, a_index_out);

            for (int i = a_index_out; a_length > 0; a_length -= 4)
            {
                a_result[i++] =
                    ((uint)a_in[a_index++] << 24) |
                    ((uint)a_in[a_index++] << 16) |
                    ((uint)a_in[a_index++] << 8) |
                    a_in[a_index++];
            }
        }

        public static byte[] ConvertUIntsToBytesSwapOrder(uint[] a_in, int a_index = 0, int a_length = -1)
        {
            if (a_length == -1)
                a_length = a_in.Length;

            Check(a_in, 4, 1, a_index, a_length);

            byte[] result = new byte[a_length * 4];

            for (int j = 0; a_length > 0; a_length--, a_index++)
            {
                result[j++] = (byte)(a_in[a_index] >> 24);
                result[j++] = (byte)(a_in[a_index] >> 16);
                result[j++] = (byte)(a_in[a_index] >> 8);
                result[j++] = (byte)a_in[a_index];
            }

            return result;
        }

        public static void ConvertULongToBytesSwapOrder(ulong a_in, byte[] a_out, int a_index)
        {
            Debug.Assert(a_index + 8 <= a_out.Length);

            a_out[a_index++] = (byte)(a_in >> 56);
            a_out[a_index++] = (byte)(a_in >> 48);
            a_out[a_index++] = (byte)(a_in >> 40);
            a_out[a_index++] = (byte)(a_in >> 32);
            a_out[a_index++] = (byte)(a_in >> 24);
            a_out[a_index++] = (byte)(a_in >> 16);
            a_out[a_index++] = (byte)(a_in >> 8);
            a_out[a_index++] = (byte)a_in;
        }

        public static string ConvertBytesToHexString(byte[] a_in, bool a_group = true)
        {
            string hex = BitConverter.ToString(a_in).ToUpper();

            if (a_group)
            {
                Check(a_in, 1, 4);

                string[] ar = BitConverter.ToString(a_in).ToUpper().Split(new char[] { '-' });

                hex = "";

                for (int i = 0; i < ar.Length / 4; i++)
                {
                    if (i != 0)
                        hex += "-";
                    hex += ar[i * 4] + ar[i * 4 + 1] + ar[i * 4 + 2] + ar[i * 4 + 3];
                }
            }
            else
                hex = hex.Replace("-", "");

            return hex;
        }

        [Conditional("DEBUG")]
        private static void Check<I>(I[] a_in, int a_in_size, int a_out_size)
        {
            Debug.Assert((a_in.Length * a_in_size % a_out_size) == 0);
        }

        [Conditional("DEBUG")]
        private static void Check<I>(I[] a_in, int a_in_size, int a_out_size, int a_index, int a_length)
        {
            Debug.Assert((a_length * a_in_size % a_out_size) == 0);

            if (a_out_size > a_in_size)
                Debug.Assert((a_length % (a_out_size / a_in_size)) == 0);
            else
                Debug.Assert(a_in_size % a_out_size == 0);

            Debug.Assert(a_index >= 0);

            if (a_length > 0)
                Debug.Assert(a_index < a_in.Length);

            Debug.Assert(a_length >= 0);
            Debug.Assert(a_index + a_length <= a_in.Length);
            Debug.Assert(a_index + a_length <= a_in.Length);
        }

        [Conditional("DEBUG")]
        private static void Check<I, O>(I[] a_in, int a_in_size, O[] a_result, int a_out_size, int a_index_in, int a_length, 
            int a_index_out)
        {
            Debug.Assert((a_length * a_in_size % a_out_size) == 0);

            if (a_out_size > a_in_size)
                Debug.Assert((a_length % (a_out_size / a_in_size)) == 0);

            Debug.Assert(a_index_in >= 0);

            if (a_length > 0)
                Debug.Assert(a_index_in < a_in.Length);

            Debug.Assert(a_length >= 0);
            Debug.Assert(a_index_in + a_length <= a_in.Length);
            Debug.Assert(a_index_in + a_length <= a_in.Length);

            Debug.Assert(a_index_out + a_result.Length >= (a_length / a_out_size));
        }
    }
}