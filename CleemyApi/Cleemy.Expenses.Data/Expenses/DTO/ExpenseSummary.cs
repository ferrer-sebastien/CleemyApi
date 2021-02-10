using System;
using System.Collections.Generic;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses.DTO
{
    public class ExpenseSummary
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
    }
}
