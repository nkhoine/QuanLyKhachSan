using System;
using System.Data; // Cần thiết cho DataTable
using System.Windows.Forms; // Cần thiết cho MessageBox
using Oracle.ManagedDataAccess.Client; // Thư viện Oracle

namespace Nhom5_QuanLyKhachSan
{
    public static class Database
    {
        // Các biến lưu thông tin kết nối
        private static string _host;
        private static string _port;
        private static string _sid;
        private static string _user;
        private static string _pass;

        // Biến giữ chuỗi kết nối
        public static string ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=QUANLYKS;Password=123456;";

        /// <summary>
        /// Hàm nhận thông tin từ Form Login
        /// </summary>
        public static void Set_Database(string host, string port, string sid, string user, string pass)
        {
            _host = host.Trim();
            _port = port.Trim();
            _sid = sid.Trim();
            _user = user.Trim();
            _pass = pass.Trim();

            // Kiểm tra nếu user là 'sys' thì thêm quyền SYSDBA
            string privilege = "";
            if (_user.ToLower() == "sys")
            {
                privilege = ";DBA Privilege=SYSDBA";
            }

            // Cập nhật chuỗi kết nối có thêm biến privilege ở cuối
            ConnectionString = string.Format(
                "Data Source={0}:{1}/{2};User Id={3};Password={4}{5};",
                _host, _port, _sid, _user, _pass, privilege);
        }

        /// <summary>
        /// Hàm thử kết nối để kiểm tra đăng nhập
        /// </summary>
        /// <returns>True nếu kết nối thành công, False nếu thất bại</returns>
        public static bool Connect()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnectionString))
                {
                    conn.Open();
                    return true; // Kết nối thành công
                }
            }
            catch (Exception ex)
            {
                // BẮT BUỘC: Phải hiện dòng này lên để biết lỗi gì
                MessageBox.Show("Lỗi chi tiết: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Hàm trả về đối tượng Connection (Dùng cho các Form khác tự quản lý kết nối nếu cần)
        /// </summary>
        public static OracleConnection GetConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        /// <summary>
        /// Hàm lấy dữ liệu (SELECT) trả về bảng DataTable
        /// </summary>
        /// <param name="sql">Câu lệnh SELECT</param>
        public static DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleDataAdapter adp = new OracleDataAdapter(sql, conn))
                    {
                        adp.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Hàm thực thi lệnh INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="sql">Câu lệnh SQL</param>
        /// <returns>True nếu thành công</returns>
        public static bool ExecuteNonQuery(string sql)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
                return false;
            }
        }
    }
}