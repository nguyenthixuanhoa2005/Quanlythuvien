using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlisachcoban.Model
{
    public class Ketnoi
    {
        private static string ConnectionString = "Data Source=localhost,1433;Initial Catalog=quanlimuonsach;User ID=hoa1;Password=123;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        //Chuan hoa tên độc giả
        public static string Chuanhoa(string input)
        {
            // neu nhu chuoi rong hoac la chi la khoang trang
            if (string.IsNullOrWhiteSpace(input)) return string.Empty; 

            //neu nhu chuoi nhap vao khi trim van con ton tai khoang trang --> chuyen so lg khoang trang ve cacha 1 khoang trang
            input = System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " "); // dau + de gom cac dau cach
            string[] words = input.Split(' ');  // 1 casi list tu dc tach = khoang trang

            for (int i = 0; i < words.Length; i++)
            {
                //neu chuoi co nhieu hon 1 tu
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + // vt hoa chu cai dau cua tu 
                               (words[i].Length > 1 ? words[i].Substring(1).ToLower() : ""); // neu nhu so ki tu cua tu > 1 thi nhung ki tu dang sua se dc viet thuong, neu khong thi tra ve chuoi giong
                }
            }

            return string.Join(" ", words);
        }

    }
}
