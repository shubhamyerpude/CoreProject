using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorePractice.Models
{
    public class Restaurent
    {
        public int Id { get; set; }
        [Display(Name="Restaurant Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        [Display(Name ="Contact Number")]
        public double ContactNumber { get; set; }
    }
}
