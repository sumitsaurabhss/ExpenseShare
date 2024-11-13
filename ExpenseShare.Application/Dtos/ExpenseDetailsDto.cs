using ExpenseShare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class ExpenseDetailsDto
    {
        public Guid Id { get; set; }
        public String Description { get; set; }
        public Decimal Amount { get; set; }
        public Guid GroupId { get; set; }
        public String GroupName { get; set; }
        // public Guid PaidByMemberId { get; set; }
        public String PaidBy { get; set; }
        public ICollection<Guid> SplitAmongMemberIds { get; set; }
        public ICollection<String> SplitAmong { get; set; }

        //public ExpenseDetailsDto()
        //{
        //    PaidBy = String.Empty;
        //    SplitAmong = [];
        //}
    }
}
