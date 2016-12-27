using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLThuvien
{
    class Employees
    {
        public int MaNhanVien { get; set; }
        public string HoTenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        //method
        public Employees(int id, string fname, DateTime bday, string add, string pnum)
        {
            this.MaNhanVien = id;
            this.HoTenNhanVien = fname;
            this.NgaySinh = bday;
            this.DiaChi = add;
            this.DienThoai = pnum;
        }
    }
}
