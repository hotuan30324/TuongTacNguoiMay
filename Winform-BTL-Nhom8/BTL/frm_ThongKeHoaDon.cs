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
    public partial class frm_ThongKeHoaDon : Form
    {
        public frm_ThongKeHoaDon()
        {
            InitializeComponent();
            loadData();
            countToTalRevenue();
        }
        private void loadData()
        {
            DataTable dt = DAO.ActHoaDon.Instance.getListHoaDon();
            dtgvHoaDon.DataSource = dt;
        }
        private void countToTalRevenue()
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < dtgvHoaDon.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dtgvHoaDon.Rows[i].Cells[11].Value);
                count++;
            }
            totalRevenue.Text = string.Format(string.Format("{0:#,##0.00}", sum.ToString())) ;
            lbSoHD.Text = (count-1).ToString();
        }
        private void dtgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void timHoaDon_Click(object sender, EventArgs e)
        {
            DataTable rs = DAO.ActHoaDon.Instance.timKiemHoaDonbayMaHD(txbMaHD.Text.Trim());
            dtgvHoaDon.DataSource = rs;
        }

        private void txbMaHD_TextChanged(object sender, EventArgs e)
        {
            if(txbMaHD.Text.Trim().Length == 0){
                loadData();
            }
        }

        private void frm_ThongKeHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
