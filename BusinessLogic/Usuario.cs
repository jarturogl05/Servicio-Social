using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Usuario
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String UserType { get; set; }
        public DateTime RegisterDate { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }

        public Usuario(string UserName, string Password, string UserType, DateTime RegisterDate, string Name, string Email)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.UserType = UserType;
            this.RegisterDate = RegisterDate;
            this.Name = Name;
            this.Email = Email;
        }

        public Usuario()
        {

        }
    }
}
