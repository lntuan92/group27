using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLThuvien
{
    class DocGia
    {
        public int MaDocGia { get; set; }
        public string HoTenDocGia { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgayLapThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public double TienNo { get; set; }
        //method
        public DocGia(int id, string fullname, DateTime birthday, string addr, string mail, DateTime ngayLT, DateTime ngayHH, double tienno)
        {
            this.MaDocGia = id;
            this.HoTenDocGia = fullname;
            this.NgaySinh = birthday;
            this.DiaChi = addr;
            this.Email = mail;
            this.NgayLapThe = ngayLT;
            this.NgayHetHan = ngayHH;
            this.TienNo = tienno;
        }
    }
}
