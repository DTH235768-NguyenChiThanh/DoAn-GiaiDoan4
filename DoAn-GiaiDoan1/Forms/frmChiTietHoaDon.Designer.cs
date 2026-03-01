namespace DoAn_GiaiDoan1.Forms
{
    partial class frmChiTietHoaDon
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            cbNhanVien = new ComboBox();
            cbKhachHang = new ComboBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cbTenPhong = new ComboBox();
            cbLoaiPhong = new ComboBox();
            cbDichVu = new ComboBox();
            datGioVao = new DateTimePicker();
            datGioRa = new DateTimePicker();
            dataGridView1 = new DataGridView();
            btnLuu = new Button();
            btnIn = new Button();
            btnThoat = new Button();
            label8 = new Label();
            numericUpDown1 = new NumericUpDown();
            ID = new DataGridViewTextBoxColumn();
            TenPhong = new DataGridViewTextBoxColumn();
            LoaiPhong = new DataGridViewTextBoxColumn();
            GioVao = new DataGridViewTextBoxColumn();
            GioRa = new DataGridViewTextBoxColumn();
            TenDV = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbKhachHang);
            groupBox1.Controls.Add(cbNhanVien);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 132);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hoá đơn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 34);
            label1.Name = "label1";
            label1.Size = new Size(126, 19);
            label1.TabIndex = 0;
            label1.Text = "Nhân Viên Lập (*):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 87);
            label2.Name = "label2";
            label2.Size = new Size(110, 19);
            label2.TabIndex = 1;
            label2.Text = "Khách Hàng (*):";
            // 
            // cbNhanVien
            // 
            cbNhanVien.FormattingEnabled = true;
            cbNhanVien.Location = new Point(189, 31);
            cbNhanVien.Name = "cbNhanVien";
            cbNhanVien.Size = new Size(583, 27);
            cbNhanVien.TabIndex = 2;
            // 
            // cbKhachHang
            // 
            cbKhachHang.FormattingEnabled = true;
            cbKhachHang.Location = new Point(189, 84);
            cbKhachHang.Name = "cbKhachHang";
            cbKhachHang.Size = new Size(583, 27);
            cbKhachHang.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(datGioRa);
            groupBox2.Controls.Add(datGioVao);
            groupBox2.Controls.Add(cbDichVu);
            groupBox2.Controls.Add(cbLoaiPhong);
            groupBox2.Controls.Add(cbTenPhong);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 163);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(794, 321);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết hoá đơn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 40);
            label3.Name = "label3";
            label3.Size = new Size(77, 19);
            label3.TabIndex = 1;
            label3.Text = "Tên Phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(207, 40);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 2;
            label4.Text = "Loại Phòng:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(403, 40);
            label5.Name = "label5";
            label5.Size = new Size(110, 19);
            label5.TabIndex = 3;
            label5.Text = "Sử dụng dịch vụ:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 114);
            label6.Name = "label6";
            label6.Size = new Size(60, 19);
            label6.TabIndex = 4;
            label6.Text = "Giờ vào:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(239, 114);
            label7.Name = "label7";
            label7.Size = new Size(50, 19);
            label7.TabIndex = 5;
            label7.Text = "Giờ ra:";
            // 
            // cbTenPhong
            // 
            cbTenPhong.FormattingEnabled = true;
            cbTenPhong.Location = new Point(20, 62);
            cbTenPhong.Name = "cbTenPhong";
            cbTenPhong.Size = new Size(169, 27);
            cbTenPhong.TabIndex = 6;
            // 
            // cbLoaiPhong
            // 
            cbLoaiPhong.FormattingEnabled = true;
            cbLoaiPhong.Location = new Point(207, 62);
            cbLoaiPhong.Name = "cbLoaiPhong";
            cbLoaiPhong.Size = new Size(178, 27);
            cbLoaiPhong.TabIndex = 7;
            // 
            // cbDichVu
            // 
            cbDichVu.FormattingEnabled = true;
            cbDichVu.Location = new Point(403, 62);
            cbDichVu.Name = "cbDichVu";
            cbDichVu.Size = new Size(182, 27);
            cbDichVu.TabIndex = 8;
            // 
            // datGioVao
            // 
            datGioVao.Location = new Point(84, 107);
            datGioVao.Name = "datGioVao";
            datGioVao.Size = new Size(147, 26);
            datGioVao.TabIndex = 9;
            // 
            // datGioRa
            // 
            datGioRa.Location = new Point(300, 108);
            datGioRa.Name = "datGioRa";
            datGioRa.Size = new Size(158, 26);
            datGioRa.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, TenPhong, LoaiPhong, GioVao, GioRa, TenDV, ThanhTien });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 168);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(788, 150);
            dataGridView1.TabIndex = 11;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(191, 499);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(140, 34);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu Hoá Đơn";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            btnIn.Location = new Point(351, 499);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(139, 34);
            btnIn.TabIndex = 13;
            btnIn.Text = "In Hoá Đơn";
            btnIn.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(516, 499);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 34);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "button3";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(607, 40);
            label8.Name = "label8";
            label8.Size = new Size(60, 19);
            label8.TabIndex = 15;
            label8.Text = "Đơn Giá";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(607, 63);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(159, 26);
            numericUpDown1.TabIndex = 16;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // TenPhong
            // 
            TenPhong.HeaderText = "Tên Phòng";
            TenPhong.Name = "TenPhong";
            // 
            // LoaiPhong
            // 
            LoaiPhong.HeaderText = "Loại Phòng";
            LoaiPhong.Name = "LoaiPhong";
            // 
            // GioVao
            // 
            GioVao.HeaderText = "Giờ Vào";
            GioVao.Name = "GioVao";
            // 
            // GioRa
            // 
            GioRa.HeaderText = "Giờ Ra";
            GioRa.Name = "GioRa";
            // 
            // TenDV
            // 
            TenDV.HeaderText = "Tên Dịch Vụ";
            TenDV.Name = "TenDV";
            // 
            // ThanhTien
            // 
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.Name = "ThanhTien";
            // 
            // frmChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(868, 570);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnThoat);
            Controls.Add(btnIn);
            Controls.Add(btnLuu);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmChiTietHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmChiTietHoaDon";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private ComboBox cbKhachHang;
        private ComboBox cbNhanVien;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private ComboBox cbLoaiPhong;
        private ComboBox cbTenPhong;
        private Button btnThoat;
        private Button btnIn;
        private Button btnLuu;
        private DataGridView dataGridView1;
        private DateTimePicker datGioRa;
        private DateTimePicker datGioVao;
        private ComboBox cbDichVu;
        private Label label8;
        private NumericUpDown numericUpDown1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenPhong;
        private DataGridViewTextBoxColumn LoaiPhong;
        private DataGridViewTextBoxColumn GioVao;
        private DataGridViewTextBoxColumn GioRa;
        private DataGridViewTextBoxColumn TenDV;
        private DataGridViewTextBoxColumn ThanhTien;
    }
}