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
        string imagesFolder = Path.Combine(
    Directory.GetParent(Application.StartupPath).Parent.Parent.FullName,
    "Images"
);
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
        public void LayLoaiPhong()
        {
            cbLoaiPhong.DataSource = context.LoaiPhong.ToList();
            cbLoaiPhong.ValueMember = "ID";
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyThem = true;
            BatTatChucNang(true);
            txtTenPhong.Clear();
            txtGiaGio.Clear();
            cbLoaiPhong.Text = "";
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

            if (string.IsNullOrWhiteSpace(txtTenPhong.Text) ||
            string.IsNullOrWhiteSpace(txtGiaGio.Text) ||
            string.IsNullOrWhiteSpace(cbLoaiPhong.Text) ||
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
            LayLoaiPhong();
            dataGridView1.AutoGenerateColumns = false;


            List<DanhSachPhong> p = new List<DanhSachPhong>();
            
            p = context.Phong.Select(r=> new DanhSachPhong
            {
                ID = r.ID,
                TenPhong = r.TenPhong,
                LoaiPhongID = r.LoaiPhongID,
                GiaGio = r.GiaGio,
                TenLoaiPhong = r.LoaiPhong.TenLoaiPhong,
                TrangThai = r.TrangThai,
                //inhAnh = r.HinhAnh
                HinhAnh = (!string.IsNullOrEmpty(r.HinhAnh) &&
                   File.Exists(Path.Combine(imagesFolder, r.HinhAnh)))
                   ? Image.FromFile(Path.Combine(imagesFolder, r.HinhAnh))
                   : null
            }).ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = p;
           
            txtTenPhong.DataBindings.Clear();
            txtTenPhong.DataBindings.Add("Text",bindingSource, "TenPhong", false, DataSourceUpdateMode.Never);
            txtGiaGio.DataBindings.Clear();
            txtGiaGio.DataBindings.Add("Text", bindingSource, "GiaGio", true, DataSourceUpdateMode.Never);
            cbLoaiPhong.DataBindings.Clear();
            cbLoaiPhong.DataBindings.Add("SelectedValue", bindingSource, "LoaiPhongID", false, DataSourceUpdateMode.Never);
           
            
            picHinhAnh.DataBindings.Clear();

            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh",false, DataSourceUpdateMode.Never);

            hinhAnh.Format += (s, e) =>
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    string fullPath = Path.Combine(imagesFolder, e.Value.ToString());
                    if (File.Exists(fullPath))
                        e.Value = fullPath;
                    else
                        e.Value = null;
                }
                else
                {
                    e.Value = null;
                }
            };

            picHinhAnh.DataBindings.Add(hinhAnh); 
           
           
            //picHinhAnh.DataBindings.Add("Image", bindingSource, "HinhAnh");
            dataGridView1.DataSource = bindingSource;
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
                    dataGridView1.CurrentRow.Cells["TenLoaiPhong"].Value.ToString();

                string trangThai =
                    dataGridView1.CurrentRow.Cells["TrangThai"].Value.ToString();

                rdbTrong.Checked = trangThai == "Trống";
                rdbĐangDung.Checked = trangThai == "Đang dùng";
                rdbBaoTri.Checked = trangThai == "Bảo trì";
            }
        }

       /*rivate void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            /* if (dataGridView1.Columns[e.ColumnIndex].Name == "HinhAnh")
             {
                 Image image = Image.FromFile(Path.Combine(imagesFolder, e.Value.ToString()));
                 image = new Bitmap(image, 24, 24);
                 e.Value = image;
             }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                if (e.Value != null)
                {
                    string fullPath = Path.Combine(imagesFolder, e.Value.ToString());

                    if (File.Exists(fullPath))
                    {
                        Image image = Image.FromFile(fullPath);
                        image = new Bitmap(image, 24, 24);
                        e.Value = image;
                    }
                    else
                    {
                        e.Value = null;
                    }
                }
            }


        }*/
       

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BatTatChucNang(true);
                xulyThem = false;
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
                picHinhAnh.ImageLocation = fileSavePath;

            }
        }
    }
}
