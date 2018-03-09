using BankPayment.DataPersistence;
using BankPayment.Models;
using BankPayment.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BankPayment.Test
{
    [TestClass]
    public class TestWhatEverController
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
            paymentInfo = new PaymentInfo
            {
                BSB = "123-456",
                AccountName = "account name is here",
                AccountNumber = "1234567",
                Amount = 1238
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
