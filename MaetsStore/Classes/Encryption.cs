using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace MaetsStore.Classes
{
    public class Encryption
    {
        public static string EncryptPass(string unHashedPass)
        {
            var sha256 = SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(unHashedPass);
            var hash = sha256.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}