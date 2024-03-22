using System.Security.Cryptography;
using System.Text;

namespace ProjectVsoft.other
{
    public class PasswordCrypt
    {
        public static String SHA1Hashing(string pasword)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(pasword);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); 
                }
                return builder.ToString();
            }
        }
    }
}
