using Cleemy.Expenses.Data;
using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Expenses.DTO;
using Cleemy.Expenses.Data.Expenses.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cleemy.Expenses.Test.Services.ExpenseServices
{
    public class CreateExpenseEntityTest : AbstractExpenseTest
    {
        public CreateExpenseEntityTest()
        {
            this.ExpenseRepository.Setup(s => s.Add(It.IsAny<Expense>())).Returns(Task.FromResult(new Expense()));
            this.UserRepository.Setup(s => s.Get(It.IsAny<int>())).Returns(Task.FromResult(new User() { Id = 1, Currency = "RUB", FirstName = "Romanova", SecondName = "Natasha" }));
            this.ExpenseRepository.Setup(s => s.Find(It.IsAny<Expression<Func<Expense, bool>>>())).Returns(Task.FromResult(new List<Expense>() { new Expense() 
                {
                    Id = 2,
                    UserId = 1,
                    ExpenseType = ExpenseType.Hotel,
                    Amount = 20,
                    Currency = "RUB",
                    Comment = "setup",
                    Date = DateTime.Today.AddMonths(-1)
                }
            } ));
        }

        [Fact]
        public async Task CreateExpenseWithDateInFutureKO()
        {
            CreateExpenseParameter parameter = BuildCreateExpenseParameter(1, ExpenseType.Restaurant, 20, "$", "date in future", DateTime.Now.AddDays(1));

            await Assert.ThrowsAsync<ExpenseInTheFutureException>(() => this.ExpenseService.CreateExpense(parameter));
        }

        [Fact]
        public async Task CreateOutdatedExpenseKO()
        {
            CreateExpenseParameter parameter = BuildCreateExpenseParameter(1, ExpenseType.Restaurant, 20, "$", "outdated", DateTime.Today.AddMonths(-4));

            await Assert.ThrowsAsync<OutdatedExpenseException>(() => this.ExpenseService.CreateExpense(parameter));
        }

        [Fact]
        public async Task CreateNotCommentedExpenseKO()
        {
            CreateExpenseParameter parameter = BuildCreateExpenseParameter(1, ExpenseType.Restaurant, 20, "$", string.Empty, DateTime.Today.AddMonths(-2));

            await Assert.ThrowsAsync<EmptyCommentException>(() => this.ExpenseService.CreateExpense(parameter));
        }

        [Fact]
        public async Task CreateExpenseWithInvalidCurrencyKO()
        {
            CreateExpenseParameter parameter = BuildCreateExpenseParameter(1, ExpenseType.Misc, 20, "USD", "not the currency of this user", DateTime.Today.AddMonths(-1));

            await Assert.ThrowsAsync<InvalidCurrencyException>(() => this.ExpenseService.CreateExpense(parameter));
        }

        [Fact]
        public async Task CreateDuplicatedExpenseKO()
        {
            CreateExpenseParameter parameter = BuildCreateExpenseParameter(1, ExpenseType.Misc, 20, "RUB", "initial", DateTime.Today.AddMonths(-1));

            await Assert.ThrowsAsync<DuplicateExpenseException>(() => this.ExpenseService.CreateExpense(parameter));
        }

        private static CreateExpenseParameter BuildCreateExpenseParameter(int userId, ExpenseType expenseType, decimal amount, string currency,string comment, DateTime date)
        {
            return new CreateExpenseParameter()
            {
                UserId = userId,
                ExpenseType = expenseType,
                Amount = amount,
                Comment = comment,
                Currency = currency,
                Date = date
            };
        }
    }
}
