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
    public partial class frmLogin : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        Database db = new Database();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = qlthuvien; Integrated Security = true;";
            cn = new SqlConnection(cnStr);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connect();
            try
            {
                string sql = "select count(*) from [QLThuvien].[dbo].[User] where ID = @id and Password = @pass";
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(new SqlParameter("@id", txtAcc.Text));
                cmd.Parameters.Add(new SqlParameter("@pass", txtPass.Text));
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {//Đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    this.Hide();
                    frmMenu frm = new frmMenu();
                    frm.ShowDialog();
                }
                else
                {
                    lbIncorrect.Text = "ID hoặc password không đúng !";
                    txtAcc.Text = "";
                    txtPass.Text = "";
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

        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            object dummy = null;
            EventArgs dummye = null;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnLogin_Click(dummy, dummye);
            }

        }
    }
}
