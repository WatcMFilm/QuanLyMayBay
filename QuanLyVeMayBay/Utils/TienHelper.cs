using System;
using System.Collections.Generic;

namespace QuanLyVeMayBay
{
    /// <summary>
    /// Tiện ích dùng chung: đọc số tiền thành chữ tiếng Việt (dùng cho hóa đơn)
    /// </summary>
    public static class TienHelper
    {
        private static readonly string[] ChuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] DonVi = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ", "tỷ tỷ" };

        // Ví dụ: 1.850.000 -> "Một triệu tám trăm năm mươi nghìn đồng chẵn"
        public static string DocTienBangChu(decimal soTien)
        {
            long n = (long)Math.Floor(Math.Abs(soTien));
            if (n == 0) return "Không đồng";

            // Tách thành các nhóm 3 chữ số, nhóm 0 là hàng đơn vị
            var nhom = new List<int>();
            while (n > 0)
            {
                nhom.Add((int)(n % 1000));
                n /= 1000;
            }

            var phan = new List<string>();
            for (int i = nhom.Count - 1; i >= 0; i--)
            {
                if (nhom[i] == 0) continue;
                bool laNhomDauTien = i == nhom.Count - 1;
                string chu = DocBaSo(nhom[i], !laNhomDauTien);
                phan.Add(string.IsNullOrEmpty(DonVi[i]) ? chu : $"{chu} {DonVi[i]}");
            }

            string ketQua = string.Join(" ", phan);
            return char.ToUpper(ketQua[0]) + ketQua.Substring(1) + " đồng chẵn";
        }

        // Đọc 1 nhóm 3 chữ số. docDayDu = true với các nhóm phía sau (đọc cả "không trăm", "lẻ")
        private static string DocBaSo(int n, bool docDayDu)
        {
            int tram = n / 100;
            int chuc = (n % 100) / 10;
            int donVi = n % 10;
            var res = new List<string>();

            if (tram > 0 || docDayDu)
                res.Add($"{ChuSo[tram]} trăm");

            if (chuc == 0)
            {
                if (donVi > 0)
                    res.Add(res.Count > 0 ? $"lẻ {ChuSo[donVi]}" : ChuSo[donVi]);
            }
            else if (chuc == 1)
            {
                res.Add("mười");
                if (donVi == 5) res.Add("lăm");
                else if (donVi > 0) res.Add(ChuSo[donVi]);
            }
            else
            {
                res.Add($"{ChuSo[chuc]} mươi");
                if (donVi == 1) res.Add("mốt");
                else if (donVi == 5) res.Add("lăm");
                else if (donVi > 0) res.Add(ChuSo[donVi]);
            }

            return string.Join(" ", res);
        }
    }
}
