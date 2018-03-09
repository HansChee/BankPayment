using BankPayment.DataPersistence;
using BankPayment.Models;
using BankPayment.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace BankPayment.Test
{
    [TestClass]
    public class TestTextSaver
    {
        [TestMethod]
        public void TestSavePaymentInfo()
        {
            PaymentInfo paymentInfo = new PaymentInfo
            {
                BSB = "this is the bsb",
                AccountName = "account name is here",
                AccountNumber = "what's the number",
                Reference = "take reference",
                Amount = 1123.45
            };
            TextSaver saver = new TextSaver();

            BpActionResult result = saver.SavePaymentInfo(paymentInfo);
            Assert.AreEqual(true, result.Success);
        }

        [TestMethod]
        public void TestEncrypt()
        {
            string src = "Strange, you can see me.";
            string str1 = SecurityHelper.Encrypt(src, "1234");
            string str2 = SecurityHelper.Decrypt(str1, "1234");

            Assert.AreEqual(src, str2);
        }

        [TestMethod]
        public void TestDecrypt()
        {
            string fileName = "eb526702-c4e2-4194-9bfb-5867196e888b";
            string src = File.ReadAllText($"C:\\Uploaded\\{fileName}.txt");

            string str2 = SecurityHelper.Decrypt(src, fileName);
            var paymentInfo = JsonConvert.DeserializeObject<PaymentInfo>(str2);
            Assert.AreEqual(paymentInfo, null);
        }

        [TestMethod]
        public void TestConfig()
        {
            //string path = ConfigurationManager.AppSettings["filePath"];
            string path = ConfigurationHelper.GetSetting("filePath");
            Assert.AreEqual(path, "//Uploaded");
        }
    }
}
