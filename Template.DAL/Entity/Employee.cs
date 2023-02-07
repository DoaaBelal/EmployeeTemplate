using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
