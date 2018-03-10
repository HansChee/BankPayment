using System;
using System.ComponentModel.DataAnnotations;

namespace BankPayment.Models
{
    [Serializable]
    public class PaymentInfo
    {
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}$")]
        public string BSB { get; set; }
        [Required]
        [RegularExpression(@"^\d+$")]
        public string AccountNumber { get; set; }
        [Required]
        public string AccountName { get; set; }
        [StringLength(20)]
        public string Reference { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public double Amount { get; set; }
    }
}
