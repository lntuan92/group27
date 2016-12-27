using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLThuvien
{
    class Book
    {
        //properties
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int NamXuatBan { get; set; }
        public string NhaXuatBan { get; set; }
        public double TriGia { get; set; }
        public DateTime NgayNhap { get; set; }
        //method
        public Book(int id, string bname, string aname, int year, string nxb, double price, DateTime ngay)
        {
            this.MaSach = id;
            this.TenSach = bname;
            this.TacGia = aname;
            this.NamXuatBan = year;
            this.NhaXuatBan = nxb;
            this.TriGia = price;
            this.NgayNhap = ngay;
        }
    }
}
