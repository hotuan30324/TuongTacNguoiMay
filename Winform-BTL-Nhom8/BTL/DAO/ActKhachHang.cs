using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DAO
{
    class ActKhachHang
    {
        private static ActKhachHang instance;
        public static ActKhachHang Instance
        {
            get { if (instance == null) instance = new ActKhachHang(); return ActKhachHang.instance; }
            private set { ActKhachHang.instance = value; }
        }
        private ActKhachHang() { }

        public DataTable GetDataKhachHang()
        {
            string sqlstr = "select * from KhachHang";
            return ConnectSQL.GetData(sqlstr);
        }

        public DataTable timKiemKHByMaKH(string maKH)
        {
            string sqlstr = "select * from KhachHang where MaKH='" + maKH + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable timKiemKH(string sdt)
        {
            //string sqlstr = "select * from KhachHang where SDT like '" + "%" + sdt + "%'";
            string sqlstr = "select * from KhachHang where SDT='" + sdt + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public bool ThemMoi(KhachHang objKH)
        {
            string sqlstr = "insert into KhachHang(MaKH, TenKH, SDT, GioiTinh, DiaChi, CMNDHoChieu, QuocTich, NgaySinh) values (@MaKH, @TenKH,@SDT,@GioiTinh,@DiaChi,@CMNDHoChieu,@QuocTich,@NgaySinh)";
            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaKH", SqlDbType.NChar, 5);
            pars[0].Value = objKH.MaKH;

            pars[1] = new SqlParameter("@TenKH", SqlDbType.NChar, 30);
            pars[1].Value = objKH.TenKH;

            pars[2] = new SqlParameter("@GioiTinh", SqlDbType.NChar, 3);
            pars[2].Value = objKH.GioiTinh;

            pars[3] = new SqlParameter("@DiaChi", SqlDbType.NChar, 40);
            pars[3].Value = objKH.DiaChi;

            pars[4] = new SqlParameter("@CMNDHoChieu", SqlDbType.NChar, 20);
            pars[4].Value = objKH.CMNDHoChieu;

            pars[5] = new SqlParameter("@QuocTich", SqlDbType.NChar, 20);
            pars[5].Value = objKH.QuocTich;

            pars[6] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            pars[6].Value = objKH.NgaySinh;

            pars[7] = new SqlParameter("@SDT", SqlDbType.NChar, 30);
            pars[7].Value = objKH.SDT;

 
            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool CapNhat(KhachHang objKH)
        {

            string sqlstr = "update KhachHang set TenKH=@TenKH, SDT=@SDT, GioiTinh=@GioiTinh, DiaChi=@DiaChi, CMNDHoChieu=@CMNDHoChieu, QuocTich=@QuocTich, NgaySinh=@NgaySinh where MaKH=@MaKH ";
            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaKH", SqlDbType.NChar, 5);
            pars[0].Value = objKH.MaKH;

            pars[1] = new SqlParameter("@TenKH", SqlDbType.NChar, 30);
            pars[1].Value = objKH.TenKH;

            pars[2] = new SqlParameter("@GioiTinh", SqlDbType.NChar, 3);
            pars[2].Value = objKH.GioiTinh;

            pars[3] = new SqlParameter("@DiaChi", SqlDbType.NChar, 40);
            pars[3].Value = objKH.DiaChi;

            pars[4] = new SqlParameter("@CMNDHoChieu", SqlDbType.NChar, 20);
            pars[4].Value = objKH.CMNDHoChieu;

            pars[5] = new SqlParameter("@QuocTich", SqlDbType.NChar, 20);
            pars[5].Value = objKH.QuocTich;

            pars[6] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            pars[6].Value = objKH.NgaySinh;

            pars[7] = new SqlParameter("@SDT", SqlDbType.NChar, 30);
            pars[7].Value = objKH.SDT;

 
            return ConnectSQL.ThucHien(sqlstr, pars);
        }
    }
}
