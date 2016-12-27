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
    public partial class frmDocgia : Form
    {
        SqlConnection cn;
        SqlDataAdapter da;
        
        public frmDocgia()
        {
            InitializeComponent();
        }
   
        
        private void frmDocgia_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = qlthuvien; Integrated Security = true;";
            cn = new SqlConnection(cnStr);
            dgvDocGia.DataSource = LayDSDG();
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
        private List<DocGia> LayDSDG()
        {
            connect();
            List<DocGia> list = new List<DocGia>();
            {
                string sql = "select * from DOCGIA";
                da = new SqlDataAdapter(sql, cn);
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string fullname, addr, mail;
                int id;
                double tienno;
                DateTime birthday, ngayLT, ngayHH;
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                    fullname = dr.GetString(1);
                    birthday = dr.GetDateTime(2);
                    addr = dr.GetString(3);
                    mail = dr.GetString(4);
                    ngayLT = dr.GetDateTime(5);
                    ngayHH = dr.GetDateTime(6);
                    tienno = dr.GetDouble(7);
                    DocGia dg = new DocGia(id, fullname, birthday, addr, mail, ngayLT, ngayHH, tienno);
                    list.Add(dg);
                }
            }
            disconnect();
            return list;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            connect();
            try
            {
                SqlCommand cmd = new SqlCommand("uspThemDocGia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@fullname", txtHoten.Text));
                cmd.Parameters.Add(new SqlParameter("@birthday", dtpNgaySinh.Value));
                cmd.Parameters.Add(new SqlParameter("@add", txtDiaChi.Text));
                cmd.Parameters.Add(new SqlParameter("@mail", txtEmail.Text));
                cmd.Parameters.Add(new SqlParameter("@ngayLT", dtpNgaylapthe.Value));
                cmd.Parameters.Add(new SqlParameter("@ngayHH", dtpNgayhethan.Value));
                cmd.Parameters.Add(new SqlParameter("@tienno", txtTienNo.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công !");
                dgvDocGia.DataSource = LayDSDG();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            connect();
            try
            {
                if (txtMaDG.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("uspUpdateDG", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtMaDG.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtHoten.Text);
                    cmd.Parameters.AddWithValue("@BirthDay", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@add", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@ngayLT", dtpNgaylapthe.Value);
                    cmd.Parameters.AddWithValue("@ngayHH", dtpNgayhethan.Value);
                    cmd.Parameters.AddWithValue("@tienno", txtTienNo.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công !");
                    dgvDocGia.DataSource = LayDSDG();
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập mã đọc giả cần sửa !");
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            connect();
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa đọc giả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("uspXoaDG", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtMaDG.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công !");
                    dgvDocGia.DataSource = LayDSDG();
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
    }
}
