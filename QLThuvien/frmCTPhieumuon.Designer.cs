namespace QLThuvien
{
    partial class frmCTPhieumuon
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
            this.grbChiTiet = new System.Windows.Forms.GroupBox();
            this.cboSachNguon = new System.Windows.Forms.ComboBox();
            this.lsvSachChon = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnHuyCT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTra = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.lblTenDG = new System.Windows.Forms.Label();
            this.lblMaPM = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbChiTiet
            // 
            this.grbChiTiet.Controls.Add(this.cboSachNguon);
            this.grbChiTiet.Controls.Add(this.lsvSachChon);
            this.grbChiTiet.Controls.Add(this.btnHuyCT);
            this.grbChiTiet.Controls.Add(this.label4);
            this.grbChiTiet.Controls.Add(this.label3);
            this.grbChiTiet.Controls.Add(this.btnTra);
            this.grbChiTiet.Controls.Add(this.btnChon);
            this.grbChiTiet.Location = new System.Drawing.Point(30, 156);
            this.grbChiTiet.Name = "grbChiTiet";
            this.grbChiTiet.Size = new System.Drawing.Size(409, 294);
            this.grbChiTiet.TabIndex = 11;
            this.grbChiTiet.TabStop = false;
            this.grbChiTiet.Text = "Chi tiết phiếu mượn - Chọn Sách";
            // 
            // cboSachNguon
            // 
            this.cboSachNguon.FormattingEnabled = true;
            this.cboSachNguon.Location = new System.Drawing.Point(18, 46);
            this.cboSachNguon.Name = "cboSachNguon";
            this.cboSachNguon.Size = new System.Drawing.Size(366, 21);
            this.cboSachNguon.TabIndex = 5;
            // 
            // lsvSachChon
            // 
            this.lsvSachChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvSachChon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12});
            this.lsvSachChon.FullRowSelect = true;
            this.lsvSachChon.Location = new System.Drawing.Point(12, 150);
            this.lsvSachChon.MultiSelect = false;
            this.lsvSachChon.Name = "lsvSachChon";
            this.lsvSachChon.Size = new System.Drawing.Size(373, 120);
            this.lsvSachChon.TabIndex = 4;
            this.lsvSachChon.UseCompatibleStateImageBehavior = false;
            this.lsvSachChon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Mã Sách";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tên Sách";
            this.columnHeader12.Width = 400;
            // 
            // btnHuyCT
            // 
            this.btnHuyCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuyCT.ForeColor = System.Drawing.Color.Purple;
            this.btnHuyCT.Location = new System.Drawing.Point(216, 87);
            this.btnHuyCT.Name = "btnHuyCT";
            this.btnHuyCT.Size = new System.Drawing.Size(169, 34);
            this.btnHuyCT.TabIndex = 3;
            this.btnHuyCT.Text = "Kết thúc nhập chi tiết";
            this.btnHuyCT.UseVisualStyleBackColor = true;
            this.btnHuyCT.Click += new System.EventHandler(this.btnHuyCT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(9, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Các sách độc giả đang còn mượn (chưa trả)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sách đang có";
            // 
            // btnTra
            // 
            this.btnTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTra.ForeColor = System.Drawing.Color.Red;
            this.btnTra.Location = new System.Drawing.Point(109, 87);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(101, 35);
            this.btnTra.TabIndex = 1;
            this.btnTra.Text = "X";
            this.btnTra.UseVisualStyleBackColor = true;
            this.btnTra.Click += new System.EventHandler(this.btnTra_Click);
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnChon.ForeColor = System.Drawing.Color.Blue;
            this.btnChon.Location = new System.Drawing.Point(12, 87);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(91, 35);
            this.btnChon.TabIndex = 1;
            this.btnChon.Text = " ";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // lblTenDG
            // 
            this.lblTenDG.AutoSize = true;
            this.lblTenDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenDG.ForeColor = System.Drawing.Color.Green;
            this.lblTenDG.Location = new System.Drawing.Point(154, 112);
            this.lblTenDG.Name = "lblTenDG";
            this.lblTenDG.Size = new System.Drawing.Size(51, 16);
            this.lblTenDG.TabIndex = 15;
            this.lblTenDG.Text = "label5";
            // 
            // lblMaPM
            // 
            this.lblMaPM.AutoSize = true;
            this.lblMaPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMaPM.Location = new System.Drawing.Point(154, 84);
            this.lblMaPM.Name = "lblMaPM";
            this.lblMaPM.Size = new System.Drawing.Size(51, 16);
            this.lblMaPM.TabIndex = 16;
            this.lblMaPM.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tên Độc Giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã Phiếu Mượn :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(83, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "CHI TIẾT PHIẾU MƯỢN";
            // 
            // frmCTPhieumuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 457);
            this.Controls.Add(this.grbChiTiet);
            this.Controls.Add(this.lblTenDG);
            this.Controls.Add(this.lblMaPM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCTPhieumuon";
            this.Text = "CHI TIẾT PHIẾU MƯỢN";
            this.Load += new System.EventHandler(this.frmCTPhieumuon_Load);
            this.grbChiTiet.ResumeLayout(false);
            this.grbChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbChiTiet;
        private System.Windows.Forms.ComboBox cboSachNguon;
        private System.Windows.Forms.ListView lsvSachChon;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnHuyCT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTra;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Label lblTenDG;
        private System.Windows.Forms.Label lblMaPM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}