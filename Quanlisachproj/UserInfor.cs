using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlisachcoban
{
    public class UserInfor
    {
        public long User_Id { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        public UserInfor() { }

        public UserInfor(UserInfor u)
        {
            User_Id = u.User_Id;
            Username = u.Username;
            Name = u.Name;
            Role = u.Role;
            Email = u.Email;
            Phone = u.Phone;
            password = u.password;
        }
    }
}
