using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibPassManager
{
    public static class Util
    {
        private static RNGCryptoServiceProvider _prng;
        internal static RNGCryptoServiceProvider PRNG
        {
            get
            {
                return _prng ?? (_prng = new RNGCryptoServiceProvider());
            }
        }

        public static byte[] RandomBytes(int n = 256)
        {
            try
            {
                var bytes = new byte[n];
                PRNG.GetBytes(bytes);
                return bytes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string RandomString(int length, string characterRange = null)
        {
            if (characterRange == null)
            {
                return Convert.ToBase64String(RandomBytes(length)).Substring(0, length);
            }
            else
            {
                while(characterRange.Length < 257)
                {
                    characterRange += new string(characterRange.Reverse().ToArray());
                }
                var bytes = RandomBytes(length);
                var builder = new StringBuilder(length);
                for (int i = 0; i < length; i += 0)
                {
                    builder.Append((char)bytes[i]);
                }
                var result = builder.ToString();
                builder.Clear();
                return result;
            }
        }
    }
}
