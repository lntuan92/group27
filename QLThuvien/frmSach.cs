using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLThuvien
{
    public partial class frmSach : Form
    {
        SqlConnection cn;
        SqlDataAdapter da;
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = qlthuvien; Integrated Security = true;";
            cn = new SqlConnection(cnStr);
            dgvBook.DataSource = getBook();
        }
        private void connect()
        {
            {
                try
                {
                    if (cn != null && cn.State == ConnectionState.Closed)
                        cn.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void disconnect()
        {
            if (cn != null && cn.State == ConnectionState.Open)
                cn.Close();
        }
        private List<Book> getBook()
        {
            connect();
            List<Book> list = new List<Book>();
            {
                string sql = "select * from SACH";
                da = new SqlDataAdapter(sql, cn);
                SqlCommand cmd = new SqlCommand(sql, cn);//co the viet thanh 3 cau lenh
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = sql;
                //cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();
                string bname, aname, nxb;
                int id, year;
                double price;
                DateTime ngay;
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    bname = dr.GetString(1);
                    aname = dr.GetString(2);
                    year = dr.GetInt32(3);
                    nxb = dr.GetString(4);
                    price = dr.GetDouble(5);
                    ngay = dr.GetDateTime(6);
                    Book b = new Book(id, bname, aname, year, nxb, price, ngay);
                    list.Add(b);
                }
            }
            disconnect();
            return list;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            connect();

            //string sql = "insert into NhanVien (HoNV, Ten, DiaChi, DienThoai) values (N'" + txtHoNV + "', N'" + txtTenNV + "', N'" + txtAddress + "', N'" + txtPhone + "')";
            //SqlCommand cmd = new SqlCommand(sql, cn);
            try
            {
                SqlCommand cmd = new SqlCommand("uspThemSach", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenSach", txtTenSach.Text));
                cmd.Parameters.Add(new SqlParameter("@TacGia", txtTacGia.Text));
                cmd.Parameters.Add(new SqlParameter("@NamXB", txtNamXB.Text));
                cmd.Parameters.Add(new SqlParameter("@NXB", txtNXB.Text));
                cmd.Parameters.Add(new SqlParameter("@price", txtPrice.Text));
                cmd.Parameters.Add(new SqlParameter("@NgayNhap", dtpNgayNhap.Value));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công !");
                dgvBook.DataSource = getBook();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                disconnect();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            connect();
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?","Xóa sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("uspDelBook", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtMaSach.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công !");
                    dgvBook.DataSource = getBook();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                disconnect();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            connect();

            
            try
            {
                if (txtMaSach.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateBook", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", txtTenSach.Text);
                    cmd.Parameters.AddWithValue("@Author", txtTacGia.Text);
                    cmd.Parameters.AddWithValue("@NamXB", txtNamXB.Text);
                    cmd.Parameters.AddWithValue("@NXB", txtNXB.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpNgayNhap.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công !");
                    dgvBook.DataSource = getBook();
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập mã sách cần sửa !");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                disconnect();
            }
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dem = e.RowIndex;    // Lấy số dòng con trỏ chuột click vào hiện tại
                    txtMaSach.Text = dgvBook.Rows[dem].Cells[0].Value.ToString();
                    txtTenSach.Text = dgvBook.Rows[dem].Cells[1].Value.ToString();
                    txtTacGia.Text = dgvBook.Rows[dem].Cells[2].Value.ToString();
                    txtNamXB.Text = dgvBook.Rows[dem].Cells[3].Value.ToString();
                    txtNXB.Text = dgvBook.Rows[dem].Cells[4].Value.ToString();
                    txtPrice.Text = dgvBook.Rows[dem].Cells[5].Value.ToString();
                    dtpNgayNhap.Format = DateTimePickerFormat.Custom;
                    dtpNgayNhap.CustomFormat = "MM/dd/yyyy - dddd";

            dtpNgayNhap.Value = Convert.ToDateTime(dgvBook.Rows[dem].Cells[6].Value.ToString());
                
        }
    }
}
