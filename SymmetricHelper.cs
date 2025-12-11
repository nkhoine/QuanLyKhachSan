using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nhom5_QuanLyKhachSan
{
    public static class SymmetricHelper
    {
        private static readonly string SecretPassword = "Nhom5_Hotel_Security_Key_2025!!!";

        // Hàm tạo Key chuẩn 32 bytes từ mật khẩu
        private static byte[] GetKeyFromPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return null;

            try
            {
                byte[] key = GetKeyFromPassword(SecretPassword);
                byte[] iv = new byte[16];

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                        }
                        byte[] encryptedBytes = msEncrypt.ToArray();

                        // [SỬA LỖI ORA-01465]: Chuyển sang chuỗi HEX thay vì Base64
                        // BitConverter trả về dạng "AA-BB-CC", ta xóa dấu gạch ngang đi
                        return BitConverter.ToString(encryptedBytes).Replace("-", "");
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string Decrypt(string cipherTextHex)
        {
            if (string.IsNullOrEmpty(cipherTextHex)) return null;

            try
            {
                // [SỬA LỖI]: Chuyển từ chuỗi HEX trở lại mảng byte
                // Đảm bảo chuỗi có độ dài chẵn
                if (cipherTextHex.Length % 2 != 0)
                {
                    throw new FormatException("Ciphertext Hex length is odd, cannot convert to byte array.");
                }

                byte[] fullCipher = new byte[cipherTextHex.Length / 2];
                for (int i = 0; i < fullCipher.Length; i++)
                {
                    fullCipher[i] = Convert.ToByte(cipherTextHex.Substring(i * 2, 2), 16);
                }

                byte[] key = GetKeyFromPassword(SecretPassword); //
                byte[] iv = new byte[16]; //

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key; //
                    aesAlg.IV = iv; //
                    aesAlg.Mode = CipherMode.CBC; //
                    aesAlg.Padding = PaddingMode.PKCS7; //

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV); //

                    using (MemoryStream msDecrypt = new MemoryStream(fullCipher))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) //
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt)) //
                            {
                                return srDecrypt.ReadToEnd(); //
                            }
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                // Lỗi khi chuỗi Hex không hợp lệ
                return $"[Lỗi giải mã: Dữ liệu Hex không hợp lệ - {ex.Message}]";
            }
            catch (CryptographicException ex)
            {
                // Lỗi phổ biến nhất: Key, IV, hoặc Padding sai
                return $"[Lỗi giải mã: Bảo mật sai - {ex.Message}]";
            }
            catch (Exception ex)
            {
                // Lỗi chung khác
                return $"[Lỗi giải mã: Lỗi chung - {ex.Message}]";
            }
        }
    }
}