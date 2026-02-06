using DoAn_GiaiDoan1.Data;
using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_GiaiDoan1.Forms
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();

        }
        QLQKOKDbContext context = new QLQKOKDbContext();
        bool xulyThem = false;
        int id;
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Images");
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;
            txtTenPhong.Enabled = giaTri;
            rdbTrong.Enabled = giaTri;
            txtGiaGio.Enabled = giaTri;
            rdbĐangDung.Enabled = giaTri;
            rdbBaoTri.Enabled = giaTri;
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyThem = true;
            BatTatChucNang(true);
            txtTenPhong.Clear();
            txtGiaGio.Clear();
            cbLoaiPhong.SelectedIndex = -1;
            rdbTrong.Checked = false;
            rdbĐangDung.Checked = false;
            rdbBaoTri.Checked = false;
            picHinhAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDPhong"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTenPhong.Text) || string.IsNullOrWhiteSpace(txtGiaGio.Text) ||
                cbLoaiPhong.SelectedIndex == -1 ||
                !(rdbTrong.Checked || rdbĐangDung.Checked || rdbBaoTri.Checked))

                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string trangThai =
                    rdbTrong.Checked ? "Trống" :
                    rdbĐangDung.Checked ? "Đang dùng" : "Bảo trì";
                if (!decimal.TryParse(txtGiaGio.Text, out decimal giaGio))
                {
                    MessageBox.Show("Vui lòng nhập giá giờ hợp lệ", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (xulyThem)
                {
                    Phong p = new Phong();
                    p.TenPhong = txtTenPhong.Text;
                    p.GiaGio = giaGio;
                    p.TrangThai = trangThai;
                    p.LoaiPhongID = (int)cbLoaiPhong.SelectedValue;
                    

                    context.Phong.Add(p);
                    context.SaveChanges();
                }
                else
                {
                    Phong p = context.Phong.Find(id);
                    if (p != null)
                    {
                        p.TenPhong = txtTenPhong.Text;
                        p.GiaGio = giaGio;
                        p.TrangThai = trangThai;
                        p.LoaiPhongID = (int)cbLoaiPhong.SelectedValue;
                        context.Phong.Update(p);
                        context.SaveChanges();
                    }
                }
                frmPhong_Load_1(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa phòng?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDPhong"].Value.ToString());
                Phong p = context.Phong.Find(id);
                if (p != null)
                {
                    context.Phong.Remove(p);
                }
                context.SaveChanges();
                frmPhong_Load_1(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmPhong_Load_1(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhong_Load_1(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView1.AutoGenerateColumns = false;


            List<Phong> p = new List<Phong>();
            /*p = context.Phong.Select(r => new Phong
            {
                ID= r.ID,
                TenPhong = r.TenPhong,
                GiaGio = r.GiaGio,
                LoaiPhong = r.LoaiPhong.TenLoaiPhong,
                LoaiPhongID = r.LoaiPhongID,
                TrangThai = r.TrangThai,
                HinhAnh = r.HinhAnh
            }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = p*/
            var dsPhong = from ph in context.Phong
                          join lp in context.LoaiPhong
                          on ph.LoaiPhongID equals lp.ID
                          select new
                          {
                              ph.ID,
                              ph.TenPhong,
                              ph.GiaGio,
                              LoaiPhong = lp.TenLoaiPhong,
                              ph.LoaiPhongID,
                              TrangThai = ph.TrangThai,
                              ph.HinhAnh 
                  
                          };

            BindingSource bs = new BindingSource();
            bs.DataSource = dsPhong.ToList();
            dataGridView1.DataSource = bs;
           /* BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = p;*/
            txtTenPhong.DataBindings.Clear();
            txtTenPhong.DataBindings.Add("Text", bs, "TenPhong", false, DataSourceUpdateMode.Never);
            txtGiaGio.DataBindings.Clear();
            txtGiaGio.DataBindings.Add("Text", bs, "GiaGio", false, DataSourceUpdateMode.Never);
            cbLoaiPhong.DataSource = context.LoaiPhong.ToList();
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.ValueMember = "ID";
            cbLoaiPhong.SelectedIndex = -1;

            picHinhAnh.DataBindings.Clear();
            Binding imgBind = new Binding("ImageLocation", bs, "HinhAnh");
            imgBind.Format += (s, e2) =>
            {
                if (e2.Value != null)
                    e2.Value = Path.Combine(imagesFolder, e2.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(imgBind);

// dataGridView1.DataSource = bindingSource;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTenPhong.Text =
                    dataGridView1.CurrentRow.Cells["TenPhong"].Value.ToString();

                txtGiaGio.Text =
                    dataGridView1.CurrentRow.Cells["GiaGio"].Value.ToString();

                cbLoaiPhong.Text =
                    dataGridView1.CurrentRow.Cells["LoaiPhong"].Value.ToString();

                string trangThai =
                    dataGridView1.CurrentRow.Cells["TrangThai"].Value.ToString();

                rdbTrong.Checked = trangThai == "Trống";
                rdbĐangDung.Checked = trangThai == "Đang dùng";
                rdbBaoTri.Checked = trangThai == "Bảo trì";
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                Image image = Image.FromFile(Path.Combine(imagesFolder, e.Value.ToString()));
                image = new Bitmap(image, 24, 24);
                e.Value = image;
            }


        }
       

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);
                string fileSavePath = Path.Combine(imagesFolder, fileName.GenerateSlug() + ext);
                File.Copy(openFileDialog.FileName, fileSavePath, true);
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDPhong"].Value.ToString());
                Phong p = context.Phong.Find(id);
                p.HinhAnh = fileName.GenerateSlug() + ext;
                context.Phong.Update(p);
                context.SaveChanges();
                frmPhong_Load_1(sender, e);
            }
        }
    }
}
