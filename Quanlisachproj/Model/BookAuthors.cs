using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class BookAuthors
    {
        public long Book_ID { get; set; }
        public long Author_ID { get; set; }

        public BookAuthors()
        {
            Book_ID = 0;
            Author_ID = 0;
        }

        public BookAuthors(long book_id, long author_id)
        {
            Book_ID = book_id;
            Author_ID = author_id;
        }
    }
}
