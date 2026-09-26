namespace QuanLyVeMayBay
{
    internal static class Program
    {
        // Khởi chạy ứng dụng
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}