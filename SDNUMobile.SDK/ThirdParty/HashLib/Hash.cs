using System;

namespace HashLib
{
    internal abstract class Hash : IHash
    {
        private readonly Int32 m_block_size;
        private readonly Int32 m_hash_size;

        public static Int32 BUFFER_SIZE = 64 * 1024;

        public Hash(Int32 a_hash_size, Int32 a_block_size)
        {
            m_block_size = a_block_size;
            m_hash_size = a_hash_size;
        }

        public virtual String Name
        {
            get
            {
                return GetType().Name;
            }
        }

        public virtual Int32 BlockSize
        {
            get
            {
                return m_block_size;
            }
        }

        public virtual Int32 HashSize
        {
            get
            {
                return m_hash_size;
            }
        }

        public virtual HashResult ComputeBytes(Byte[]  a_data)
        {
            Initialize();
            TransformBytes(a_data);
            HashResult result = TransformFinal();
            Initialize();
            return result;
        }

        public void TransformBytes(Byte[]  a_data)
        {
            TransformBytes(a_data, 0, a_data.Length);
        }

        public void TransformBytes(Byte[]  a_data, Int32 a_index)
        {
            Int32 length = a_data.Length - a_index;

            TransformBytes(a_data, a_index, length);
        }

        public abstract void Initialize();
        public abstract void TransformBytes(Byte[]  a_data, Int32 a_index, Int32 a_length);
        public abstract HashResult TransformFinal();
    }
}