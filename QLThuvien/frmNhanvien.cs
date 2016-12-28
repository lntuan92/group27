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
    public partial class frmNhanvien : Form
    {
        SqlConnection cn;
        SqlDataAdapter da;
        public frmNhanvien()
        {
            InitializeComponent();
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

        private void frmNhanvien_Load_1(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = qlthuvien; Integrated Security = true;";
            cn = new SqlConnection(cnStr);
            dgvNhanVien.DataSource = getEmp();
        }
        //Sự kiện khi chọn 1 dòng trên Listview thì nội dung của dòng đó sẽ được nạp lên FORM
        private List<Employees> getEmp()
        {
            connect();
            List<Employees> list = new List<Employees>();
            {
                string sql = "select * from NHANVIEN";
                da = new SqlDataAdapter(sql, cn);
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string fname, add, pnum;
                int id;
                DateTime bday;
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    fname = dr.GetString(1);
                    bday = dr.GetDateTime(2);
                    add = dr.GetString(3);
                    pnum = dr.GetString(4);
                    Employees e = new Employees(id, fname, bday, add, pnum);
                    list.Add(e);
                }
            }
            disconnect();
            return list;
        }


        private void btnSua_Click_1(object sender, EventArgs e)
        {
            connect();
            try
            {
                if (txtMaNV.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateNV", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@phone", txtDienThoai.Text);
                    cmd.Parameters.AddWithValue("@BirthDay", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@add", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("fullname", txtHoten.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công !");
                    dgvNhanVien.DataSource = getEmp();
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập mã nhân viên cần sửa !");
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
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            connect();

            try
            {
                SqlCommand cmd = new SqlCommand("uspThemNhanVien", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fullname", txtHoten.Text));
                cmd.Parameters.Add(new SqlParameter("@birthday", dtpNgaySinh.Value));
                cmd.Parameters.Add(new SqlParameter("@add", txtDiaChi.Text));
                cmd.Parameters.Add(new SqlParameter("@phone", txtDienThoai.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công !");
                dgvNhanVien.DataSource = getEmp();
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
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            connect();
            try
            {
                if (txtMaNV.Text != "")
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("uspXoaNV", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", txtMaNV.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công !");
                        dgvNhanVien.DataSource = getEmp();
                    }
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
    }
}
