using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Position
    {
        public Position()
        {
            Persons = new HashSet<Person>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<Person>? Persons { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
