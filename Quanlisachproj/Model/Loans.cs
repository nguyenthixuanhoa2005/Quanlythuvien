using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class Loans
    {
        public long Loan_ID { get; set; }
        public long User_ID { get; set; }
        public DateTime Loan_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public string Status { get; set; }
        public Loans()
        {
            User_ID = 0;
            Loan_Date = DateTime.Now;
            Due_Date = DateTime.Now.AddDays(30); // ngày đến hạn là ngày mượn + 30 ngày 
            Return_Date = DateTime.Now;
            Status = "borrowing";

        }
        public Loans(long user_id, DateTime loan_date, DateTime due_date, string status, DateTime return_date)
        {
            User_ID = user_id;
            Loan_Date = loan_date;
            Due_Date = due_date;
            Status = status;
            Return_Date = return_date;
        }
    }
}
