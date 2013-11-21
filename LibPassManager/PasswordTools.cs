using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPassManager
{
    public static class PasswordTools
    {
        public class PasswordOptions
        {
            public const string lower_alpha = "abcdefghijklmnopqrstuvwxyz";
            public const string upper_alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public const string numeric = "0123456789";
            public const string symbols = @"!@#$%^&*()-=_+`~[{]}\|;:'\"",<.>/?";

            public static PasswordOptions Low = new PasswordOptions(lower_alpha + upper_alpha);
            public static PasswordOptions Medium = new PasswordOptions(lower_alpha + upper_alpha + numeric);
            public static PasswordOptions High = new PasswordOptions();
            public static PasswordOptions RandomSSLBase64 = new PasswordOptions(true);

            public string CharRange { get; set; }
            public bool RandomBase64 = false;

            public PasswordOptions()
            {
                CharRange = lower_alpha + upper_alpha + numeric + symbols;
            }

            public PasswordOptions(bool useSSLBase64)
            {
                RandomBase64 = true;
            }

            public PasswordOptions(string charRange)
            {
                CharRange = charRange;
            }
        }
        public static string GeneratePassword(int length, PasswordOptions options)
        {
            if (options.RandomBase64)
                return Util.RandomString(length);
            else
                return Util.RandomString(length, options.CharRange);
        }
    }
}
