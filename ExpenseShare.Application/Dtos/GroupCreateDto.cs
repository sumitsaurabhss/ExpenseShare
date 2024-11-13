using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class GroupCreateDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public ICollection<String> MemberEmails { get; set; }

        //public GroupDto()
        //{
        //    Name = String.Empty;
        //    Description = String.Empty;
        //    MemberIds = [];
        //}
    }
}
