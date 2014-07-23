using System;

using HashLib.Crypto;

namespace HashLib
{
    internal class HMACSHA1 : IHMAC
    {
        private SHA1 _sha1;
        private HMACNotBuildInAdapter _adapter;

        public Byte[] Key
        {
            get { return _adapter.Key; }
            set { _adapter.Key = value; }
        }

        public Int32? KeyLength
        {
            get { return _adapter.KeyLength; }
        }

        public String Name
        {
            get { return _adapter.Name; }
        }

        public Int32 BlockSize
        {
            get { return _adapter.BlockSize; }
        }

        public Int32 HashSize
        {
            get { return _adapter.HashSize; }
        }

        public HMACSHA1()
        {
            _sha1 = new SHA1();
            _adapter = new HMACNotBuildInAdapter(_sha1);
        }

        public void Initialize()
        {
            _adapter.Initialize();
        }

        public HashResult ComputeBytes(Byte[] a_data)
        {
            return this._adapter.ComputeBytes(a_data);
        }

        public void TransformBytes(Byte[] a_data)
        {
            _adapter.TransformBytes(a_data);
        }

        public void TransformBytes(Byte[] a_data, Int32 a_index)
        {
            _adapter.TransformBytes(a_data, a_index);
        }

        public void TransformBytes(Byte[] a_data, Int32 a_index, Int32 a_length)
        {
            _adapter.TransformBytes(a_data, a_index, a_length);
        }

        public HashResult TransformFinal()
        {
            return this._adapter.TransformFinal();
        }

        public Byte[] ComputeHash(Byte[] a_data)
        {
            HashResult result = ComputeBytes(a_data);
            Byte[] data = result.GetBytes();

            return data;
        }
    }
}