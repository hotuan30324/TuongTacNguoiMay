namespace BTL
{
    partial class frm_DoiMK
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCurrentMK = new ZBobb.AlphaBlendTextBox();
            this.txbCofirmNewMK = new ZBobb.AlphaBlendTextBox();
            this.txbNewMK = new ZBobb.AlphaBlendTextBox();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 193);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu hiện tại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 301);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xác nhận mật khẩu:";
            // 
            // txbCurrentMK
            // 
            this.txbCurrentMK.BackAlpha = 10;
            this.txbCurrentMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txbCurrentMK.Location = new System.Drawing.Point(281, 193);
            this.txbCurrentMK.Name = "txbCurrentMK";
            this.txbCurrentMK.Size = new System.Drawing.Size(245, 26);
            this.txbCurrentMK.TabIndex = 1;
            // 
            // txbCofirmNewMK
            // 
            this.txbCofirmNewMK.BackAlpha = 10;
            this.txbCofirmNewMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txbCofirmNewMK.Location = new System.Drawing.Point(281, 301);
            this.txbCofirmNewMK.Name = "txbCofirmNewMK";
            this.txbCofirmNewMK.Size = new System.Drawing.Size(245, 26);
            this.txbCofirmNewMK.TabIndex = 1;
            // 
            // txbNewMK
            // 
            this.txbNewMK.BackAlpha = 10;
            this.txbNewMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txbNewMK.Location = new System.Drawing.Point(281, 244);
            this.txbNewMK.Name = "txbNewMK";
            this.txbNewMK.Size = new System.Drawing.Size(245, 26);
            this.txbNewMK.TabIndex = 1;
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.BackColor = System.Drawing.Color.Transparent;
            this.btnDoiMK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDoiMK.Location = new System.Drawing.Point(319, 357);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(95, 37);
            this.btnDoiMK.TabIndex = 2;
            this.btnDoiMK.Text = "Đổi MK";
            this.btnDoiMK.UseVisualStyleBackColor = false;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.Transparent;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_cancel.Location = new System.Drawing.Point(431, 356);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(95, 37);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "huỷ";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BTL.Properties.Resources.Logo4;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(-1, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 181);
            this.panel1.TabIndex = 4;
            // 
            // frm_DoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(706, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.btnDoiMK);
            this.Controls.Add(this.txbNewMK);
            this.Controls.Add(this.txbCofirmNewMK);
            this.Controls.Add(this.txbCurrentMK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_DoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mk";
            this.Load += new System.EventHandler(this.frm_DoiMK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ZBobb.AlphaBlendTextBox txbCurrentMK;
        private ZBobb.AlphaBlendTextBox txbCofirmNewMK;
        private ZBobb.AlphaBlendTextBox txbNewMK;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Panel panel1;
    }
}