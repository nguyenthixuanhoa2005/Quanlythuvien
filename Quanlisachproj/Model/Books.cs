using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class Books
    {
        public long book_id { get; set; }
        public String title { get; set; }
        public int year { get; set; }
        public String publishing_House { get; set; }
        public long total { get; set; }
        public long available { get; set; }
        public String category{ get; set; }
        public String authors { get; set; }
        public Books()
        {
            title = string.Empty;
            year = 1800;
            publishing_House = string.Empty;
            total = 0;
            available = 0;
            category = string.Empty;
            authors = string.Empty;

        }

        //k quann tam tên tham số trong constructor, chỉ quan tâm tới tên property khi map với cột DB
        public Books (String Title, int Year, String Publishing_house, long Total, long Available,String Category, String Author)
        {
            title = Title;
            year = Year;
            publishing_House = Publishing_house;
            total = Total;
            available = Available;
            category = Category;
            authors = Author;
        }
    }
}
