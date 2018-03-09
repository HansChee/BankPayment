using BankPayment.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankPayment.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class WhatEverController : Controller
    {
        ISaver saver;

        public WhatEverController(ISaver saver)
        {
            this.saver = saver;
        }

        public string Get()
        {
            return "Here comes the message.";
        }

        [HttpPost("[action]")]
        public PaymentSaveResponse SavePayment([FromBody]PaymentInfo paymentInfo)
        {
            var result = saver.SavePaymentInfo(paymentInfo);
            PaymentSaveResponse psr = new PaymentSaveResponse
            {
                Success = result.Success,
                Errors = result.Information
            };
            return psr;
        }
    }
}