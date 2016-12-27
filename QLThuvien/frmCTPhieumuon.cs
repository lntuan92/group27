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
    public partial class frmCTPhieumuon : Form
    {
        public string mapm;
        public string tendg;
        public string madg;
        Database db = new Database();
        public frmCTPhieumuon(string MAPM, string MADG, string TENDG)
        {
            InitializeComponent();
            mapm = MAPM;
            madg = MADG;
            tendg = TENDG;
        }
        public void HienThiDanhSach_SachNguon()
        {
            DataTable dt_s;
            dt_s = db.Docbang("Select * from Sach"); 

            cboSachNguon.DataSource = dt_s;
            cboSachNguon.DisplayMember = "Tensach";
            cboSachNguon.ValueMember = "Masach";
        }

        public void HienThiDanhSach_SachChon()
        {
            DataTable dt_schon;
            dt_schon = db.Docbang("Select * from SACH s, PHIEUMUONSACH pm, CHITIETPHIEUMUON ct where s.masach=ct.masach and ct.maphieumuon=pm.maphieumuon and madocgia="+madg); //lấy tất cả sách mà độc giả đã mượn
            lsvSachChon.Items.Clear();
            lsvSachChon.View = View.Details;
            for (int i = 0; i < dt_schon.Rows.Count; i++)
            {
                ListViewItem lvi;
                lvi = lsvSachChon.Items.Add(dt_schon.Rows[i][0].ToString());
                lvi.SubItems.Add(dt_schon.Rows[i]["TenSach"].ToString());
            }
        }
        private void frmCTPhieumuon_Load(object sender, EventArgs e)
        {
            lblMaPM.Text = mapm;
            lblTenDG.Text = tendg;
            
            HienThiDanhSach_SachNguon();//DS cac quyen sach trong commbo
            HienThiDanhSach_SachChon();//Nhung quyen sach da muon trong listview
          
        }

        private void btnHuyCT_Click(object sender, EventArgs e)
        {
            Close();
        }
        //kiem tra mot item co tồn tại trong listview ?? dùng để xem độc giả có mượn trùng sách hay không?
        bool Dachon(string item, ListView lv)
        {
            for (int i = 0; i < lv.Items.Count; i++)
                if (item.Equals(lv.Items[i].Text))
                    return false;
            return true;
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lsvSachChon.Items.Count >= 3)
            {
                MessageBox.Show("Mỗi Độc giả chỉ được mượn tối đa 3 quyển");
                return;
            }
            if (Dachon(cboSachNguon.SelectedValue.ToString(), lsvSachChon)==true)
            {
                ListViewItem lviSachChon = lsvSachChon.Items.Add(cboSachNguon.SelectedValue.ToString());
                lviSachChon.SubItems.Add(cboSachNguon.Text);
                //thêm mới sách vào chi tiết phiếu mượn
                string masach = cboSachNguon.SelectedValue.ToString();                  
                string sql = string.Format("INSERT INTO CHITIETPHIEUMUON VALUES({0},{1})", masach, mapm);
                db.Thuchienlenh(sql);
            }
            else
            {
                MessageBox.Show("Sách này đã được chọn rồi, vui lòng chọn sách khác", "Lỗi chọn sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (lsvSachChon.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < lsvSachChon.SelectedIndices.Count; i++)
                {
                    string masach=lsvSachChon.SelectedItems[i].SubItems[0].Text;                     
                    String sql = string.Format("Delete from CHITIETPHIEUMUON where Masach={0} and MaPhieuMuon = {1}", masach, mapm);
                    db.Thuchienlenh(sql);
                    lsvSachChon.Items.RemoveAt(lsvSachChon.SelectedIndices[i]);
                }
            }
        }
    }
}
