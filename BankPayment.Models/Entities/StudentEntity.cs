using System;
using System.Collections.Generic;
using System.Text;

namespace BankPayment.Models.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public int Age { get; set; }
    }
}
