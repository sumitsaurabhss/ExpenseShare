using ExpenseShare.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseShare.Infrastructure.DbContexts;
namespace ExpenseShare.Infrastructure.SeededData
{
    public class UserData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExpenseShareDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ExpenseShareDbContext>>()))
            {
                // Check if the database has been seeded
                if (context.Users.Any())
                {
                    return; // Database has been seeded
                }

                // Seed the database with sample products
                context.Users.AddRange(
                    // Admin users
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Admin1",
                        Email = "admin1@mail.com",
                        Password = "Admin@123",
                        Role = "Admin",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Admin2",
                        Email = "admin2@mail.com",
                        Password = "Admin@123",
                        Role = "Admin",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Admin3",
                        Email = "admin3@mail.com",
                        Password = "Admin@123",
                        Role = "Admin",
                        Created = DateTime.Now
                    },

                    // Regular users
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Aman",
                        Email = "aman@mail.com",
                        Password = "Aman@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rohan",
                        Email = "rohan@mail.com",
                        Password = "Rohan@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sana",
                        Email = "sana@mail.com",
                        Password = "Sana@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Priya",
                        Email = "priya@mail.com",
                        Password = "Priya@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Karan",
                        Email = "karan@mail.com",
                        Password = "Karan@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Neha",
                        Email = "neha@mail.com",
                        Password = "Neha@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Vikram",
                        Email = "vikram@mail.com",
                        Password = "Vikram@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Aarti",
                        Email = "aarti@mail.com",
                        Password = "Aarti@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Anil",
                        Email = "anil@mail.com",
                        Password = "Anil@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bhavna",
                        Email = "bhavna@mail.com",
                        Password = "Bhavna@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Deepak",
                        Email = "deepak@mail.com",
                        Password = "Deepak@123",
                        Role = "Member",
                        Created = DateTime.Now
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ekta",
                        Email = "ekta@mail.com",
                        Password = "Ekta@123",
                        Role = "Member",
                        Created = DateTime.Now
                    }
                );

                context.SaveChanges(); // Save changes to the database
            }
        }
    }
}