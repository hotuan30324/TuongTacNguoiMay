namespace BTL
{
    partial class frm_ThongKeVe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvVe = new System.Windows.Forms.DataGridView();
            this.MaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loaive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timKiemVe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSoVe = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvVe);
            this.panel1.Location = new System.Drawing.Point(4, 133);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 420);
            this.panel1.TabIndex = 0;
            // 
            // dtgvVe
            // 
            this.dtgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVe,
            this.Loaive,
            this.DiemDi,
            this.DiemDen});
            this.dtgvVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvVe.Location = new System.Drawing.Point(0, 0);
            this.dtgvVe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgvVe.Name = "dtgvVe";
            this.dtgvVe.RowHeadersWidth = 51;
            this.dtgvVe.Size = new System.Drawing.Size(1057, 420);
            this.dtgvVe.TabIndex = 3;
            // 
            // MaVe
            // 
            this.MaVe.DataPropertyName = "MaVe";
            this.MaVe.HeaderText = "Mã Vé";
            this.MaVe.MinimumWidth = 6;
            this.MaVe.Name = "MaVe";
            // 
            // Loaive
            // 
            this.Loaive.DataPropertyName = "Loaive";
            this.Loaive.HeaderText = "Loại Vé";
            this.Loaive.MinimumWidth = 6;
            this.Loaive.Name = "Loaive";
            // 
            // DiemDi
            // 
            this.DiemDi.DataPropertyName = "DiemDi";
            this.DiemDi.HeaderText = "Điểm đi";
            this.DiemDi.MinimumWidth = 6;
            this.DiemDi.Name = "DiemDi";
            // 
            // DiemDen
            // 
            this.DiemDen.DataPropertyName = "DiemDen";
            this.DiemDen.HeaderText = "Điểm đến";
            this.DiemDen.MinimumWidth = 6;
            this.DiemDen.Name = "DiemDen";
            // 
            // timKiemVe
            // 
            this.timKiemVe.Location = new System.Drawing.Point(901, 42);
            this.timKiemVe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timKiemVe.Name = "timKiemVe";
            this.timKiemVe.Size = new System.Drawing.Size(129, 36);
            this.timKiemVe.TabIndex = 7;
            this.timKiemVe.Text = "Tìm kiếm";
            this.timKiemVe.UseVisualStyleBackColor = true;
            this.timKiemVe.Click += new System.EventHandler(this.timKiemVe_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(613, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(279, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số vé đã bán:";
            // 
            // lbSoVe
            // 
            this.lbSoVe.AutoSize = true;
            this.lbSoVe.Location = new System.Drawing.Point(124, 52);
            this.lbSoVe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoVe.Name = "lbSoVe";
            this.lbSoVe.Size = new System.Drawing.Size(44, 16);
            this.lbSoVe.TabIndex = 9;
            this.lbSoVe.Text = "label2";
            // 
            // frm_ThongKeVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lbSoVe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timKiemVe);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_ThongKeVe";
            this.Text = "Vé đã bán";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvVe;
        private System.Windows.Forms.Button timKiemVe;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loaive;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemDen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSoVe;
    }
}