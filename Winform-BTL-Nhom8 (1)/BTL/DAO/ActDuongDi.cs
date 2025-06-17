using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BTL.DAO
{
    class ActDuongDi
    {
        private static ActDuongDi instance;
        public static ActDuongDi Instance
        {
            get { if (instance == null) instance = new ActDuongDi(); return ActDuongDi.instance; }
            private set { ActDuongDi.instance = value; }
        }
        private ActDuongDi() { }

        public DataTable GetDataDuongDi()
        {
            //string sqlstr = "select MaDD as ['Mã Đường Đi'], DiemDi as ['Điểm đi'], DiemDen as ['Điểm đến'], Manv as ['Mã NV tạo'], (rtrim(DiemDi)+'-'+rtrim(DiemDen)) AS LoTrinh from DuongDi";

            string sqlstr = "select MaDD, DiemDi, DiemDen, Manv, (rtrim(DiemDi)+'-'+rtrim(DiemDen)) AS LoTrinh from DuongDi";
            return ConnectSQL.GetData(sqlstr);
        }
        public DataTable checkDuongDi(string maDD)
        {
            string sqlstr = "select * from DuongDi where MaDD='" + maDD + "'";
            return ConnectSQL.GetData(sqlstr);
        }

        public bool ThemMoi(DuongDi objDD)
        {
            string sqlstr = "insert into DuongDi(MaDD, DiemDen, DiemDi, Manv) values (@MaDD, @DiemDen, @DiemDi, @Manv)";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaDD", SqlDbType.NChar, 5);
            pars[0].Value = objDD.MaDD;

            pars[1] = new SqlParameter("@DiemDen", SqlDbType.NChar, 30);
            pars[1].Value = objDD.DiemDen;

            pars[2] = new SqlParameter("@DiemDi", SqlDbType.NChar, 30);
            pars[2].Value = objDD.DiemDi;

            pars[3] = new SqlParameter("@Manv", SqlDbType.NChar, 5);
            pars[3].Value = objDD.Manv;

            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool CapNhat(DuongDi objDD)
        {
            string sqlstr = "update DuongDi set DiemDen = @DiemDen, DiemDi=@DiemDi, Manv= @Manv where MaDD = @MaDD ";

            SqlParameter[] pars = new SqlParameter[4];

            pars[0] = new SqlParameter("@MaDD", SqlDbType.NChar, 5);
            pars[0].Value = objDD.MaDD;

            pars[1] = new SqlParameter("@DiemDen", SqlDbType.NChar, 30);
            pars[1].Value = objDD.DiemDen;

            pars[2] = new SqlParameter("@DiemDi", SqlDbType.NChar, 30);
            pars[2].Value = objDD.DiemDi;

            pars[3] = new SqlParameter("@Manv", SqlDbType.NChar, 5);
            pars[3].Value = objDD.Manv;

            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool Xoa(string MaDD)
        {
            string strDel = "delete from DuongDi where MaDD = '" + MaDD + "'";
            return ConnectSQL.ThucHien(strDel);
        }

    }
}
