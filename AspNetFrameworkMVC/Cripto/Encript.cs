using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AspNetFrameworkMVC.Cripto
{
    public class Encript
    {
        public static string Encrypt(string text, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] textBytes = Encoding.UTF8.GetBytes(text);

            using (var aesAlg = new RijndaelManaged())
            {
                aesAlg.Key = keyBytes;
                aesAlg.Mode = CipherMode.ECB; // Defina o modo de criptografia desejado
                aesAlg.Padding = PaddingMode.PKCS7; // Defina o modo de preenchimento desejado

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Decrypt(string encryptedText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (var aesAlg = new RijndaelManaged())
            {
                aesAlg.Key = keyBytes;
                aesAlg.Mode = CipherMode.ECB; // Defina o modo de criptografia desejado
                aesAlg.Padding = PaddingMode.PKCS7; // Defina o modo de preenchimento desejado

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}