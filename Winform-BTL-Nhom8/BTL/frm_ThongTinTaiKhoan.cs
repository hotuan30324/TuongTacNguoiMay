using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frm_ThongTinTaiKhoan : Form
    {
        public frm_ThongTinTaiKhoan()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            rbNam.BackColor = Color.Transparent;
            rbNu.BackColor = Color.Transparent;
            btnCapNhat.BackColor = Color.Transparent;
            btnDoiMK.BackColor = Color.Transparent;
            
        }

        private string manv = "";
        public string MANV
        {
            get { return manv; }
            set { manv = value; }
        }
        private DataTable TT;
        private void HienThiChiTietNhanVien()
        {
            //Lấy thông tin theo mã nv ở frm trước
            TT = ConnectSQL.ActNhanVien.ChiTietTheoMa(MANV);
            
            if (TT.Rows.Count > 0)
            {
                txtMaNV.Text = ""+TT.Rows[0]["MaNV"];
                txtTenNV.Text = "" + TT.Rows[0]["TenNhanVien"];
                txtSDT.Text = "" + TT.Rows[0]["SoDT"];
                txtDiaChi.Text = "" + TT.Rows[0]["DiaChi"];
                txtTaiKhoan.Text = "" + TT.Rows[0]["TaiKhoan"];
                txtChucVu.Text = "" + TT.Rows[0]["ChucVu"];

                DateTime NgaySinh;
                DateTime.TryParse("" + TT.Rows[0]["NgaySinh"], out NgaySinh);
                dtpNgaySinh.Value = NgaySinh;

                string GioiTinh = "" + TT.Rows[0]["GioiTinh"];
                if (GioiTinh == "1") rbNam.Checked = true;
                if (GioiTinh == "0") rbNu.Checked = true;
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            frm_DoiMK frmdmk = new frm_DoiMK(TT);
            frmdmk.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
            NhanVien objNV = new NhanVien();

            objNV.MaNV = txtMaNV.Text;
            objNV.SDT = txtSDT.Text;
            objNV.TenNhanVien = txtTenNV.Text;
            objNV.DiaChi = txtDiaChi.Text;
            objNV.ChucVu = txtChucVu.Text;
            objNV.NgaySinh = dtpNgaySinh.Value;
            objNV.TaiKhoan = txtTaiKhoan.Text;
            if (rbNam.Checked) objNV.GioiTinh = 1;
            else objNV.GioiTinh = 0;

            bool kq = ConnectSQL.ActNhanVien.CapNhat(objNV);

            if (kq) MessageBox.Show("Cập nhật thông tin thành công");
            HienThiChiTietNhanVien();
           

        }



        private void frm_ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiChiTietNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
