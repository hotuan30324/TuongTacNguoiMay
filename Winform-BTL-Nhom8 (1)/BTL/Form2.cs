using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL
{
    public partial class Form2 : Form
    {
        private string _manvf1 = "";
        public string manvf1
        {
            get { return _manvf1; }
            set { _manvf1 = value; }
        }

        private DataTable _MANV;
        public DataTable MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

        public DataTable TTNV;
        public Form2(string maNV)
        {
            InitializeComponent();
            ActNhanVien dsnv = new ActNhanVien();
            TTNV = dsnv.ChiTietTheoMa(maNV);
            checkShowTab();
        }

        public void checkShowTab()
        {
            if(TTNV.Rows[0]["ChucVu"].ToString().Trim() == "Nhân Viên")
            {
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage2);
                //tabControl1.TabPages.Remove(tabPage4);

                btnQLDD.Visible = false;
                btnQLMB.Visible = false;
                btnQLNV.Visible = false;
            }
            else
            {

            }
        }
        private void btnLichBay_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void btnQLMB_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void thêmĐườngĐiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage5);    

        }

        private void thêmChuyếnBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_ThemChuyenBay frmcb = new frm_ThemChuyenBay();
            //frmcb.ShowDialog();
            tabControl1.SelectTab(tabPage3);

        }

        private void btnMuaVe_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(manvf1);
            frm_BanVeMB frmbv = new frm_BanVeMB(txtMaChuyenBay.Text, manvf1);
            //frm_BanVe frmbv = new frm_BanVe();
            frmbv.ShowDialog();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(tabPage4);
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThongTinTaiKhoan frmTK = new frm_ThongTinTaiKhoan();
            frmTK.MANV = manvf1;
            
            frmTK.ShowDialog();

            //reload lai ds nhanh vien
            HienThiDanhSachNV();
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            HienThiDanhSachNV();


        }

        private void HienThiDanhSachNV()
        {
            string tukhoa = txtTimKiemNV.Text;
            ActNhanVien dsnv = new ActNhanVien();
            DataTable dt = dsnv.TimKiemNhanVien(tukhoa);
            
           /* foreach(DataRow dr in dt.Rows)
            {
                foreach(DataColumn dc in dt.Columns)
                {
                    if (dr[dc].ToString() == "0") dr.SetField(dc, "Nam");
                    else dr.SetField(dc, "Nữ");
                }    

            }*/

            dgrNhanVien.DataSource = dt;
        }

        private void HienThiDanhSachMB()
        {
            ActMayBay dsmb = new ActMayBay();
            DataTable dt = dsmb.GetDataMayBay();
            cbMaMayBay.DataSource = dt;
            cbMaMayBay.DisplayMember = "MaMayBay";
            cbMaMayBay.ValueMember = "MaMayBay";
            dgrMayBay.DataSource = dt;

        }

        private void HienThiDanhSachChuyenBay()
        {
            //DAO.ActChuyenBay rs = new DAO.ActChuyenBay();
            DataTable dt = DAO.ActChuyenBay.Instance.GetDataChuyenBay();
            dtgvChuyenBay.DataSource = dt;
            dtgvCacChuyenBay.DataSource = dt;

            dtgvCacChuyenBay.MultiSelect = false;
            dtgvCacChuyenBay.MultiSelect = true;
            dtgvCacChuyenBay.Rows[0].Selected = true;

            DataGridViewRow row = dtgvChuyenBay.Rows[0];
            string cellValue = row.Cells[0].Value?.ToString();
            if (cellValue == null)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }

            DataRow rowMayBay = this.loadMayBayFromCB(cellValue).Rows[0];

            txtMaChuyenBay.Text = row.Cells[0].Value.ToString();
            txtKhoiHanh.Text = String.Format("{0:d/M/yyyy}", row.Cells[1].Value) + " - " + row.Cells[3].Value.ToString();
            txtMaMayBay.Text = rowMayBay["MaMayBay"].ToString();
            txtLoaiMayBay.Text = rowMayBay["TenMayBay"].ToString();
            txtHangMayBay.Text = rowMayBay["HangSanXuat"].ToString();
            txtSoGhe.Text = (Convert.ToInt32(rowMayBay["SoLuongGhe1"].ToString()) + Convert.ToInt32(rowMayBay["SoLuongGhe2"].ToString())).ToString();
            txtSoGhe1.Text = rowMayBay["SoLuongGhe1"].ToString();
            txtSoGhe2.Text = rowMayBay["SoLuongGhe2"].ToString();
            txtNoiDi.Text = row.Cells[6].Value.ToString();
            txtNoiDen.Text = row.Cells[7].Value.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNV();
            HienThiDanhSachMB();
            HienThiDanhSachChuyenBay();
            HienThiDanhSachDuongDi();
            HienThiDanhSachVe();
            HienThiDanhSachKH();

            loadBindingCBBox();
            
            string manv = manvf1;
            ActNhanVien dsnv = new ActNhanVien();
            DataTable dt = dsnv.TimKiemNhanVien(manv);
            this.Text = dt.Rows[0]["TenNhanVien"].ToString().Trim() + "_" + dt.Rows[0]["ChucVu"].ToString();
 

        }

        private void loadBindingCBBox()
        {
            txtQlCBLoaiMB.DataBindings.Add(new Binding("Text", cbMaMayBay.DataSource, "TenMayBay"));
            txtQlCBHangMB.DataBindings.Add(new Binding("Text", cbMaMayBay.DataSource, "HangSanXuat"));
            txtQlCBSoGheEco.DataBindings.Add(new Binding("Text", cbMaMayBay.DataSource, "SoLuongGhe1"));
            txtQlCBSoGheBu.DataBindings.Add(new Binding("Text", cbMaMayBay.DataSource, "SoLuongGhe2"));

            txtQlCBNoiDi.DataBindings.Add(new Binding("Text", cbMaDuongDi.DataSource, "DiemDi"));
            txtQlCBNoiDen.DataBindings.Add(new Binding("Text", cbMaDuongDi.DataSource, "DiemDen"));

        }
        public void HienThiDanhSachKH()
        {
            DataTable dt = DAO.ActKhachHang.Instance.GetDataKhachHang();
            dtgvKhachHang.DataSource = dt;
        }


        public void HienThiDanhSachVe()
        {
            DataTable dt = DAO.ActVe.Instance.GetDataVe();
            dtgvVe.DataSource = dt;
        }
        public void HienThiDanhSachDuongDi()
        {
            //DAO.ActDuongDi rs = new ;
            DataTable dt = DAO.ActDuongDi.Instance.GetDataDuongDi();
            cbMaDuongDi.DataSource = dt;
            cbMaDuongDi.DisplayMember = "LoTrinh";
            cbMaDuongDi.ValueMember = "MaDD";

            dtgvDuongDi.DataSource = dt;

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frm_AddNhanVien frm_Add = new frm_AddNhanVien();

            frm_Add.ShowDialog();

            HienThiDanhSachNV();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTimKiemLB_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string manv = "";
            frm_AddNhanVien frm_Update = new frm_AddNhanVien();
            
            manv = "" + dgrNhanVien.CurrentRow.Cells["MaNV"].Value;
            frm_Update.MaNV = manv;
            frm_Update.ShowDialog();
            HienThiDanhSachNV();
        }

        private void btnThemMB_Click(object sender, EventArgs e)
        {
            MayBay objMB = new MayBay();

            //Lấy giá trị từ giao diện
            objMB.MaMayBay = txtMaMB.Text;
            objMB.TenMayBay = txtTenMB.Text;
            objMB.HangSanXuat = txtHangSX.Text;
            objMB.SoLuongGhe1 = Convert.ToInt32(txtGhe1.Text);
            objMB.SoLuongGhe2 = Convert.ToInt32(txtGhe2.Text);

            bool kq = false;
            kq = ConnectSQL.ActMayBay.ThemMoi(objMB);
            if (kq)
            {
                MessageBox.Show("Thêm máy bay thành công");
                //reload lại danh sách sau khi thêm
                HienThiDanhSachMB();
            }
        }

        private void btnSuaMB_Click(object sender, EventArgs e)
        {
            string mamb = ""+ dgrMayBay.CurrentRow.Cells[0].Value;

            MayBay objMB = new MayBay();

            //Lấy giá trị từ giao diện
            objMB.MaMayBay = txtMaMB.Text;
            objMB.TenMayBay = txtTenMB.Text;
            objMB.HangSanXuat = txtHangSX.Text;
            objMB.SoLuongGhe1 = Convert.ToInt32(txtGhe1.Text);
            objMB.SoLuongGhe2 = Convert.ToInt32(txtGhe2.Text);

            bool kq = false;
            kq = ConnectSQL.ActMayBay.CapNhat(objMB);
            if (kq)
            {
                MessageBox.Show("Cập nhật máy bay thành công");
                //reload lại danh sách sau khi thêm
                HienThiDanhSachMB();
            }

        }

        private void dgrMayBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //nếu có dữ liệu
            if (e.RowIndex != null && e.RowIndex >= 0 && e.RowIndex < dgrMayBay.Rows.Count - 1)
            {
                DataGridViewRow row = dgrMayBay.Rows[e.RowIndex];
                txtMaMB.Text = row.Cells[0].Value.ToString();
                txtTenMB.Text = row.Cells[1].Value.ToString();
                txtHangSX.Text = row.Cells[2].Value.ToString();
                txtGhe1.Text = row.Cells[3].Value.ToString();
                txtGhe2.Text = row.Cells[4].Value.ToString();
            }    
        }

        private void btnXoaMB_Click(object sender, EventArgs e)
        {
            //Lấy kết quả người dùng nhấn
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //Nếu muốn xóa
            if (dr == DialogResult.Yes)
            {
                //Lấy mã sv
                string MaMB = "" + dgrMayBay.CurrentRow.Cells[0].Value;
                DataTable CB = DAO.ActChuyenBay.Instance.timKiemCBByMaMB(MaMB);
                foreach (DataRow rCB in CB.Rows)
                {
                    DataTable VeCanXoa = DAO.ActVe.Instance.timKiemVeByMaCB(rCB["MaChuyenBay"].ToString());
                    if(VeCanXoa.Rows.Count > 0)
                    {
                        bool kq_3 = DAO.ActHoaDon.Instance.XoaHDByMaVe(VeCanXoa.Rows[0]["MaVe"].ToString());
                    }
                    bool kq_2 = DAO.ActVe.Instance.XoaVeByMaCB(CB.Rows[0]["MaChuyenBay"].ToString());
                    bool kq_4 = DAO.ActChuyenBay.Instance.Xoa(CB.Rows[0]["MaChuyenBay"].ToString());
                }

                bool kq = ConnectSQL.ActMayBay.Xoa(MaMB);
                if (kq)
                {
                    //Reload lại danh sách
                    HienThiDanhSachMB();
                }
                HienThiDanhSachMB();

            }
        }

        private void click_QuanLyChuyenBay(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void dtgvChuyenBay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //nếu có dữ liệu
            if (e.RowIndex != null && e.RowIndex >= 0 && e.RowIndex < dtgvChuyenBay.Rows.Count - 1)
            {
                DataGridViewRow row = dtgvChuyenBay.Rows[e.RowIndex];
                DataRow rowMayBay = this.loadMayBayFromCB(row.Cells[0].Value.ToString()).Rows[0];
             
                txtMaChuyenBay.Text = row.Cells[0].Value.ToString();
                txtKhoiHanh.Text = String.Format("{0:d/M/yyyy}", row.Cells[1].Value) +  " - " + row.Cells[3].Value.ToString();
                txtMaMayBay.Text = rowMayBay["MaMayBay"].ToString();
                txtLoaiMayBay.Text = rowMayBay["TenMayBay"].ToString();
                txtHangMayBay.Text = rowMayBay["HangSanXuat"].ToString();
                txtSoGhe.Text = (Convert.ToInt32(rowMayBay["SoLuongGhe1"].ToString()) + Convert.ToInt32(rowMayBay["SoLuongGhe2"].ToString())).ToString();
                txtSoGhe1.Text = rowMayBay["SoLuongGhe1"].ToString();
                txtSoGhe2.Text = rowMayBay["SoLuongGhe2"].ToString();
                txtNoiDi.Text = row.Cells[6].Value.ToString();
                txtNoiDen.Text = row.Cells[7].Value.ToString();

            }
        }

        private DataTable loadMayBayFromCB(string maCB)
        {
            //DAO.ActChuyenBay rs = new DAO.ActChuyenBay();
            DataTable dt = DAO.ActChuyenBay.Instance.getMayBayFromChuyyenBay(maCB);
            return dt;
        }

        private void txtLoaiMayBay_Click(object sender, EventArgs e)
        {

        }

        private void dtgvCacChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != null && e.RowIndex >= 0 && e.RowIndex < dtgvCacChuyenBay.Rows.Count -1)
            {
                
                DataGridViewRow row = dtgvCacChuyenBay.Rows[e.RowIndex];
                DataRow rowMayBay = this.loadMayBayFromCB(row.Cells[0].Value.ToString()).Rows[0];

                txbMaChuyenBay.Text = row.Cells[0].Value.ToString();
                dtpNgayDi.Value = Convert.ToDateTime(row.Cells[1].Value);
                dtNgayDen.Value = Convert.ToDateTime(row.Cells[2].Value);
                dtGioDi.Value = Convert.ToDateTime(row.Cells[3].Value);
                txtQlCBLoaiMB.Text = rowMayBay["TenMayBay"].ToString();
                txtQlCBHangMB.Text = rowMayBay["HangSanXuat"].ToString();
                txtQlCBSoGheEco.Text = (Convert.ToInt32(rowMayBay["SoLuongGhe1"].ToString()) + Convert.ToInt32(rowMayBay["SoLuongGhe2"].ToString())).ToString();
                txtQlCBNoiDi.Text = row.Cells[6].Value.ToString();
                txtQlCBNoiDen.Text = row.Cells[7].Value.ToString();
                txbchuyenBayNote.Text = row.Cells[8].Value.ToString();

                cbMaDuongDi.SelectedIndex = cbMaDuongDi.FindStringExact(txtQlCBNoiDi.Text.Trim() + "-" + txtQlCBNoiDen.Text.Trim());
                //MessageBox.Show(txtQlCBNoiDi.Text.Trim() + "-" + txtQlCBNoiDen.Text.Trim());
            }
        }

        private void themChuyenBay_Click(object sender, EventArgs e)
        {
            if (DAO.ActChuyenBay.Instance.timChuyenBayByMaCB(txbMaChuyenBay.Text.Trim()).Rows.Count == 0 )
            {
                ChuyenBay objCB = new ChuyenBay();

                if (dtpNgayDi.Value > dtNgayDen.Value)
                {
                    MessageBox.Show("Ngày đi và ngày đến không hợp lệ!");
                    return;
                }

                objCB.MaChuyenBay = txbMaChuyenBay.Text;
                objCB.MaMayBay = cbMaMayBay.SelectedValue.ToString();
                objCB.MaDD = cbMaDuongDi.SelectedValue.ToString();
                objCB.Manv = manvf1;
                //objCB.Manv = MANV.Rows[0]["MaNV"].ToString().Trim();
                objCB.NgayDi = dtpNgayDi.Value;
                objCB.NgayDen = dtNgayDen.Value;
                objCB.GioDi = dtGioDi.Text;
                objCB.Ghichu = txbchuyenBayNote.Text;


                bool kq = false;
                kq = DAO.ActChuyenBay.Instance.ThemMoi(objCB);

                if (kq)
                {
                    MessageBox.Show("Thêm chuyến bay thành công");
                    HienThiDanhSachChuyenBay();
                }
            }
            else
            {
                MessageBox.Show("Mã chuyến bay đã tồn tại");
            }



        }
        private void suaChuyenBay_Click(object sender, EventArgs e)
        {
            ChuyenBay objCB = new ChuyenBay();

            objCB.MaChuyenBay = txbMaChuyenBay.Text;
            objCB.MaMayBay = cbMaMayBay.SelectedValue.ToString();
            objCB.MaDD = cbMaDuongDi.SelectedValue.ToString();
            //objCB.Manv = MANV.Rows[0]["MaNV"].ToString().Trim();
            objCB.Manv = manvf1;
            objCB.NgayDi = dtpNgayDi.Value;
            objCB.NgayDen = dtNgayDen.Value;
            objCB.GioDi = dtGioDi.Text;
            objCB.Ghichu = txbchuyenBayNote.Text;


            bool kq = false;
            kq = DAO.ActChuyenBay.Instance.CapNhat(objCB);

            if (kq)
            {
                MessageBox.Show("Cập nhật chuyến bay thành công");
                HienThiDanhSachChuyenBay();
            }
        }

        private void xoaChuyenBay_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string MaCB = txbMaChuyenBay.Text;

                DataTable CB = DAO.ActChuyenBay.Instance.timChuyenBayByMaCB(MaCB);
                DataTable VeCanXoa = DAO.ActVe.Instance.timKiemVeByMaCB(MaCB);

                bool kq_3 = DAO.ActHoaDon.Instance.XoaHDByMaVe(VeCanXoa.Rows[0]["MaVe"].ToString());
                bool kq_2 = DAO.ActVe.Instance.XoaVeByMaCB(MaCB);
                bool kq = DAO.ActChuyenBay.Instance.Xoa(MaCB);


                if (kq && kq_2 && kq_3)
                {
                    HienThiDanhSachChuyenBay();
                }
                HienThiDanhSachChuyenBay();

            }
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void cbMaDuongDi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMaDuongDi_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;
            //string MaDD = cb.SelectedValue.ToString();
            //MessageBox.Show(MaDD);
        }

        private void cbMaMayBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;
            //MayBay mb = cb.SelectedItem as MayBay;
            //txtQlCBLoaiMB.Text = mb.TenMayBay.ToString();
        }

        private void btnQLDD_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage5);
        }

        private void dtgvDuongDi_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dtgvDuongDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != null && e.RowIndex >=0 && e.RowIndex < dtgvDuongDi.Rows.Count - 1)
            {

                DataGridViewRow row = dtgvDuongDi.Rows[e.RowIndex];

                txbMaDuongDi.Text = row.Cells[0].Value.ToString();
                txbDiemDi.Text = row.Cells[1].Value.ToString();
                txbDiemDen.Text = row.Cells[2].Value.ToString();

                cbMaDuongDi.SelectedIndex = cbMaDuongDi.FindStringExact(txtQlCBNoiDi.Text.Trim() + "-" + txtQlCBNoiDen.Text.Trim());
            }
        }

        private void themDuongDi_Click(object sender, EventArgs e)
        {
            if (DAO.ActDuongDi.Instance.checkDuongDi(txbMaDuongDi.Text.Trim()).Rows.Count == 0)
            {
                DuongDi objDD = new DuongDi();

                objDD.MaDD = txbMaDuongDi.Text;
                objDD.DiemDi = txbDiemDi.Text;
                objDD.DiemDen = txbDiemDen.Text;
                //objDD.Manv = MANV.Rows[0]["MaNV"].ToString().Trim();
                objDD.Manv = manvf1;

                bool kq = false;
                kq = DAO.ActDuongDi.Instance.ThemMoi(objDD);

                if (kq)
                {
                    MessageBox.Show("Thêm đường đi thành công");
                    HienThiDanhSachDuongDi();
                }
            }
            else
            {
                MessageBox.Show("Mã đường đi đã tồn tại");
            }


        }

        private void suaDuongDi_Click(object sender, EventArgs e)
        {
            DuongDi objDD = new DuongDi();

            objDD.MaDD = txbMaDuongDi.Text;
            objDD.DiemDi = txbDiemDi.Text;
            objDD.DiemDen = txbDiemDen.Text;
            //objDD.Manv = MANV.Rows[0]["MaNV"].ToString().Trim();
            objDD.Manv = manvf1;

            bool kq = false;
            kq = DAO.ActDuongDi.Instance.CapNhat(objDD);

            if (kq)
            {
                MessageBox.Show("Sửa đường đi thành công");
                HienThiDanhSachDuongDi();
            }
        }

        private void xoaDuongDi_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string MaDD = txbMaDuongDi.Text;

                DataTable CB = DAO.ActChuyenBay.Instance.timKiemCBByMaDD(MaDD);
                foreach(DataRow rCB in CB.Rows)
                {
                    DataTable VeCanXoa = DAO.ActVe.Instance.timKiemVeByMaCB(rCB["MaChuyenBay"].ToString());
                    if (VeCanXoa.Rows.Count > 0)
                    {
                        bool kq_3 = DAO.ActHoaDon.Instance.XoaHDByMaVe(VeCanXoa.Rows[0]["MaVe"].ToString());

                    }

                    bool kq_2 = DAO.ActVe.Instance.XoaVeByMaCB(CB.Rows[0]["MaChuyenBay"].ToString());
                    bool kq_4 = DAO.ActChuyenBay.Instance.Xoa(CB.Rows[0]["MaChuyenBay"].ToString());
                }
                bool kq = DAO.ActDuongDi.Instance.Xoa(MaDD);

                HienThiDanhSachDuongDi();

                //if (kq)
                //{
                //    HienThiDanhSachDuongDi();
                //}
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage7);
        }

        private bool checkSDT(string sdt)
        {
            if(sdt.Length != 10)
            {
                return false;
            }

            return true;
        }
        private void themKhachHang_Click(object sender, EventArgs e)
        {
            if (!checkSDT(txtSdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            DataTable rs = DAO.ActKhachHang.Instance.timKiemKHByMaKH(maKH.Text.Trim());
            if (rs.Rows.Count == 0)
            {
                bool stKH = false;

                KhachHang objKh = new KhachHang();

                objKh.MaKH = maKH.Text;
                objKh.TenKH = tbTenKH.Text;
                objKh.SDT = txtSdt.Text.Trim();
                objKh.DiaChi = tbDiaChi.Text;
                objKh.CMNDHoChieu = tbCMND.Text;
                objKh.QuocTich = tbQuocTich.Text;
                objKh.NgaySinh = dtpNgaySinh.Value;
                if (rbNam.Checked) objKh.GioiTinh = "Nu";
                else objKh.GioiTinh = "Nam";

                stKH = DAO.ActKhachHang.Instance.ThemMoi(objKh);

                if (stKH)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                    HienThiDanhSachKH();
                }
            }
            else
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
            }
          

        }

        private void suaKhachHang_Click(object sender, EventArgs e)
        {
            if (!checkSDT(txtSdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ");
                return;
            }
            bool stKH = false;

            KhachHang objKh = new KhachHang();

            objKh.MaKH = maKH.Text;
            objKh.TenKH = tbTenKH.Text;
            objKh.SDT = txtSdt.Text.Trim();
            objKh.DiaChi = tbDiaChi.Text;
            objKh.CMNDHoChieu = tbCMND.Text;
            objKh.QuocTich = tbQuocTich.Text;
            objKh.NgaySinh = dtpNgaySinh.Value;
            if (rbNam.Checked) objKh.GioiTinh = "Nu";
            else objKh.GioiTinh = "Nam";

            stKH = DAO.ActKhachHang.Instance.CapNhat(objKh);

            if (stKH)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                HienThiDanhSachKH();
            }
            

        }

        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != null && e.RowIndex >= 0 && e.RowIndex < dtgvKhachHang.Rows.Count - 1)
            {
                DataGridViewRow row = dtgvKhachHang.Rows[e.RowIndex];

                txtSdt.Text = row.Cells[2].Value.ToString().Trim();
                maKH.Text = row.Cells[0].Value.ToString().Trim();
                tbTenKH.Text = row.Cells[1].Value.ToString().Trim();
                tbCMND.Text = row.Cells[6].Value.ToString().Trim();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells[3].Value);
                tbDiaChi.Text = row.Cells[5].Value.ToString();
                tbQuocTich.Text = row.Cells[7].Value.ToString().Trim();

                string gioitinh = row.Cells[4].Value.ToString();

                if (gioitinh == "Nu")
                {
                    rbNu.Checked = true;
                }
                else{
                    rbNam.Checked = true;

                }
            }
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void véĐãBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(tabPage6);
            frm_ThongKeVe frmtthd = new frm_ThongKeVe();
            frmtthd.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThongKeHoaDon frmtthd = new frm_ThongKeHoaDon();
            frmtthd.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage6);
        }

        private void dtgvVe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timKiemVe_Click(object sender, EventArgs e)
        {
            DataTable rs = DAO.ActVe.Instance.timKiemVeByMaVeThongKe(tb_TimKiemVe.Text.Trim());
            dtgvVe.DataSource = rs;
        }

        private void loadVe()
        {
            DataTable dt = DAO.ActVe.Instance.GetDataVe();
            lbSoVe.Text = dt.Rows.Count.ToString();
            dtgvVe.DataSource = dt;
        }

        private void tb_TimKiemVe_TextChanged(object sender, EventArgs e)
        {
            if (tb_TimKiemVe.Text.Trim().Length == 0)
            {
                loadVe();
            }
        }
    }
}
