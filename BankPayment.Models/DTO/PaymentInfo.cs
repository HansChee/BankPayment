using System;

namespace BankPayment.Models
{
    [Serializable]
    public class PaymentInfo
    {
        public string BSB { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Reference { get; set; }
        public double Amount { get; set; }
    }
}
