using Cleemy.Expenses.Data;
using Cleemy.Expenses.Data.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cleemy.Expenses.Business
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext(DbContextOptions<ExpensesContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 2,
                        FirstName = "Stark",
                        SecondName = "Anthony",
                        Currency = "USD"
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Romanova",
                        SecondName = "Natasha",
                        Currency = "RUB"
                    }
                );
        }
    }
}
