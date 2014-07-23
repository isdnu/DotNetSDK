using System;

namespace HashLib
{
    internal class HMACNotBuildInAdapter : Hash, IHMACNotBuildIn
    {
        private Byte[]  m_opad;
        private Byte[]  m_ipad;
        private IHash m_hash;
        private Byte[]  m_key;

        public virtual Byte[]  Key
        {
            get
            {
                return (Byte[] )m_key.Clone();
            }
            set
            {
                if (value == null)
                {
                    m_key = new Byte[0];
                }
                else
                {
                    m_key = (Byte[] )value.Clone();
                }
            }
        }

        internal HMACNotBuildInAdapter(IHash a_underlyingHash)
            : base(a_underlyingHash.HashSize, a_underlyingHash.BlockSize)
        {
            m_hash = a_underlyingHash;
            m_key = new Byte[0];
            m_ipad = new Byte[m_hash.BlockSize];
            m_opad = new Byte[m_hash.BlockSize];
        }

        private void UpdatePads()
        {
            Byte[]  key;
            if (Key.Length > m_hash.BlockSize)
                key = m_hash.ComputeBytes(Key).GetBytes();
            else
                key = Key;

            for (Int32 i = 0; i < m_hash.BlockSize; i++)
            {
                m_ipad[i] = 0x36;
                m_opad[i] = 0x5c;
            }

            for (Int32 i = 0; i < key.Length; i++)
            {
                m_ipad[i] ^= key[i];
                m_opad[i] ^= key[i];
            }
        }

        public override void Initialize()
        {
            m_hash.Initialize();
            UpdatePads();
            m_hash.TransformBytes(m_ipad);
        }

        public override HashResult TransformFinal()
        {
            HashResult h = m_hash.TransformFinal();
            m_hash.TransformBytes(m_opad);
            m_hash.TransformBytes(h.GetBytes());
            h = m_hash.TransformFinal();
            Initialize();
            return h;
        }

        public override void TransformBytes(Byte[]  a_data, Int32 a_index, Int32 a_length)
        {
            m_hash.TransformBytes(a_data, a_index, a_length);
        }

        public override String Name
        {
            get
            {
                return String.Format("{0}({1})", GetType().Name, m_hash.GetType().Name);
            }
        }

        public int? KeyLength
        {
            get
            {
                return null;
            }
        }
    }
}