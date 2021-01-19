using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data.PeopleClasses
{
    public class Employee : Contact
    {
        [Key]
        public int EmployeeId { get; set; }
    }
}
