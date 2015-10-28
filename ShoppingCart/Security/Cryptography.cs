using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Security
{
    internal static class Cryptography
    {
        static readonly string Appsignature = ConfigurationManager.AppSettings["App.Signature"];
        internal static byte[] SaltBytes;
        public static byte[] InitVectorBytes;

        static Cryptography()
        {
            InitVectorBytes = Encoding.UTF8.GetBytes(Appsignature);

        }

        internal static string GenerateSalt()
        {

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[256];

            rng.GetBytes(buffer);
            return BitConverter.ToString(buffer);
        }

        internal static string Encrypt(string plainText, string password, string salt, string initialVector = "")
        {
            return Convert.ToBase64String(EncryptToBytes(plainText, password, salt, initialVector));
        }

        internal static byte[] EncryptToBytes(string plainText, string password, string salt = null, string initialVector = "")
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return EncryptToBytes(plainTextBytes, password, salt, initialVector);
        }

        internal static byte[] EncryptToBytes(byte[] plainTextBytes, string password, string salt = null, string initialVector = "")
        {
            const int keySize = 256;

            byte[] initialVectorBytes = string.IsNullOrEmpty(initialVector) ? InitVectorBytes : Encoding.UTF8.GetBytes(initialVector);
            byte[] saltValueBytes = string.IsNullOrEmpty(salt) ? SaltBytes : Encoding.UTF8.GetBytes(salt);
            byte[] keyBytes = new Rfc2898DeriveBytes(password, saltValueBytes).GetBytes(keySize / 8);

            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes))
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();

                            return memStream.ToArray();
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string password, string salt = null, string initialVector = null)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText.Replace(' ', '+'));
            return Decrypt(cipherTextBytes, password, salt, initialVector).TrimEnd('\0');
        }

        public static string Decrypt(byte[] cipherTextBytes, string password, string salt = null,
            string initialVector = null)
        {
            const int keySize = 256;

            byte[] initialVectorBytes = string.IsNullOrEmpty(initialVector)
                ? InitVectorBytes
                : Encoding.UTF8.GetBytes(initialVector);
            byte[] saltValueBytes = string.IsNullOrEmpty(salt) ? SaltBytes : Encoding.UTF8.GetBytes(salt);
            byte[] keyBytes = new Rfc2898DeriveBytes(password, saltValueBytes).GetBytes(keySize/8);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;

                using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes))
                {
                    using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read)
                            )
                        {
                            int byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
                        }
                    }
                }
            }
        }
    }
}
