using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Services
{
    public static class PasswordHasherService
    {
        private const string SECRET = "9124860198260sdcvsd@29357235";

        public static string HashPassword(string password)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(SECRET);
            byte[] textBytes = Encoding.UTF8.GetBytes(password);

            using (var aesAlg = new RijndaelManaged())
            {
                aesAlg.Key = GetValidKeySize(keyBytes, aesAlg.KeySize / 8);
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.GenerateIV(); // Gera um IV aleatório

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);

                byte[] encryptedBytesWithIV = new byte[aesAlg.IV.Length + encryptedBytes.Length];
                Array.Copy(aesAlg.IV, 0, encryptedBytesWithIV, 0, aesAlg.IV.Length);
                Array.Copy(encryptedBytes, 0, encryptedBytesWithIV, aesAlg.IV.Length, encryptedBytes.Length);

                return Convert.ToBase64String(encryptedBytesWithIV);
            }
        }

        public static string UnhashPassword(string password)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(SECRET);
            byte[] encryptedBytesWithIV = Convert.FromBase64String(password);

            byte[] iv = new byte[16];
            byte[] encryptedBytes = new byte[encryptedBytesWithIV.Length - iv.Length];
            Array.Copy(encryptedBytesWithIV, 0, iv, 0, iv.Length);
            Array.Copy(encryptedBytesWithIV, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

            using (var aesAlg = new RijndaelManaged())
            {
                aesAlg.Key = GetValidKeySize(keyBytes, aesAlg.KeySize / 8);
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.IV = iv;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        private static byte[] GetValidKeySize(byte[] keyBytes, int validSize)
        {
            if (keyBytes.Length == validSize)
            {
                return keyBytes;
            }

            byte[] validKeyBytes = new byte[validSize];
            Array.Copy(keyBytes, validKeyBytes, Math.Min(keyBytes.Length, validSize));
            return validKeyBytes;
        }

        public static bool VerifyPassword(string hashedPassword)
        {
            return true;
        }

        public static bool VerifyPassword(string unhashedPassword, string hashedPassword)
        {
            string decryptedPassword = UnhashPassword(hashedPassword);
            return unhashedPassword == decryptedPassword;
        }
    }
}