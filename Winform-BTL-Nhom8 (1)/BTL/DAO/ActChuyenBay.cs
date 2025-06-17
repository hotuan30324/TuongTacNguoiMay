using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DAO
{
    class ActChuyenBay
    {
        private static ActChuyenBay instance;
        public static ActChuyenBay Instance
        {
            get { if (instance == null) instance = new ActChuyenBay(); return ActChuyenBay.instance; }
            private set { ActChuyenBay.instance = value; }
        }
        private ActChuyenBay() { }

        public DataTable timChuyenBayByMaCB(string MaChuyenBay)
        {
            string sqlstr = "select * from ChuyenBay WHERE MaChuyenBay= '" + MaChuyenBay + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable GetDataChuyenBay()
        {
            string sqlstr = "select cb.MaChuyenBay, cb.NgayDi , cb.NgayDen , cb.GioDi , " +
                "mb.SoLuongGhe1 , mb.SoLuongGhe2 , dd.DiemDi , dd.DiemDen ," +
                "cb.GhiChu " +
                "from ChuyenBay AS cb INNER JOIN dbo.MayBay AS mb ON cb.MaMayBay = mb.MaMayBay INNER JOIN dbo.DuongDi AS dd ON cb.MaDD = dd.MaDD";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable timKiemCBByMaDD(string maDD)
        {
            string sqlstr = "select * from ChuyenBay where MaDD='" + maDD + "'";
            return ConnectSQL.GetData(sqlstr);
        }

        public DataTable timKiemCBByMaMB(string maMB)
        {
            string sqlstr = "select * from ChuyenBay where MaMayBay='" + maMB + "'";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable getMayBayFromChuyyenBay(string MaChuyenBay)
        {

            string sqlstr = "select * from ChuyenBay AS cb INNER JOIN dbo.MayBay AS mb ON cb.MaMayBay = mb.MaMayBay WHERE cb.MaChuyenBay = '" + MaChuyenBay +"'";
            return ConnectSQL.GetData(sqlstr);

        }
  
        public bool ThemMoi(ChuyenBay objCB)
        {
            string sqlstr = "insert into ChuyenBay(MaChuyenBay, MaMayBay, MaDD, Manv, NgayDi, NgayDen, GioDi, Ghichu) values (@MaChuyenBay, @MaMayBay,@MaDD,@Manv,@NgayDi,@NgayDen,@GioDi,@Ghichu)";
            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaChuyenBay", SqlDbType.NChar, 5);
            pars[0].Value = objCB.MaChuyenBay;

            pars[1] = new SqlParameter("@MaMayBay", SqlDbType.NChar, 5);
            pars[1].Value = objCB.MaMayBay;

            pars[2] = new SqlParameter("@MaDD", SqlDbType.NChar, 5);
            pars[2].Value = objCB.MaDD;

            pars[3] = new SqlParameter("@Manv", SqlDbType.NChar, 5);
            pars[3].Value = objCB.Manv;

            pars[4] = new SqlParameter("@NgayDi", SqlDbType.DateTime);
            pars[4].Value = objCB.NgayDi;

            pars[5] = new SqlParameter("@NgayDen", SqlDbType.DateTime);
            pars[5].Value = objCB.NgayDen;

            pars[6] = new SqlParameter("@GioDi", SqlDbType.NChar, 10);
            pars[6].Value = objCB.GioDi;

            pars[7] = new SqlParameter("@Ghichu", SqlDbType.NChar, 50);
            pars[7].Value = objCB.Ghichu;

            return ConnectSQL.ThucHien(sqlstr, pars);

        }

        public bool CapNhat(ChuyenBay objCB)
        {
            string strsql = "update ChuyenBay set MaMayBay = @MaMayBay, MaDD = @MaDD, Manv=@Manv, NgayDi= @NgayDi , NgayDen = @NgayDen, GioDi = @GioDi, Ghichu=@Ghichu where MaChuyenBay = @MaChuyenBay";

            SqlParameter[] pars = new SqlParameter[8];

            pars[0] = new SqlParameter("@MaChuyenBay", SqlDbType.NChar, 5);
            pars[0].Value = objCB.MaChuyenBay;

            pars[1] = new SqlParameter("@MaMayBay", SqlDbType.NChar, 5);
            pars[1].Value = objCB.MaMayBay;

            pars[2] = new SqlParameter("@MaDD", SqlDbType.NChar, 5);
            pars[2].Value = objCB.MaDD;

            pars[3] = new SqlParameter("@Manv", SqlDbType.NChar, 5);
            pars[3].Value = objCB.Manv;

            pars[4] = new SqlParameter("@NgayDi", SqlDbType.DateTime);
            pars[4].Value = objCB.NgayDi;

            pars[5] = new SqlParameter("@NgayDen", SqlDbType.DateTime);
            pars[5].Value = objCB.NgayDen;

            pars[6] = new SqlParameter("@GioDi", SqlDbType.NChar, 10);
            pars[6].Value = objCB.GioDi;

            pars[7] = new SqlParameter("@Ghichu", SqlDbType.NChar, 50);
            pars[7].Value = objCB.Ghichu;

            return ConnectSQL.ThucHien(strsql, pars);


        }


 
        public bool Xoa(string MaCB)
        {
            string strDel = "delete from ChuyenBay where MaChuyenBay = '" + MaCB + "'";
            return ConnectSQL.ThucHien(strDel);
        }

    }
}
