using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_wars.Models
{
    public class Reward
    {
        [Key]
        public int Id { get; set; }
        public int Xp { get; set; }

        public int Level { get; set; }

        public DateTime LastEarnedXp { get; set; }
        public int UserId { get; set; }                     // FK column in MySQL

        [ForeignKey(nameof(UserId))]                        // link FK → nav
        public ExpenseUser ExpenseUser { get; set; }

    }
}
