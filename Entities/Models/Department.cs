using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Department
    {
        public Department()
        {
            Positions = new HashSet<Position>();
        }
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
