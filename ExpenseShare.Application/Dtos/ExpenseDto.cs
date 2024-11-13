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
    public class ExpenseDto
    {
        public String Description { get; set; }
        public Decimal Amount { get; set; }
        public Guid GroupId { get; set; }
        public String PaidByMemberId { get; set; }
        public ICollection<Guid> SplitAmongMemberIds { get; set; }

        //public ExpenseDto()
        //{
        //    Description = String.Empty;
        //    Amount = 0;
        //    Group = new Group();
        //    SplitAmongMemberIds = [];
        //}
    }
}
