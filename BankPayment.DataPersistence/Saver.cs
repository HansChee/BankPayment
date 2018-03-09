using BankPayment.Models;
using System;
using System.Collections.Generic;

namespace BankPayment.DataPersistence
{
    public class TextSaver : ISaver
    {
        public BpActionResult SavePaymentInfo(PaymentInfo paymentInfo)
        {
            return new BpActionResult
            {
                Success = true,
                Information = new List<string> { "Winner winner, chicken dinner." }
            };
        }
    }
}
