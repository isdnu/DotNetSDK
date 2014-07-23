using System;

namespace HashLib
{
    public interface IHash
    {
        String Name { get; }
        Int32 BlockSize { get; }
        Int32 HashSize { get; }

        void Initialize();

        HashResult ComputeBytes(Byte[] a_data);

        void TransformBytes(Byte[] a_data);
        void TransformBytes(Byte[] a_data, Int32 a_index);
        void TransformBytes(Byte[] a_data, Int32 a_index, Int32 a_length);

        HashResult TransformFinal();
    }
}
