using System;

namespace BankPayment.Models
{
    public class PaymentInfo
    {
        public string BSB { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Reference { get; set; }
        public string Amount { get; set; }
    }
}
