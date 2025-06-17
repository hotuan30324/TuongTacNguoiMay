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
    public partial class frm_ThongKeVe : Form
    {
        public frm_ThongKeVe()
        {
            InitializeComponent();
            loadVe();
        }
        private void loadVe()
        {
            DataTable dt = DAO.ActVe.Instance.GetDataVe();
            lbSoVe.Text = dt.Rows.Count.ToString();
            dtgvVe.DataSource = dt;
        }
        private void countToTalRevenue()
        {
        }

        private void timKiemVe_Click(object sender, EventArgs e)
        {
            DataTable rs = DAO.ActVe.Instance.timKiemVeByMaVeThongKe(textBox1.Text.Trim());
            dtgvVe.DataSource = rs;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                loadVe();
            }
        }
    }
   
}
