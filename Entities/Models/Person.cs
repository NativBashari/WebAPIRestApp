using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surename { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Adress { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position? Position { get; set; }
        [ForeignKey("Salary")]
        public int SalaryId { get; set; }
        public virtual Salary? Salary { get; set; }
    }
}
