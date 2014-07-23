using System;

namespace HashLib
{
    public interface IWithKey : IHash
    {
        Byte[] Key
        {
            get;
            set;
        }

        Int32? KeyLength
        {
            get;
        }
    }

    public interface ICrypto : IHash, IBlockHash { }

    public interface ICryptoNotBuildIn : ICrypto { }

    public interface IHMAC : IWithKey, ICrypto { }

    public interface IHMACNotBuildIn : IHMAC, ICryptoNotBuildIn { }

    public interface IBlockHash { }
}