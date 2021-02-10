using Cleemy.Expenses.Business;
using Cleemy.Expenses.Data.Expenses;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cleemy.Expenses.Data.DataAccess
{
    public class ExpenseRepository : ContextRepository<Expense, ExpensesContext>
    {
        public ExpenseRepository(ExpensesContext context) : base(context)
        {

        }
    }
}
