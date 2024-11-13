using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseShare.Domain.Entities
{
    public class Balance
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Decimal Dues { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        [InverseProperty("Balances")]
        public Group Group { get; set; }

        [ForeignKey("Member")]
        public Guid MemberId { get; set; }
        [InverseProperty("Balances")]
        public User Member { get; set; }

        //public Balance()
        //{
        //    Debt = 0;
        //    Group = new Group();
        //    Member = new User();
        //}
    }
}
