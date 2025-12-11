using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom5_QuanLyKhachSan
{
    // Class tĩnh để lưu trữ thông tin dùng chung cho toàn bộ ứng dụng
    public static class Session
    {
        public static string MaNV = "";
        public static string HoTen = "";
        public static string ChucVu = ""; // Admin, LeTan, QuanLy...
        public static string TenDangNhap = "";
    }
}