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
    public partial class frm_DoiMK : Form
    {
        private DataTable TTNV;
        public frm_DoiMK(DataTable ttNV)
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            btnDoiMK.BackColor = Color.Transparent;
            TTNV = ttNV;
        }
   
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            bool kq = false;
            if(txbNewMK.Text.Trim() == txbCofirmNewMK.Text.Trim() && txbCurrentMK.Text.Trim() == TTNV.Rows[0]["MatKhau"].ToString().Trim())
            {
                kq = ConnectSQL.ActNhanVien.CapNhatMK(txbNewMK.Text, TTNV.Rows[0]["MaNV"].ToString());
                if (kq)
                {
                    MessageBox.Show("Mật khẩu của bạn đã được thay đổi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("đổi mật khẩu thất bại");
                
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không trùng khớp. Vui lòng thử lại.", "Lỗi Thay Đổi Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_DoiMK_Load(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
