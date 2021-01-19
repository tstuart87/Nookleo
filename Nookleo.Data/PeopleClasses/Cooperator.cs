using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Data.PeopleClasses
{
    public class Cooperator : Contact
    {
        [Key]
        public int CooperatorId { get; set; }
        public string StreetAddressOne { get; set; }
        public string StreetAddressTwo { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
    }
}
