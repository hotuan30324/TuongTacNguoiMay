using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    public class NhanVien
    {

        public NhanVien()
        {
            MatKhau = "0";
        }
        public string MaNV { get; set; }

        public string TenNhanVien { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }
        public int GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public DateTime NgaySinh { get; set; }



    }
}
