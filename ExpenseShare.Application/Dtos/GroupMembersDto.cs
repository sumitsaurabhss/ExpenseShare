using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class GroupMembersDto
    {
        public Guid GroupId { get; set; }
        public ICollection<Guid> MemberIds { get; set; }
        public ICollection<String> MemberNames { get; set; }
    }
}
