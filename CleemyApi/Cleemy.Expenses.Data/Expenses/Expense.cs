using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cleemy.Expenses.Data.Expenses
{
    [Table("expense")]
    public class Expense: IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ExpenseType ExpenseType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
