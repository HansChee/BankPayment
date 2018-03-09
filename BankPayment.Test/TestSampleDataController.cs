using BankPayment.DataPersistence;
using BankPayment.Models;
using BankPayment.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BankPayment.Test
{
    [TestClass]
    public class TestSampleDataController
    {
        [TestMethod]
        public void TestSavePayment()
        {
            ISaver saver = new TextSaver();
            var ctrl = new WhatEverController(saver);
            PaymentInfo paymentInfo = new PaymentInfo
            {
                BSB = "this is the bsb",
                AccountName = "account name is here",
                AccountNumber = "what's the number",
                Reference = "take reference"
            };
            PaymentSaveResponse response = ctrl.SavePayment(paymentInfo);
            PaymentSaveResponse result = new PaymentSaveResponse
            {
                Success = true
            };
            Assert.AreEqual(result.Success, response.Success);
        }
    }
}
