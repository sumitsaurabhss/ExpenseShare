using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseShare.Domain.Entities
{
    public class Group
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3), MaxLength(50)]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [InverseProperty("Group")]
        public ICollection<Balance> Balances { get; set; }

        [InverseProperty("Group")]
        public ICollection<Expense> Expenses { get; set; }

        //public Group()
        //{
        //    Name = String.Empty;
        //    Description = String.Empty;
        //    Balances = [];
        //    Expenses = [];
        //}
    }
}
