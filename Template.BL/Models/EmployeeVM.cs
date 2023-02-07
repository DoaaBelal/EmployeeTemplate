using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL.Entity;

namespace Template.BL.Models
{
    public class EmployeeVM
    {

        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
            IsDeleted = false;
            IsActive = true;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [MinLength(3,ErrorMessage = "Min Len 3")]
        [MaxLength(50,ErrorMessage = "Max Len 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary Required")]
        [Range(5000,20000,ErrorMessage = "Salary btw 5K : 20K")]
        public double Salary { get; set; }

        [EmailAddress(ErrorMessage ="Mail InValid")]
        public string Email { get; set; }

        //[DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }

        // 12-StreetName-CityName-CountryName
        [RegularExpression("[0-9]{1,10}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}", ErrorMessage = "Address Must Like : 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
