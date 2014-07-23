using System;

namespace HashLib
{
    internal abstract class BlockHash : Hash, IBlockHash
    {
        protected readonly HashBuffer m_buffer;
        protected UInt64 m_processed_bytes;

        protected BlockHash(Int32 a_hash_size, Int32 a_block_size, Int32 a_buffer_size = -1) 
            : base(a_hash_size, a_block_size)
        {
            if (a_buffer_size == -1)
                a_buffer_size = a_block_size;

            m_buffer = new HashBuffer(a_buffer_size);
            m_processed_bytes = 0;
        }

        public override void TransformBytes(Byte[]  a_data, Int32 a_index, Int32 a_length)
        {
            if (!m_buffer.IsEmpty)
            {
                if (m_buffer.Feed(a_data, ref a_index, ref a_length, ref m_processed_bytes))
                    TransformBuffer();
            }

            while (a_length >= m_buffer.Length)
            {
                m_processed_bytes += (UInt64)m_buffer.Length;
                TransformBlock(a_data, a_index);
                a_index += m_buffer.Length;
                a_length -= m_buffer.Length;
            }

            if (a_length > 0)
                m_buffer.Feed(a_data, ref a_index, ref a_length, ref m_processed_bytes);
        }

        public override void Initialize()
        {
            m_buffer.Initialize();
            m_processed_bytes = 0;
        }

        public override HashResult TransformFinal()
        {
            Finish();

            Byte[]  result = GetResult();

            Initialize();
            return new HashResult(result);
        }

        protected void TransformBuffer()
        {
            TransformBlock(m_buffer.GetBytes(), 0);
        }

        protected abstract void Finish();
        protected abstract void TransformBlock(Byte[]  a_data, Int32 a_index);
        protected abstract Byte[]  GetResult();
    }
}