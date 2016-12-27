using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QLThuvien
{
    class Database
    {
        public SqlConnection cn;
        public Database()
        {
            //Kết nối CSDL không có username, Password
            String cnStr = "Data source=(local); database=QLThuvien; Integrated Security = True";
            //Kết nối CSDL có username, Password
            //String Strcnn = "Data source=   ; database= ; uid = ; pwd= ; Integrated Security = false";
            //Tao Doi tuong ket noi CSDL
            cn = new SqlConnection(cnStr);
        }
        public DataTable Docbang(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void Thuchienlenh(string strSQL)
        {
            SqlCommand cmd = new SqlCommand(strSQL, cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
