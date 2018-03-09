using System;
using System.Collections.Generic;
using System.Text;

namespace BankPayment.Models
{
    public interface ISaver
    {
       BpActionResult SavePaymentInfo(PaymentInfo paymentInfo);
    }
}
