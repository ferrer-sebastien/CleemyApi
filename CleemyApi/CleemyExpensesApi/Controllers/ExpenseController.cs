using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cleemy.Expenses.Data;
using Cleemy.Expenses.Data.Expenses;
using Cleemy.Expenses.Data.Expenses.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cleemy.Expenses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }
        //// GET: api/<ExpenseController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ExpenseController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("byuser")]
        public async Task<ActionResult<List<Expense>>> GetExpensesByUser([FromQuery] GetExpensesByUserParameter parameter)
        {
            return await expenseService.GetExpensesByUser(parameter);
        }

        [HttpGet("orderbyamount")]
        public async Task<ActionResult<List<Expense>>> GetExpensesOrderedByAmount()
        {
            return await expenseService.GetExpensesSortedByAmount();
        }

        [HttpGet("orderbydate")]
        public async Task<ActionResult<List<Expense>>> GetExpensesOrderedByDate()
        {
            return await expenseService.GetExpensesSortedByDate();
        }

        [HttpGet("summary")]
        public async Task<ActionResult<ExpenseSummary>> GetExpenseSummary([FromQuery] int expenseId)
        {
            return await expenseService.GetExpenseSummary(expenseId);
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public async Task<ActionResult<Expense>> Post([FromBody] CreateExpenseParameter createExpenseParameter)
        {
            return await expenseService.CreateExpense(createExpenseParameter);
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
