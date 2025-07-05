using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_wars.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
        public double amount { get; set; }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }
        [ForeignKey("ExpenseUser")]
        public int UserId { get; set; }

    }
}
