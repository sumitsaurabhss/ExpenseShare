using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class GroupDetailsDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public ICollection<Guid> MemberIds { get; set; }
        public ICollection<String> MemberNames { get; set; }
        public ICollection<Guid> MemberDuesIds { get; set; }
        public ICollection<Decimal> MemberDues { get; set; }
        public ICollection<Guid> ExpenseIds { get; set; }
        public ICollection<String> ExpenseDescriptions { get; set; }
        public ICollection<Decimal> ExpenseAmounts { get; set; }
    }
}
