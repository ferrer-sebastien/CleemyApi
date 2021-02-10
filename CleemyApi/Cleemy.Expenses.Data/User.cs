using Cleemy.Expenses.Data.Expenses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cleemy.Expenses.Data
{
    [Table("user")]
    public class User : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string Currency { get; set; }
    }
}
