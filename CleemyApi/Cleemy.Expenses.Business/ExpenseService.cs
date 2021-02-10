using Cleemy.Expenses.Data;
using Cleemy.Expenses.Data.DataAccess;
using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Expenses.DTO;
using Cleemy.Expenses.Data.Expenses.Exceptions;
using Cleemy.Expenses.Data.Technical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleemy.Expenses.Business
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> expenseRepository;
        private readonly IRepository<User> userRepository;

        public ExpenseService(IRepository<Expense> expenseRepository, IRepository<User> userRepository)
        {
            this.expenseRepository = expenseRepository;
            this.userRepository = userRepository;
        }

        public async Task<List<Expense>> GetExpensesByUser(GetExpensesByUserParameter expensesByUserParameter)
        {
            return await expenseRepository.Find(e => e.User.Id.Equals(expensesByUserParameter.UserId));
        }

        public async Task<List<Expense>> GetExpensesSortedByAmount()
        {
            return await expenseRepository.GetAllOrderedBy("e => e.Amount.ToString()");
        }

        public async Task<List<Expense>> GetExpensesSortedByDate()
        {
            return await expenseRepository.GetAllOrderedBy("e => e.Date.ToString()");
        }

        public async Task<ExpenseSummary> GetExpenseSummary(int expenseId)
        {
            Expense retrievedExpense = await expenseRepository.Get(expenseId);
            ExpenseSummary summary = new ExpenseSummary()
            {
                Id = retrievedExpense.Id,
                User = string.Format("{0} {1}", retrievedExpense.User.FirstName, retrievedExpense.User.SecondName),
                Date = retrievedExpense.Date,
                ExpenseType = retrievedExpense.ExpenseType,
                Amount = retrievedExpense.Amount,
                Currency = retrievedExpense.Currency,
                Comment = retrievedExpense.Comment
            };
            return summary;
        }

        public async Task<Expense> CreateExpense(CreateExpenseParameter createExpenseParameter)
        {
            User user = await this.userRepository.Get(createExpenseParameter.UserId);
            string userCurrency = user.Currency;
            string expenseCurrency = createExpenseParameter.Currency;
            DateTime expenseDate = createExpenseParameter.Date;

            if(expenseDate > DateTime.Now)
            {
                throw new ExpenseInTheFutureException();
            }

            DateTime threeMonthsAgo = DateTime.Today.AddMonths(-3);

            if (expenseDate < threeMonthsAgo)
            {
                throw new OutdatedExpenseException((int)Math.Round((DateTime.Now - expenseDate).TotalDays));
            }

            if(string.IsNullOrEmpty(createExpenseParameter.Comment))
            {
                throw new EmptyCommentException();
            }

            IEnumerable<Expense> expensesForThisUser = await expenseRepository.Find(e => e.User.Id.Equals(createExpenseParameter.UserId));

            if (expensesForThisUser.Any(e => (e.Amount == createExpenseParameter.Amount) && (e.Date == expenseDate) ))
            {
                throw new DuplicateExpenseException();
            }

            if (userCurrency != expenseCurrency)
            {
                throw new InvalidCurrencyException(expenseCurrency, userCurrency);
            }

            Expense createdExpense = await this.expenseRepository.Add(
                new Expense 
                { 
                  User = user,
                  Amount = createExpenseParameter.Amount,
                  Currency = expenseCurrency,
                  Comment = createExpenseParameter.Comment,
                  Date = expenseDate,
                  ExpenseType = createExpenseParameter.ExpenseType
                }
            );

            return createdExpense;
        }
    }
}
