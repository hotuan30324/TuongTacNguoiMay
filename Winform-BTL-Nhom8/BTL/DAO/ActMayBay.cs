using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    public class ActMayBay
    {
        public DataTable GetDataMayBay()
        {
            string sqlstr = "select * from MayBay";
            return ConnectSQL.GetData(sqlstr);
        }

   
        public bool ThemMoi(MayBay objMB)
        {
            string sqlstr = "insert into MayBay(MaMayBay, TenMayBay, HangSanXuat, SoLuongGhe1, SoLuongGhe2) values (@MaMayBay, @TenMayBay, @HangSanXuat, @SoLuongGhe1, @SoLuongGhe2)";

            SqlParameter[] pars = new SqlParameter[5];

            pars[0] = new SqlParameter("@MaMayBay", SqlDbType.NChar, 5);
            pars[0].Value = objMB.MaMayBay;

            pars[1] = new SqlParameter("@TenMayBay", SqlDbType.NChar, 30);
            pars[1].Value = objMB.TenMayBay;

            pars[2] = new SqlParameter("@HangSanXuat", SqlDbType.NChar, 30);
            pars[2].Value = objMB.HangSanXuat;

            pars[3] = new SqlParameter("@SoLuongGhe1", SqlDbType.Int);
            pars[3].Value = objMB.SoLuongGhe1;

            pars[4] = new SqlParameter("@SoLuongGhe2", SqlDbType.Int);
            pars[4].Value = objMB.SoLuongGhe2;

            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool CapNhat(MayBay objMB)
        {
            string sqlstr = "Update MayBay set MaMayBay = @MaMayBay, TenMayBay = @TenMayBay, HangSanXuat = @HangSanXuat, SoLuongGhe1 = @SoLuongGhe1, SoLuongGhe2 = @SoLuongGhe2 where MaMayBay = @MaMayBay ";
            
            SqlParameter[] pars = new SqlParameter[5];

            pars[0] = new SqlParameter("@MaMayBay", SqlDbType.NChar, 5);
            pars[0].Value = objMB.MaMayBay;

            pars[1] = new SqlParameter("@TenMayBay", SqlDbType.NChar, 30);
            pars[1].Value = objMB.TenMayBay;

            pars[2] = new SqlParameter("@HangSanXuat", SqlDbType.NChar, 30);
            pars[2].Value = objMB.HangSanXuat;

            pars[3] = new SqlParameter("@SoLuongGhe1", SqlDbType.Int);
            pars[3].Value = objMB.SoLuongGhe1;

            pars[4] = new SqlParameter("@SoLuongGhe2", SqlDbType.Int);
            pars[4].Value = objMB.SoLuongGhe2;

            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool Xoa(string MaMB)
        {
            string sqlstr = "delete from MayBay where MaMayBay = '" + MaMB + "'";
            return ConnectSQL.ThucHien(sqlstr);
        }
    }
}
