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
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(senha)).ToString();
            }
        }
    }
}