using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public String Password { get; set; }

        //public LoginRequestDto()
        //{
        //    Email = String.Empty;
        //    Password = String.Empty;
        //}
    }
}
