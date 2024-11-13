using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseShare.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public String Password { get; set; }

        [Required]
        public String Role { get; set; }

        [Required]
        public DateTime Created { get; set; }

        //[InverseProperty("PaidBy")]
        //public ICollection<Expense> ExpensesPaid { get; set; }

        [InverseProperty("Member")]
        public ICollection<Balance> Balances { get; set; }

        [InverseProperty("Member")]
        public ICollection<ExpenseMember> ExpenseMembers { get; set; }

        //public User()
        //{
        //    Name = String.Empty;
        //    Email = String.Empty;
        //    Password = String.Empty;
        //    Role = String.Empty;
        //    Balances = [];
        //}
    }
}
