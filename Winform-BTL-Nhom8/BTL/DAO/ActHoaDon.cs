using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.DAO
{
    class ActHoaDon
    {
        private static ActHoaDon instance;
        public static ActHoaDon Instance
        {
            get { if (instance == null) instance = new ActHoaDon(); return ActHoaDon.instance; }
            private set { ActHoaDon.instance = value; }
        }
        private ActHoaDon() { }

        public DataTable timKiemHoaDonbayMaHD(string maHD)
        {
            string sqlstr = "select * from HoaDon where MaHoaDon='" + maHD + "'";
            return ConnectSQL.GetData(sqlstr);
        }

        //public DataTable timKiemThongKeHoaDon(string MaHD)
        //{
        //    string sqlstr = "SELECT HD.MaHoaDon AS 'Mã Hóa Đơn',KH.MaKH AS 'Mã Khách Hàng', Kh.TenKH AS 'Tên Khách Hàng' ,KH.SDT 'Số Điện Thoại',HD.NgayBan AS 'Ngày Lập Hóa Đơn ', HD.MaNV AS N'Mã Nhân Viên', DD.DiemDi AS 'Điểm Đi' , DD.DiemDen AS  'Điểm Đến', CB.NgayDi AS 'Ngày Đi', CB.NgayDen AS 'Ngày Đến ' ,TTV.Loaive,TTV.GiaVe" +
        //        "FROM HoaDon HD,KhachHang KH, dbo.ChuyenBay CB, dbo.DuongDi DD, ThongTinVe TTV,dbo.NhanVien NV WHERE HD.MaKH = KH.MaKH AND HD.MaVe = TTV.MaVe AND TTV.MaCHuyenBay = CB.MaChuyenBay AND Cb.MAdd = DD.MaDD AND NV.MaNV = HD.MaNV AND HD.MaHoaDon = '" + MaHD + "'";
        //    return ConnectSQL.GetData(sqlstr);
        //}

        public DataTable GetDataHoaDon()
        {
            string sqlstr = "select * from HoaDon AS hd INNER JOIN dbo.ThongTinVe AS ttv ON hd.MaVe = ttv.MaVe INNER JOIN dbo.ChuyenBay AS cb ON ttv.MaCHuyenBay = cb.MaChuyenBay INNER JOIN dbo.KhachHang AS kh ON kh.MaKH = hd.MaKH INNER JOIN dbo.DuongDi AS dd ON dd.MaDD = cb.MaDD"; 
            return ConnectSQL.GetData(sqlstr);
        }

        public DataTable getListHoaDon()
        {
            string sqlstr = "select * from viewhoadon";
            return ConnectSQL.GetData(sqlstr);
        }

        public bool ThemMoi(HoaDon objHD)
        {
            string sqlstr = "insert into HoaDon(MaHoaDon, NgayBan, MaNV, MaKH, MaVe, TongTien) values (@MaHoaDon, @NgayBan,@MaNV,@MaKH,@MaVe,@TongTien)";
            SqlParameter[] pars = new SqlParameter[6];

            pars[0] = new SqlParameter("@MaHoaDon", SqlDbType.NChar, 5);
            pars[0].Value = objHD.MaHoaDon;

            pars[1] = new SqlParameter("@NgayBan", SqlDbType.DateTime);
            pars[1].Value = objHD.NgayBan;

            pars[2] = new SqlParameter("@MaNV", SqlDbType.NChar, 5);
            pars[2].Value = objHD.MaNV;

            pars[3] = new SqlParameter("@MaKH", SqlDbType.NChar, 5);
            pars[3].Value = objHD.MaKH;

            pars[4] = new SqlParameter("@MaVe", SqlDbType.NChar, 5);
            pars[4].Value = objHD.MaVe;

            pars[5] = new SqlParameter("@TongTien", SqlDbType.Int);
            pars[5].Value = objHD.TongTien;

            return ConnectSQL.ThucHien(sqlstr, pars);
        }

        public bool XoaHDByMaVe(string maVe)
        {
            string strDel = "delete from HoaDon where MaVe = '" + maVe + "'";
            return ConnectSQL.ThucHien(strDel);
        }
    }
}
