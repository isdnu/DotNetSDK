using System;

namespace HashLib
{
    internal class HashBuffer 
    {
        private Byte[]  m_data;
        private Int32 m_pos;

        public HashBuffer(Int32 a_length)
        {
            m_data = new Byte[a_length];

            Initialize();
        }

        public void Initialize()
        {
            m_pos = 0;
        }

        public Byte[]  GetBytes()
        {
            m_pos = 0;
            return m_data;
        }

        public Byte[]  GetBytesZeroPadded()
        {
            Array.Clear(m_data, m_pos, m_data.Length - m_pos); 
            m_pos = 0;
            return m_data;
        }

        public Boolean Feed(Byte[]  a_data, ref Int32 a_start_index, ref Int32 a_length, ref UInt64 a_processed_bytes)
        {
            if (a_data.Length == 0)
                return false;

            if (a_length == 0)
                return false;

            Int32 length = m_data.Length - m_pos;
            if (length > a_length)
                length = a_length;

            Array.Copy(a_data, a_start_index, m_data, m_pos, length);

            m_pos += length;
            a_start_index += length;
            a_length -= length;
            a_processed_bytes += (UInt64)length;

            return IsFull;
        }

        public Boolean Feed(Byte[]  a_data, Int32 a_length)
        {
            if (a_data.Length == 0)
                return false;

            if (a_length == 0)
                return false;

            Int32 length = m_data.Length - m_pos;
            if (length > a_length)
                length = a_length;

            Array.Copy(a_data, 0, m_data, m_pos, length);

            m_pos += length;

            return IsFull;
        }

        public Boolean IsEmpty
        {
            get
            {
                return m_pos == 0;
            }
        }

        public Int32 Pos
        {
            get
            {
                return m_pos;
            }
        }

        public Int32 Length
        {
            get
            {
                return m_data.Length;
            }
        }

        public Boolean IsFull
        {
            get
            {
                return (m_pos == m_data.Length);
            }
        }

        public override String ToString()
        {
            return String.Format("HashBuffer, Legth: {0}, Pos: {1}, IsEmpty: {2}", Length, Pos, IsEmpty);
        }
    }
}