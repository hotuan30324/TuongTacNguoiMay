using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DAO
{
    class ActVe
    {
        private static ActVe instance;
        public static ActVe Instance
        {
            get { if (instance == null) instance = new ActVe(); return ActVe.instance; }
            private set { ActVe.instance = value; }
        }
        private ActVe() { }
        public DataTable GetDataVe()
        {
            string sqlstr = "select MaVe, LoaiVe, GiaVe, DiemDi, DiemDen from ThongTinVe as ttv INNER JOIN dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD";
            return ConnectSQL.GetData(sqlstr);
        }

        public DataTable countVeTheoLoaiFromChuyenBay(string maCB, string loaiVe)
        {
            string sqlstr_eco = "select count(*) as SoVe from ThongTinVe where MaCHuyenBay='" + maCB + "' and Loaive='" + loaiVe + "'";
            return ConnectSQL.GetData(sqlstr_eco);
        }


        public DataTable timKiemVeByMaVe(string maVe)
        {
            string sqlstr = "select * from ThongTinVe where MaVe='" + maVe + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable timKiemVeByMaCB(string maCB)
        {
            string sqlstr = "select * from ThongTinVe where MaCHuyenBay='" + maCB + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable timKiemVeByMaVeThongKe(string maVe)
        {
            string sqlstr = "select MaVe, LoaiVe, GiaVe, DiemDi, DiemDen from ThongTinVe as ttv INNER JOIN dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD WHERE MaVe='" + maVe + "'";
            return ConnectSQL.GetData(sqlstr);
        }

        public bool ThemMoi(Ve objVe)
        {
            string sqlstr = "insert into ThongTinVe(MaVe, MaCHuyenBay, LoaiVe, GiaVe) values (@MaVe, @MaCHuyenBay, @LoaiVe, @GiaVe)";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaVe", SqlDbType.NChar, 5);
            pars[0].Value = objVe.MaVe;

            pars[1] = new SqlParameter("@MaCHuyenBay", SqlDbType.NChar, 5);
            pars[1].Value = objVe.MaCHuyenBay;

            pars[2] = new SqlParameter("@LoaiVe", SqlDbType.NChar, 5);
            pars[2].Value = objVe.LoaiVe;

            pars[3] = new SqlParameter("@GiaVe", SqlDbType.Float);
            pars[3].Value = objVe.GiaVe;

            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool XoaVeByMaCB(string maCB)
        {
            string strDel = "delete from ThongTinVe where MaCHuyenBay = '" + maCB + "'";
            return ConnectSQL.ThucHien(strDel);
        }


    }
}
