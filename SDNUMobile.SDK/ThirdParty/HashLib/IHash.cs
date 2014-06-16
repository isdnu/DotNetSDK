using System;
using System.Text;
using System.IO;

namespace HashLib
{
    public interface IHash
    {
        string Name { get; }
        int BlockSize { get; }
        int HashSize { get; }

        void Initialize();

        HashResult ComputeBytes(byte[] a_data);

        void TransformBytes(byte[] a_data);
        void TransformBytes(byte[] a_data, int a_index);
        void TransformBytes(byte[] a_data, int a_index, int a_length);

        HashResult TransformFinal();
    }
}
