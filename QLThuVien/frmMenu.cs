using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLThuvien
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNhanvien frm = new frmNhanvien();
            frm.Show();
        }

        private void đọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocgia frm = new frmDocgia();
            frm.Show();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSach frm = new frmSach();
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void phiếuMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieumuon frm = new frmPhieumuon();
            frm.Show();
        }
    }
}
