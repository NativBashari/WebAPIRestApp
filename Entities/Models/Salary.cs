using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Salary
    {
        public Salary()
        {
            Persons = new HashSet<Person>();
        }
        [Key]
        public int SalaryId { get; set; }
        [Required]
        public int Amount { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
