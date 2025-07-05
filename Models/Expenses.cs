using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Budget_wars.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public String category { get; set; }
        public double amount { get; set; }

        public DateTime date { get; set; }

        [ForeignKey("ExpenseUser")]
        public int UserId { get; set; }


    }
}
