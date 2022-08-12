using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Annotations
{
    [MetadataType(typeof(EmployeeAnnotation))]
    public partial class Employee
    {

    }
    public class EmployeeAnnotation
    {
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
    }
}
