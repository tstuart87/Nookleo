using Nookleo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nookleo.Models.ModelsContact
{
    public class CooperatorDetail
    {
        public int CooperatorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetAddressOne { get; set; }
        public string StreetAddressTwo { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string ZipCode { get; set; }
    }
}
