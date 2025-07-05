using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_wars.Models
{
    public class ExpenseUser
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required  string Password { get; set; }

        public virtual Reward?Reward { get; set; }

        public virtual Streak? Streak { get; set; }


        public virtual IEnumerable<Budget> Budgets { get; set; } = new List<Budget>();
        public virtual IEnumerable<Expenses> Expenses { get; set; } = new List<Expenses>();







    }
}
