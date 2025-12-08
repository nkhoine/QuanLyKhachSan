using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLyKhachSan
{
    public class EncryptedPacket
    {
        public byte[] EncryptedSessionKey; // Khóa phiên đã được mã hóa bằng RSA
        public byte[] EncryptedData;       // Dữ liệu thật đã được mã hóa bằng AES
        public byte[] IV;                  // Vector khởi tạo của AES
    }

    public static class HybridHelper
    {
        /// <summary>
        /// Mã hóa Lai: Dữ liệu -> AES, Key AES -> RSA
        /// </summary>
        public static EncryptedPacket EncryptData(string plainText, string receiverPublicKeyXML)
        {
            EncryptedPacket packet = new EncryptedPacket();

            // 1. Tạo khóa phiên AES ngẫu nhiên
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey(); // Sinh key ngẫu nhiên
                aes.GenerateIV();  // Sinh IV ngẫu nhiên

                packet.IV = aes.IV;

                // 2. Mã hóa dữ liệu bằng AES
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                packet.EncryptedData = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                // 3. Mã hóa khóa AES (Session Key) bằng RSA Public Key
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(receiverPublicKeyXML);
                    // false: sử dụng padding OAEP (an toàn hơn)
                    packet.EncryptedSessionKey = rsa.Encrypt(aes.Key, false);
                }
            }
            return packet;
        }

        /// <summary>
        /// Giải mã Lai: Key AES -> Giải mã bằng RSA Private, Dữ liệu -> Giải mã bằng AES
        /// </summary>
        public static string DecryptData(EncryptedPacket packet, string receiverPrivateKeyXML)
        {
            byte[] decryptedSessionKey;

            // 1. Giải mã lấy Session Key bằng RSA Private Key
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(receiverPrivateKeyXML);
                decryptedSessionKey = rsa.Decrypt(packet.EncryptedSessionKey, false);
            }

            // 2. Dùng Session Key vừa lấy được để giải mã dữ liệu AES
            using (Aes aes = Aes.Create())
            {
                aes.Key = decryptedSessionKey;
                aes.IV = packet.IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(packet.EncryptedData, 0, packet.EncryptedData.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
