using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsWebAPI.Models
{
    public partial class Contact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
    }
}