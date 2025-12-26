using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class LoanItems
    {
        public long LoanItem_ID { get; set; }
        public long Loan_ID { get; set; }
        public long Book_ID { get; set; }

        //Theem cai nay de biet sach nao
        public string Title { get; set; }
        public long Quantity { get; set; }
        public DateTime Loan_Date { get; set; }
        public DateTime Due_Date { get; set; }

        public string Status { get; set; }

        public LoanItems()
        {
            LoanItem_ID = 0;
            Loan_ID = 0;
            Book_ID = 0;
            Quantity = 1;
            Status = "borrowing";
            Title = string.Empty;
            Loan_Date = DateTime.Now;
            Due_Date = DateTime.Now.AddDays(30);
        }
        public LoanItems(long loan_item_id, long loan_id, long book_id, string title, long quanity, string status, DateTime loan_date, DateTime due_date )
        {
            LoanItem_ID = loan_item_id;
            Loan_ID = loan_id;
            Book_ID = book_id;
            Title = title;
            Quantity = quanity;
            Status = status;
            Loan_Date = loan_date;
            Due_Date = due_date;
        }
    }
}
