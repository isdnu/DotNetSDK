using System;

namespace HashLib
{
    internal interface IWithKey : IHash
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

    internal interface ICrypto : IHash, IBlockHash { }

    internal interface ICryptoNotBuildIn : ICrypto { }

    internal interface IHMAC : IWithKey, ICrypto { }

    internal interface IHMACNotBuildIn : IHMAC, ICryptoNotBuildIn { }

    internal interface IBlockHash { }
}