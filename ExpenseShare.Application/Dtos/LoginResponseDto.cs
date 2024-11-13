using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Token { get; set; }
        public Boolean IsAdmin { get; set; }
        public Int16 Expiry { get; set; }

        //public LoginResponseDto() 
        //{ 
        //    Name = String.Empty;
        //    Token = String.Empty;
        //    IsAdmin = false;
        //}
    }
}
