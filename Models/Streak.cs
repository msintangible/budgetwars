using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_wars.Models
{
    public class Streak
    {
        [Key]
        public int Id { get; set; }

        public int CurrentStreak { get; set; }

        public DateTime LastChecked { get; set; }
        public int UserId { get; set; }                     // FK column in MySQL

        [ForeignKey(nameof(UserId))]                        // link FK → nav
        public ExpenseUser ExpenseUser { get; set; }



    }
}
