using Cleemy.Expenses.Business;
using Cleemy.Expenses.Data;
using Cleemy.Expenses.Data.DataAccess;
using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Technical;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cleemy.Expenses.Test.Services.ExpenseServices
{
    public abstract class AbstractExpenseTest
    {
        protected IExpenseService ExpenseService { get; }

        protected Mock<IRepository<Expense>> ExpenseRepository { get; } = new Mock<IRepository<Expense>>(MockBehavior.Strict);
        protected Mock<IRepository<User>> UserRepository { get; } = new Mock<IRepository<User>>(MockBehavior.Strict);

        protected AbstractExpenseTest()
        {
            this.ExpenseService = new ExpenseService(this.ExpenseRepository.Object, this.UserRepository.Object);
        }
    }
}
