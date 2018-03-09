using System;
using System.Collections.Generic;
using System.Text;

namespace BankPayment.Models
{
    public class BpActionResult
    {
        public bool Success { get; set; }
        public IList<string> Information { get; set; }
    }
}
