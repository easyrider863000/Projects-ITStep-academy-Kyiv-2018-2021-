using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_MARVEL.Models
{
    public class APIConfig
    {
        public static long TimeStamp => DateTimeOffset.Now.ToUnixTimeSeconds();
        public static string PublicKey { get; set; } = "";
        public static string PrivateKey { get; set; } = "";
        public static string Hash()
        {
            string stringToHash = $"{TimeStamp}{PrivateKey}{PublicKey}";
            MD5 hash = MD5.Create();

            byte[] bytesStringToHash = Encoding.Default.GetBytes(stringToHash);

            byte[] bytes = hash.ComputeHash(bytesStringToHash);

            return BitConverter.ToString(bytes).Replace("-",string.Empty).ToLower();

        }



    }
}
