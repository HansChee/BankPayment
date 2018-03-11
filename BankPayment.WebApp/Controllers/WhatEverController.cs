using BankPayment.Models;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankPayment.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class WhatEverController : Controller
    {
        static ISaver Saver;
        static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public WhatEverController(ISaver saver)
        {
            log.Info("Enter WhatEvet constructor");
            Saver = saver;
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public PaymentSaveResponse SavePayment([FromForm]PaymentInfo paymentInfo)
        {
            log.Info("Enter SavePayment");
            PaymentSaveResponse psr = null;
            if (ModelState.IsValid)
            {
                log.Info("ModelState is valid, begin to save");
                var result = Saver.SavePaymentInfo(paymentInfo);

                psr = new PaymentSaveResponse
                {
                    Success = result.Success,
                    Errors = result.Information
                };
            }
            else
            {
                log.Info("Model is NOT valid, return message.");
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