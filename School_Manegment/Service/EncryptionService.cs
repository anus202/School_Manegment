using System.Security.Cryptography;
using System.Text;
using static School_Manegment.Service.EncryptionService;

namespace School_Manegment.Service
{
    public class EncryptionService 
    {
        private readonly byte[] _key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        private readonly byte[] _iv = Encoding.UTF8.GetBytes("1234567890123456");

        // 1. Encrypt Method
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // 2. Decrypt Method
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
