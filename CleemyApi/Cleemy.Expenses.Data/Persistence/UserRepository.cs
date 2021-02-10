using Cleemy.Expenses.Business;
using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Expenses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleemy.Expenses.Data.DataAccess
{
    public class UserRepository : ContextRepository<User, ExpensesContext>
    {
        public UserRepository(ExpensesContext context) : base(context)
        {

        }

    }
}
