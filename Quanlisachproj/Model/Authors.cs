using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class Authors
    {
        public long Author_ID { get; set; }
        public string Author_Name { get; set; }

        public Authors() { 
            Author_Name = string.Empty;
        }

        public Authors(long author_name) {
            Author_ID = author_name; 
        }
    }
}
