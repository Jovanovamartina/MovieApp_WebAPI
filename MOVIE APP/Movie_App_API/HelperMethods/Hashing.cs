
using System.Text;
using XSystem.Security.Cryptography;

namespace BookApp.HelperMethods
{
    public class Hashing : IHasher
    {
        public string Hash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Encoding.ASCII.GetString(md5Data);
        }
    }
}
