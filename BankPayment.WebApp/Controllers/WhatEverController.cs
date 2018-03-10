using BankPayment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

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
        [ValidateAntiForgeryToken]
        public PaymentSaveResponse SavePayment([FromForm]PaymentInfo paymentInfo)
        {
            PaymentSaveResponse psr = null;
            if (ModelState.IsValid)
            {
                var result = saver.SavePaymentInfo(paymentInfo);

                psr = new PaymentSaveResponse
                {
                    Success = result.Success,
                    Errors = result.Information
                };
            }
            else
            {
                psr = new PaymentSaveResponse
                {
                    Success = false,
                    Errors = new List<string> { "Invalid Fields" }
                };
            }

            return psr;
        }
    }
}