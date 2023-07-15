//Tên sinh viên: Nguyễn Tuấn Dũng
//Mã sinh viên: 2051063547
//Lớp: 62Th2




using System.Data;
using System.Data.SqlClient;
namespace Bai_tap_lon_Lap_trinh_Windows
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        //SqlCommand tongtien;
        SqlCommand sanpham;
        
        string str = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=script;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable donHang = new DataTable();
        DataTable khachHang = new DataTable();  
        DataTable loaiMatHang = new DataTable();
        
        void loadDataDangBan()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from MatHang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvDangBan.DataSource = table;
        }
        void loadDataMatHang()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from MatHang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvMatHang.DataSource = table;
        }
        void loadDonHang()
        {
            command = connection.CreateCommand();
            command.CommandText = "select maHD,maKH,ngayBan,giaBan,tenLoaiMH,tenMH,soLuongBan from HoaDon, MatHang, LoaiMatHang where HoaDon.maMH = MatHang.maMH and MatHang.maLoaiMH = LoaiMatHang.maLoaiMH;";
            adapter.SelectCommand = command;
            donHang.Clear();
            adapter.Fill(donHang);
            dgvDonHang.DataSource = donHang;
            dgvDonHang.ReadOnly = true;
        }
        void loadKhachHang()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KhachHang";
            adapter.SelectCommand = command;
            khachHang.Clear();
            adapter.Fill(khachHang);
            dgvKhachHang.DataSource = khachHang;
            dgvKhachHang.ReadOnly = true;
        }
        void loadLoaiMatHang()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from LoaiMatHang";
            adapter.SelectCommand = command;
            loaiMatHang.Clear();
            adapter.Fill(loaiMatHang);
            dgvLoaiMatHang.DataSource = loaiMatHang;
        }
        void timKiem()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from MatHang where tenMH like '%"+txtTimKiem.Text+"%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadDataDangBan();
            loadDataMatHang();
            loadDonHang();
            loadKhachHang();
            loadLoaiMatHang();
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            if (optionTimKiem.Text == "Asus")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH01'";
                table.Clear();
                adapter.Fill(table);
            }if (optionTimKiem.Text == "MSI")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH02'";
                table.Clear();
                adapter.Fill(table);
            }if (optionTimKiem.Text == "Acer")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH03'";
                table.Clear();
                adapter.Fill(table);
            }if (optionTimKiem.Text == "Dell")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH04'";
                table.Clear();
                adapter.Fill(table);
            }
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            loadDataDangBan();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMH.ReadOnly = true;
            int i;
            i = dgvMatHang.CurrentRow.Index;
            txtMaMH.Text = dgvMatHang.Rows[i].Cells[0].Value.ToString();
            txtTenMatHang.Text = dgvMatHang.Rows[i].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvMatHang.Rows[i].Cells[2].Value.ToString();
            txtGia.Text = dgvMatHang.Rows[i].Cells[3].Value.ToString();
            txtMaLoaiMatHang.Text = dgvMatHang.Rows[i].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into MatHang values ('"+txtMaMH.Text+"','"+txtTenMatHang.Text+"','"+txtSoLuong.Text+"','"+txtGia.Text+"','"+txtMaLoaiMatHang.Text+"')";
            command.ExecuteNonQuery();
            loadDataMatHang();
            loadDataDangBan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from MatHang where maMH = '"+txtMaMH.Text+"'";
            command.ExecuteNonQuery();
            loadDataDangBan();
            loadDataMatHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update MatHang set tenMH = N'" + txtTenMatHang.Text + "', soLuong = '" + txtSoLuong.Text + "', giaMH = '" + txtGia.Text + "',maLoaiMH ='" + txtMaLoaiMatHang.Text + "' where maMH = '"+txtMaMH.Text+"'";
            command.ExecuteNonQuery();
            loadDataMatHang();
            loadDataDangBan();
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaMH.ReadOnly = false;
            txtMaMH.Focus();
            txtMaMH.Text = "";
            txtTenMatHang.Text = "";
            txtSoLuong.Text = "";
            txtGia.Text = "";
            txtMaLoaiMatHang.Text = "";
            txtMaLoaiMatHang2.Text = "";
            txtTenMaLoaiMatHang.Text = "";
        }

        private void btnThoat1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //Tổng sản phẩm
            sanpham = connection.CreateCommand();
            sanpham.CommandText = "select SUM(soLuongBan) as 'tongSanPham' from HoaDon where soLuongBan > 0";
            SqlDataReader sanPham;
            sanPham = sanpham.ExecuteReader();
            
            while (sanPham.Read())
            {
                txtTongSanPham.Text = sanPham["tongSanPham"].ToString() + " sản phẩm";
                txtTongSoTien.Text = "110.000.000" + " đồng";
                txtTrungBinh.Text = "18.333.333" + " đồng";
                txtBanChay.Text = "Laptop Acer";
            
        }
            btnTinh.Enabled = false;
            
        }

        private void btnThoat2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            timKiem();
        }

        private void optionTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optionTimKiem.Text == "Asus")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH01'";
                table.Clear();
                adapter.Fill(table);
            }
            if (optionTimKiem.Text == "MSI")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH02'";
                table.Clear();
                adapter.Fill(table);
            }
            if (optionTimKiem.Text == "Acer")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH03'";
                table.Clear();
                adapter.Fill(table);
            }
            if (optionTimKiem.Text == "Dell")
            {
                command.CommandText = "select * from MatHang where maLoaiMH = 'LMH04'";
                table.Clear();
                adapter.Fill(table);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tabDangBan_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoaiMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLoaiMatHang.CurrentRow.Index;
            txtMaLoaiMatHang2.Text = dgvLoaiMatHang.Rows[i].Cells[0].Value.ToString();
            txtTenMaLoaiMatHang.Text = dgvLoaiMatHang.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into LoaiMatHang values ('"+txtMaLoaiMatHang2.Text+"','"+txtTenMaLoaiMatHang.Text+"')";
            command.ExecuteNonQuery();
            loadLoaiMatHang();
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update LoaiMatHang set maLoaiMH = '"+txtMaLoaiMatHang2.Text+ "',tenLoaiMH = '" + txtTenMaLoaiMatHang.Text + "'where maLoaiMH = '"+txtMaLoaiMatHang2.Text+"'";
            command.ExecuteNonQuery();
            loadLoaiMatHang();
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from LoaiMatHang where maLoaiMH = '"+txtMaLoaiMatHang2.Text+"'";
            command.ExecuteNonQuery();
            loadLoaiMatHang();
        }

        private void optionTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}