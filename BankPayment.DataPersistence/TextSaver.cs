using BankPayment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using BankPayment.Utility;

namespace BankPayment.DataPersistence
{
    public class TextSaver : ISaver
    {
        static string path = ConfigurationManager.AppSettings["filePath"];
        //static string path = @"/Uploaded";

        public BpActionResult SavePaymentInfo(PaymentInfo paymentInfo)
        {
            var result = new BpActionResult
            {
                Success = true,
                Information = new List<string> { "Winner winner, chicken dinner." }
            };
            try
            {
                string fileName = Guid.NewGuid().ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists($"{path}{fileName}.txt"))
                {
                    string text = JsonConvert.SerializeObject(paymentInfo);
                    text = SecurityHelper.Encrypt(text, fileName);
                    File.WriteAllText($"{path}/{fileName}.txt", text);
                }

                result = new BpActionResult
                {
                    Success = true,
                    Information = new List<string> { "Winner winner, chicken dinner." }
                };
            }
            catch (Exception ex)
            {
                result = new BpActionResult
                {
                    Success = false,
                    Information = new List<string> { ex.Message, ex.StackTrace }
                };
            }

            return result;
        }
    }
}
