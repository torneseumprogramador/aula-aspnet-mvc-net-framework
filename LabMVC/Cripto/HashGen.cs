using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace LabMVC.Cripto
{
    public static class HashGen
    {
        public static string hashficaSenha(string senha)
        {
            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(senha));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}