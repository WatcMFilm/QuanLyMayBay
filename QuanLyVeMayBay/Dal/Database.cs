using MySql.Data.MySqlClient;

namespace QuanLyVeMayBay.DAL
{
    public class Database
    {
        private string connectionString =
            "Server=localhost;Port=3306;Database=QuanLyDatVeMayBay;Uid=root;Pwd=123456;";

        // Lấy kết nối cơ sở dữ liệu MySQL
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}