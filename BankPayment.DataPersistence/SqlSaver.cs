using BankPayment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankPayment.DataPersistence
{
    public class SqlSaver : ISaver
    {
        public BpActionResult SavePaymentInfo(PaymentInfo paymentInfo)
        {
            BpActionResult result = new BpActionResult
            {
                Success = false,
                Information = new List<string> { "Not Implemented" }
            };
            return result;
        }
    }
}
