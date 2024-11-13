using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ExpenseShare.Domain.Entities
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public Decimal Amount { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        // [InverseProperty("Expenses")]
        public Group Group { get; set; }

        //[ForeignKey("PaidBy")]
        //[AllowNull]
        //public Guid PaidByMemberId { get; set; }
        public String? PaidBy { get; set; }

        [InverseProperty("Expense")]
        public ICollection<ExpenseMember> ExpenseMembers { get; set; }

        //public Expense()
        //{
        //    Description = String.Empty;
        //    Amount = 0;
        //    Group = new Group();
        //    PaidBy = new User();
        //    SplitAmong = [];
        //}
    }
}
