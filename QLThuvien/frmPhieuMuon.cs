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
    public partial class frmPhieumuon : Form
    {

        Database db = new Database();
        bool cothem = true;
        public frmPhieumuon()
        {
            InitializeComponent();
        }

        private void btnThemDG_Click(object sender, EventArgs e)
        {
            frmDocgia frm = new frmDocgia();
            frm.Show();
        }
        public void HienThiDanhSach()
        {
            string s = "Select MaPhieuMuon, PMS.MaDocGia, DG.HoTenDocGia, NgayMuon from PHIEUMUONSACH PMS, DOCGIA DG where PMS.MaDocGia=DG.MaDocGia Order By MaPhieuMuon";
            DataTable dt = db.Docbang(s);
            lsvPhieuMuon.Items.Clear();
            lsvPhieuMuon.View = View.Details;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvPhieuMuon.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i]["HoTenDocGia"].ToString());
                lvi.SubItems.Add(String.Format("{0:MM/dd/yyyy}", dt.Rows[i]["NgayMuon"].ToString()));
            }
        }

        public void LayDSDocGia()
        {
            DataTable dt = db.Docbang("Select * from docgia");
            cboHoTen.DataSource = dt;
            cboHoTen.DisplayMember = "HoTenDocGia";
            cboHoTen.ValueMember = "MaDocGia";

            if (cboHoTen.Items.Count > 0)
                cboHoTen.SelectedIndex = 0;
        }
        public void setButton(bool value)
        {
            btnThem.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnCTPM.Enabled = value;
            btnThoat.Enabled = value;
        }
        private void frmPhieumuon_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            LayDSDocGia();
            setButton(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cothem = true;
            setButton(false);
        }

        private void lsvPhieuMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                cboHoTen.SelectedIndex = cboHoTen.FindString(lsvPhieuMuon.SelectedItems[0].SubItems[1].Text);
                dtpNgayMuon.Value = DateTime.Parse(lsvPhieuMuon.SelectedItems[0].SubItems[2].Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string mapm = lsvPhieuMuon.SelectedItems[0].SubItems[0].Text;
                    String sql = "Delete from CHITIETPHIEUMUON where MaPhieuMuon = " + mapm;
                    db.Thuchienlenh(sql);
                    sql = "Delete from PHIEUMUONSACH where MaPhieuMuon = " + mapm;
                    db.Thuchienlenh(sql);
                    lsvPhieuMuon.Items.RemoveAt(lsvPhieuMuon.SelectedIndices[0]);
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                cothem = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCTPM_Click(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                //Lấy thông tin về  Mã phiếu mượn (mapm) và tên độc giả (tendg)
                string mapm = lsvPhieuMuon.SelectedItems[0].Text;
                string tendg = lsvPhieuMuon.SelectedItems[0].SubItems[1].Text;
                string madg = cboHoTen.SelectedValue.ToString();
                //và truyền qua form frmChitietPhieuMuon
                frmCTPhieumuon frm = new frmCTPhieumuon(mapm, madg, tendg);
                frm.Show();
            }
            else
                MessageBox.Show("Bạn phải chọn một phiếu mượn để nhập chi tiết");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboHoTen.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn hãy nhập thông tin họ tên", "Thiếu thông tin");
                cboHoTen.Focus();
            }
            else
            {
                string ngaymuon = String.Format("{0:MM/dd/yyyy}", dtpNgayMuon.Value);
                string madg = cboHoTen.SelectedValue.ToString();

                try
                {
                    if (cothem) //là thêm mới
                    {
                        string sql = string.Format("INSERT INTO PHIEUMUONSACH VALUES('{0}',{1})", ngaymuon, madg);
                        db.Thuchienlenh(sql);
                    }

                    else    // là cập nhật
                    {
                        string mapm = lsvPhieuMuon.SelectedItems[0].SubItems[0].Text;
                        string sql = string.Format("Update PHIEUMUONSACH set ngaymuon='{0}',madocgia={1} where MaPhieuMuon = {2}", ngaymuon, madg, mapm);
                        db.Thuchienlenh(sql);
                    }
                    HienThiDanhSach();
                    setButton(true);
                    MessageBox.Show("Thành công");
                }
                catch (DataException de)
                {
                    MessageBox.Show("Có lỗi khi lưu : " + de.ToString());
                }
            }
        }

        private void cboHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboHoTen_Click(object sender, EventArgs e)
        {
            DataTable dt = db.Docbang("Select * from docgia");
            cboHoTen.DataSource = dt;
            cboHoTen.DisplayMember = "HoTenDocGia";
            cboHoTen.ValueMember = "MaDocGia";

            if (cboHoTen.Items.Count > 0)
                cboHoTen.SelectedIndex = 0;
        }


        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không?", "Xóa bằng cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string mapm = lsvPhieuMuon.SelectedItems[0].SubItems[0].Text;
                    String sql = "Delete from CHITIETPHIEUMUON where MaPhieuMuon = " + mapm;
                    db.Thuchienlenh(sql);
                    sql = "Delete from PHIEUMUONSACH where MaPhieuMuon = " + mapm;
                    db.Thuchienlenh(sql);
                    lsvPhieuMuon.Items.RemoveAt(lsvPhieuMuon.SelectedIndices[0]);
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (lsvPhieuMuon.SelectedIndices.Count > 0)
            {
                cothem = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật", "Sửa mẫu tin");
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (cboHoTen.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn hãy nhập thông tin họ tên", "Thiếu thông tin");
                cboHoTen.Focus();
            }
            else
            {
                string ngaymuon = String.Format("{0:MM/dd/yyyy}", dtpNgayMuon.Value);
                string madg = cboHoTen.SelectedValue.ToString();

                try
                {
                    if (cothem) //là thêm mới
                    {
                        string sql = string.Format("INSERT INTO PHIEUMUONSACH VALUES('{0}',{1})", ngaymuon, madg);
                        db.Thuchienlenh(sql);
                    }

                    else    // là cập nhật
                    {
                        string mapm = lsvPhieuMuon.SelectedItems[0].SubItems[0].Text;
                        string sql = string.Format("Update PHIEUMUONSACH set ngaymuon='{0}',madocgia={1} where MaPhieuMuon = {2}", ngaymuon, madg, mapm);
                        db.Thuchienlenh(sql);
                    }
                    HienThiDanhSach();
                    setButton(true);
                    MessageBox.Show("Thành công");
                }
                catch (DataException de)
                {
                    MessageBox.Show("Có lỗi khi lưu : " + de.ToString());
                }
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void btnThemDG_Click_1(object sender, EventArgs e)
        {
            frmDocgia frm = new frmDocgia();
            frm.Show();
        }

        private void cboHoTen_Click_1(object sender, EventArgs e)
        {
            DataTable dt = db.Docbang("Select * from docgia");
            cboHoTen.DataSource = dt;
            cboHoTen.DisplayMember = "HoTenDocGia";
            cboHoTen.ValueMember = "MaDocGia";

            if (cboHoTen.Items.Count > 0)
                cboHoTen.SelectedIndex = 0;
        }
    }
}
