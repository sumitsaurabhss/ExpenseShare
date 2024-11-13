using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Domain.Entities
{
    public class ExpenseMember
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Decimal AmountSplit { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("Expense")]
        public Guid ExpenseId { get; set; }
        [InverseProperty("ExpenseMembers")]
        public Expense Expense { get; set; }

        [ForeignKey("Member")]
        public Guid MemberId { get; set; }
        [InverseProperty("ExpenseMembers")]
        public User Member { get; set; }
    }
}
