using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban.Model
{
    internal class Users
    {
        public long User_id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public Users()
        {
            Username = string.Empty;
            Name = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Role = "member";
            Status = "active";
        }

        //Tao constructor--truy van day du thong tin
        public Users(string username,string name, string password,string phone, string email, string role, string status)
        {
            Username = username;
            Name = name;
            Password = password;
            Phone = phone;
            Email = email;
            Role = role;
            Status = status;
        }

    }



}
