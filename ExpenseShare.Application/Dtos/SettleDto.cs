using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Dtos
{
    public class SettleDto
    {
        public Guid Id { get; set; }
        public Guid PaidByMemberId { get; set; }
    }
}
