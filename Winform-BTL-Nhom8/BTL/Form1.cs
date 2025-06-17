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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            btnDangNhap.BackColor = Color.Transparent;
        }


        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            if(Login(tk,mk))
            {
                string manv = GetMaNV(tk,mk);
                Form2 f = new Form2(manv);
                f.manvf1 = manv;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }    
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Login(string tk, string mk)
        {
            string sqlstr = "select * from NhanVien where TaiKhoan = N'" + tk + "' and MatKhau = N'" + mk + "'";
            DataTable kq = ConnectSQL.GetData(sqlstr);
            return kq.Rows.Count > 0;
        }

        private string GetMaNV(string tk, string mk)
        {
            string sqlstr = "select * from NhanVien where TaiKhoan = N'" + tk + "' and MatKhau = N'" + mk + "'";
            DataTable kq = ConnectSQL.GetData(sqlstr);
            string manv = kq.Rows[0]["MaNV"].ToString();
            return manv;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
