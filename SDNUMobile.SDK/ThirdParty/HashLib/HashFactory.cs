using System;

namespace HashLib
{
    public static class HashFactory
    {
        public static class Crypto
        {
            public static IHash CreateSHA1()
            {
                return new HashLib.Crypto.SHA1();
            }
        }

        public static class HMAC
        {
            public static IHMAC CreateHMAC(IHash a_hash)
            {
                if (a_hash is IHMAC)
                {
                    return (IHMAC)a_hash;
                }
                else
                {
                    return new HMACNotBuildInAdapter(a_hash);
                }
            }
        }
    }
}