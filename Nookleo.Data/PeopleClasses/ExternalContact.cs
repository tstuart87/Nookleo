using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data.PeopleClasses
{
    public class ExternalContact : Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Company { get; set; }
    }
}
