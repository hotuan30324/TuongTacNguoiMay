using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    public class ActNhanVien
    {
        public DataTable GetDataNV()
        {
            string strsql = "select MaNV, TenNhanVien,GioiTinh, ChucVu,SoDT,DiaChi,NgaySinh from NhanVien";
            return ConnectSQL.GetData(strsql);
        }
        public DataTable TimKiemNhanVien (string tukhoa)
        {
            //Dùng winform
            
            string strsql = "select MaNV, TenNhanVien, ChucVu,SoDT,DiaChi,NgaySinh from NhanVien where 1=1";
            //Nếu tên có thông tin thì lọc
            if(!string.IsNullOrWhiteSpace(tukhoa))
            {
                strsql += string.Format(" and (MaNV = '{0}' or TenNhanVien like N'%{1}%')",tukhoa,tukhoa);
            }

            //Sử dụng thủ tục
            //string strsql = "execute sp_timkiem N'"+tukhoa+"'";
            return ConnectSQL.GetData(strsql);
        }

        public bool caiDatChucVu(string tk, string mk, string chucvu)
        {
            string chucvu_sql = "MEMBER"; ;
            if(chucvu == "Quản lý")
            {
                chucvu_sql = "QUANLY";
            }
            
            string sqlstr = "EXECUTE dbo.addQuyen " + tk + ", " + mk + ", '" + chucvu_sql + "'";
            SqlParameter[] pars = new SqlParameter[0];

            return ConnectSQL.ThucHien(sqlstr, pars);

        }
        public DataTable ChiTietTheoMa(string manv)
        {
            return ConnectSQL.GetData("select MaNV, TenNhanVien,GioiTinh, ChucVu,SoDT,DiaChi, NgaySinh,TaiKhoan, MatKhau from NhanVien where MaNV = '" + manv + "'");
            
        }

        public bool ThemMoi(NhanVien objNV)
        {
            string sqlstr = "insert into NhanVien(MaNV, TenNhanVien, GioiTinh, DiaChi, NgaySinh, SoDT, ChucVu, TaiKhoan, MatKhau) values (@MaNV, @TenNhanVien,@GioiTinh,@DiaChi,@NgaySinh,@SoDT,@ChucVu,@TaiKhoan,@MatKhau)";
            SqlParameter[] pars = new SqlParameter[9];

            pars[0] = new SqlParameter("@MaNV", SqlDbType.NChar, 5);
            pars[0].Value = objNV.MaNV;

            pars[1] = new SqlParameter("@TenNhanVien", SqlDbType.NChar, 30);
            pars[1].Value = objNV.TenNhanVien;

            pars[2] = new SqlParameter("@GioiTinh", SqlDbType.NChar, 4);
            pars[2].Value = objNV.GioiTinh;

            pars[3] = new SqlParameter("@DiaChi", SqlDbType.NChar, 30);
            pars[3].Value = objNV.DiaChi;

            pars[4] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            pars[4].Value = objNV.NgaySinh;

            pars[5] = new SqlParameter("@SoDT", SqlDbType.NChar, 10);
            pars[5].Value = objNV.SDT;

            pars[6] = new SqlParameter("@ChucVu", SqlDbType.NChar, 10);
            pars[6].Value = objNV.ChucVu;

            pars[7] = new SqlParameter("@TaiKhoan", SqlDbType.NChar, 50);
            pars[7].Value = objNV.TaiKhoan;

            pars[8] = new SqlParameter("@MatKhau", SqlDbType.NChar, 50);
            pars[8].Value = objNV.MatKhau;

            return ConnectSQL.ThucHien(sqlstr, pars);
          
        }


        public bool CapNhat(NhanVien obj)
        {
            string strsql = "update NhanVien set  TenNhanVien = @TenNhanVien, GioiTinh = @GioiTinh,DiaChi = @DiaChi,NgaySinh= @NgaySinh, SoDT= @SoDT , ChucVu = @ChucVu, TaiKhoan = @TaiKhoan where MaNV = @MaNV";

            SqlParameter[] pars = new SqlParameter[9];
            pars[0] = new SqlParameter("@MaNV", SqlDbType.NChar, 5);
            pars[0].Value = obj.MaNV;

            pars[1] = new SqlParameter("@TenNhanVien", SqlDbType.NChar, 30);
            pars[1].Value = obj.TenNhanVien;

            pars[2] = new SqlParameter("GioiTinh", SqlDbType.NChar, 4);
            pars[2].Value = obj.GioiTinh;

            pars[3] = new SqlParameter("DiaChi", SqlDbType.NChar, 30);
            pars[3].Value = obj.DiaChi;

            pars[4] = new SqlParameter("NgaySinh", SqlDbType.DateTime);
            pars[4].Value = obj.NgaySinh;

            pars[5] = new SqlParameter("SoDT", SqlDbType.NChar, 10);
            pars[5].Value = obj.SDT;

            pars[6] = new SqlParameter("ChucVu", SqlDbType.NChar, 10);
            pars[6].Value = obj.ChucVu;

            pars[7] = new SqlParameter("TaiKhoan", SqlDbType.NChar, 50);
            pars[7].Value = obj.TaiKhoan;

            pars[8] = new SqlParameter("MatKhau", SqlDbType.NChar, 50);
            pars[8].Value = obj.MatKhau;

            return ConnectSQL.ThucHien(strsql, pars);
            

        }
        public bool CapNhatMK(string mk, string maNV)
        {
            string strsql = "update NhanVien set MatKhau = @MatKhau where MaNV = @MaNV";


            SqlParameter[] pars = new SqlParameter[2];

            pars[0] = new SqlParameter("@MaNV", SqlDbType.NChar, 5);
            pars[0].Value = maNV;

            pars[1] = new SqlParameter("MatKhau", SqlDbType.NChar, 50);
            pars[1].Value = mk;

            return ConnectSQL.ThucHien(strsql, pars);


        }



        public bool Xoa(string MaNV)
        {
            //Lay manv
            string  strDel = "delete from NhanVien where MaNV = '" + MaNV + "'";
            return ConnectSQL.ThucHien(strDel);
        }
    }
}
