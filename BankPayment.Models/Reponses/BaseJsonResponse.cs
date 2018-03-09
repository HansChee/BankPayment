using System.Collections.Generic;

namespace BankPayment.Models
{
    public class BaseJsonResponse
    {
        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
    }
}
