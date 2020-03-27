using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedTrustCodeTest.RTUtilities
{
    public static class RTUtilitie
    {
        private static Random random = new Random();
        public static string GenerateString()
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
