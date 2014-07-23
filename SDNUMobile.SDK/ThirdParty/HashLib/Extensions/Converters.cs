using System;

namespace HashLib
{
    internal static class Converters
    {
        internal static void ConvertBytesToUIntsSwapOrder(Byte[] a_in, Int32 a_index, Int32 a_length, UInt32[] a_result, Int32 a_index_out)
        {
            for (Int32 i = a_index_out; a_length > 0; a_length -= 4)
            {
                a_result[i++] =
                    ((UInt32)a_in[a_index++] << 24) |
                    ((UInt32)a_in[a_index++] << 16) |
                    ((UInt32)a_in[a_index++] << 8) |
                    a_in[a_index++];
            }
        }

        internal static Byte[] ConvertUIntsToBytesSwapOrder(UInt32[] a_in, Int32 a_index = 0, Int32 a_length = -1)
        {
            if (a_length == -1)
                a_length = a_in.Length;

            Byte[]  result = new Byte[a_length * 4];

            for (Int32 j = 0; a_length > 0; a_length--, a_index++)
            {
                result[j++] = (Byte)(a_in[a_index] >> 24);
                result[j++] = (Byte)(a_in[a_index] >> 16);
                result[j++] = (Byte)(a_in[a_index] >> 8);
                result[j++] = (Byte)a_in[a_index];
            }

            return result;
        }

        internal static void ConvertULongToBytesSwapOrder(UInt64 a_in, Byte[] a_out, Int32 a_index)
        {
            a_out[a_index++] = (Byte)(a_in >> 56);
            a_out[a_index++] = (Byte)(a_in >> 48);
            a_out[a_index++] = (Byte)(a_in >> 40);
            a_out[a_index++] = (Byte)(a_in >> 32);
            a_out[a_index++] = (Byte)(a_in >> 24);
            a_out[a_index++] = (Byte)(a_in >> 16);
            a_out[a_index++] = (Byte)(a_in >> 8);
            a_out[a_index++] = (Byte)a_in;
        }

        internal static String ConvertBytesToHexString(Byte[] a_in, Boolean a_group = true)
        {
            String hex = BitConverter.ToString(a_in).ToUpper();

            if (a_group)
            {
                String[] ar = BitConverter.ToString(a_in).ToUpper().Split(new char[] { '-' });

                hex = "";

                for (Int32 i = 0; i < ar.Length / 4; i++)
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
    }
}