using System.Text;
using System.Security.Cryptography;

namespace Persistence
{
    public static class Criptografar
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // alterá-lo em 2 dígitos hexadecimais
                // para cada byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
    // www.junian.net/2014/07/password-encryption-using-md5-hash.html
}
