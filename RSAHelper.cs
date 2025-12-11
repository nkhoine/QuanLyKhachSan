using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLyKhachSan
{
    public static class RSAHelper
    {
        /// <summary>
        /// Tạo cặp khóa mới (Chạy 1 lần khi tạo User mới)
        /// </summary>
        /// <param name="publicKey">Lưu vào DB công khai</param>
        /// <param name="privateKey">Nhân viên tự giữ bí mật</param>
        public static void GenerateKeys(out string publicKey, out string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                // false: chỉ lấy public key
                publicKey = rsa.ToXmlString(false);
                // true: lấy cả private key
                privateKey = rsa.ToXmlString(true);
            }
        }

        /// <summary>
        /// KÝ SỐ (Dùng Private Key để ký lên dữ liệu hóa đơn)
        /// </summary>
        public static string SignData(string dataToSign, string privateKeyXML)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXML);
                byte[] dataBytes = Encoding.UTF8.GetBytes(dataToSign);

                // Băm dữ liệu bằng SHA256 rồi ký
                byte[] signatureBytes = rsa.SignData(dataBytes, new SHA256CryptoServiceProvider());

                return Convert.ToBase64String(signatureBytes);
            }
        }

        /// <summary>
        /// XÁC THỰC CHỮ KÝ (Dùng Public Key để kiểm tra xem có đúng người đó ký không)
        /// </summary>
        public static bool VerifyData(string originalData, string signatureBase64, string publicKeyXML)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKeyXML);
                    byte[] dataBytes = Encoding.UTF8.GetBytes(originalData);
                    byte[] signatureBytes = Convert.FromBase64String(signatureBase64);

                    return rsa.VerifyData(dataBytes, new SHA256CryptoServiceProvider(), signatureBytes);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
