using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data.PeopleClasses
{
    public class Contact
    {
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ContactType ContactType { get; set; }
    }

    public enum ContactType
    {
        Cooperator,
        Employee,
        External
    }
}