using System;

namespace HashLib
{
    public class HashResult
    {
        private Byte[]  m_hash;

        public HashResult(UInt32 a_hash)
        {
            m_hash = BitConverter.GetBytes(a_hash);
        }

        internal HashResult(Int32 a_hash)
        {
            m_hash = BitConverter.GetBytes(a_hash);
        }

        public HashResult(UInt64 a_hash)
        {
            m_hash = BitConverter.GetBytes(a_hash);
        }
        public HashResult(Byte[]  a_hash)
        {
            m_hash = a_hash;
        }

        public Byte[] GetBytes()
        {
            Byte[] dest = new Byte[m_hash.Length];
            Buffer.BlockCopy(m_hash, 0, dest, 0, m_hash.Length);

            return dest;
        }

        public UInt32 GetUInt()
        {
            if (m_hash.Length != 4)
                throw new InvalidOperationException();

            return BitConverter.ToUInt32(m_hash, 0);
        }

        public Int32 GetInt()
        {
            if (m_hash.Length != 4)
                throw new InvalidOperationException();

            return BitConverter.ToInt32(m_hash, 0);
        }

        public UInt64 GetULong()
        {
            if (m_hash.Length != 8)
                throw new InvalidOperationException();

            return BitConverter.ToUInt64(m_hash, 0);
        }

        public override String ToString()
        {
            return Converters.ConvertBytesToHexString(m_hash);
        }

        public override Boolean Equals(Object a_obj)
        {
            HashResult hash_result = a_obj as HashResult;
            if ((HashResult)hash_result == null)
                return false;

            return Equals(hash_result);
        }

        public Boolean Equals(HashResult a_hashResult)
        {
            return HashResult.SameArrays(a_hashResult.GetBytes(), m_hash);
        }

        public override Int32 GetHashCode()
        {
            return Convert.ToBase64String(m_hash).GetHashCode();
        }

        private static Boolean SameArrays(Byte[]  a_ar1, Byte[]  a_ar2)
        {
            if (Object.ReferenceEquals(a_ar1, a_ar2))
                return true;

            if (a_ar1.Length != a_ar2.Length)
                return false;

            for (Int32 i = 0; i < a_ar1.Length; i++)
                if (a_ar1[i] != a_ar2[i])
                    return false;

            return true;
        }
    }
}