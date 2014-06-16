using System;

namespace HashLib
{
    public interface IWithKey : IHash
    {
        byte[] Key
        {
            get;
            set;
        }

        int? KeyLength
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