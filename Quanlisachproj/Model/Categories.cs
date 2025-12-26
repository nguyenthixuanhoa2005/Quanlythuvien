using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class Categories
    {
        public long Cate_id;
        public string Cate_name;

        public Categories() {
            Cate_id = 0;
            Cate_name = string.Empty;
        }
        public Categories (string cate_name)
        {
            Cate_name = cate_name;
        }
    }
}
