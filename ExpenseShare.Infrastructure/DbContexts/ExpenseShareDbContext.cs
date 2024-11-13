using ExpenseShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Infrastructure.DbContexts
{
    public class ExpenseShareDbContext : DbContext
    {
        public ExpenseShareDbContext(DbContextOptions<ExpenseShareDbContext> options)
            : base(options)
        {

        }

        public DbSet<Balance> Balances { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseMember> ExpenseMembers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseShareDbContext).Assembly);
            modelBuilder.Entity<ExpenseMember>()
                .HasOne(em => em.Expense)
                .WithMany(e => e.ExpenseMembers)
                .HasForeignKey(em => em.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExpenseMember>()
                .HasOne(em => em.Member)
                .WithMany(m => m.ExpenseMembers)
                .HasForeignKey(em => em.MemberId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Balance>()
                .HasOne(b => b.Group)
                .WithMany(g => g.Balances)
                .HasForeignKey(b => b.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Balance>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Balances)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Group)
                .WithMany(g => g.Expenses)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Balance>()
               .Property(p => p.Dues)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Expense>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ExpenseMember>()
                .Property(p => p.AmountSplit)
                .HasColumnType("decimal(18,2)");


            base.OnModelCreating(modelBuilder);

        }
    }
}