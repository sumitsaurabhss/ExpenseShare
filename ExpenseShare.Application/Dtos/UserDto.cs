using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseShare.Domain.Entities;

namespace ExpenseShare.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public ICollection<Guid> GroupIds { get; set; }
        public ICollection<String> GroupNames { get; set; }
        public ICollection<Guid> GroupDuesIds { get; set; }
        public ICollection<Decimal> GroupDues { get; set; }

        //public UserDto()
        //{
        //    Name = String.Empty;
        //    Group = String.Empty;
        //}
    }
}
