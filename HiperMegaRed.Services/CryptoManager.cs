using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HiperMegaRed.Services
{
    public class CryptoManager
    {
        public static string passCode = "WarNeverChanges";
        private static byte[] Encrypt(string plainText, string password)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, passwordBytes, DataProtectionScope.CurrentUser);
            return encryptedBytes;
        }

        private static string Decrypt(byte[] encryptedBytes, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] plainBytes = ProtectedData.Unprotect(encryptedBytes, passwordBytes, DataProtectionScope.CurrentUser);
            string plainText = Encoding.UTF8.GetString(plainBytes);
            return plainText;
        }


        public static string Encriptar(string texto)
        {
            byte[] textobase = Encrypt(texto, passCode);
            string resultado = Convert.ToBase64String(textobase);
            return resultado;
        }

        public static string Desencriptar(string texto)
        {
            byte[] bytesdesencuptados = Convert.FromBase64String(texto);
            string otroresultado = Decrypt(bytesdesencuptados, passCode);
            return otroresultado;
        }

        //private readonly byte[] _key;
        //private readonly byte[] _iv;

        //public CryptoManager(string key, string iv)
        //{
        //    // Convertir las claves y vectores de inicialización a bytes
        //    _key = Encoding.UTF8.GetBytes(key);
        //    _iv = Encoding.UTF8.GetBytes(iv);
        //}

        //public string Encrypt(string plaintext)
        //{
        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = _key;
        //        aesAlg.IV = _iv;

        //        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        //        byte[] encryptedBytes;

        //        using (var msEncrypt = new System.IO.MemoryStream())
        //        {
        //            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
        //                {
        //                    swEncrypt.Write(plaintext);
        //                }
        //                encryptedBytes = msEncrypt.ToArray();
        //            }
        //        }

        //        return Convert.ToBase64String(encryptedBytes);
        //    }
        //}

        //public string Decrypt(string ciphertext)
        //{
        //    byte[] cipherBytes = Convert.FromBase64String(ciphertext);

        //    using (Aes aesAlg = Aes.Create())
        //    {
        //        aesAlg.Key = _key;
        //        aesAlg.IV = _iv;

        //        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        //        string plaintext = null;

        //        using (var msDecrypt = new System.IO.MemoryStream(cipherBytes))
        //        {
        //            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
        //            {
        //                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
        //                {
        //                    plaintext = srDecrypt.ReadToEnd();
        //                }
        //            }
        //        }

        //        return plaintext;
        //    }
        //}
    }
}
