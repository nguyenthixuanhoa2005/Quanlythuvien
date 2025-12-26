using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Quanlisachcoban
{
    internal class Database
    {
        SqlConnection conn; // Doi tuong ket noi CSDL
        SqlDataAdapter da; // Doi tuong thuc thi truy van va lay du lieu
        SqlCommand cmd; // Doi tuong thuc thi cac cau lenh SQL
        DataSet ds;  // Doi tuong chua du lieu khi giao tiep

        public Database()
        {
            string connectionString =
             "Data Source=localhost,1433;Initial Catalog=quanlimuonsach;User ID=hoa;Password=123;TrustServerCertificate=True;";
            conn = new SqlConnection(connectionString);
        }

        //Phuong thuc thuc hien cau lenh stringsql truy van du lieu (select)
        public DataTable Excute(string sqlString)
        {
            da = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        //Phuong thuc de thuc hien cac lenh them, sua, xoa
        public void ExcuteNonQuerry(string sqlString)
        {
            cmd = new SqlCommand(sqlString, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
