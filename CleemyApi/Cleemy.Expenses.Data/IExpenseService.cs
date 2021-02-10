using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Expenses.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cleemy.Expenses.Data
{
    public interface IExpenseService
    {
        public Task<List<Expense>> GetExpensesByUser(GetExpensesByUserParameter expensesByUserParameter);

        public Task<List<Expense>> GetExpensesSortedByAmount();
        public Task<List<Expense>> GetExpensesSortedByDate();

        public Task<Expense> CreateExpense(CreateExpenseParameter createExpenseParameter);
        public Task<ExpenseSummary> GetExpenseSummary(int expenseId);
    }
}
