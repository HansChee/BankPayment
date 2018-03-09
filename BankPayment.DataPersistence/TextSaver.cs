using BankPayment.Models;
using BankPayment.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankPayment.DataPersistence
{
    public class TextSaver : ISaver
    {
        static string path = ConfigurationHelper.GetSetting("filePath");
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
                if (!String.IsNullOrEmpty(path))
                {
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
                else
                {
                    result = new BpActionResult
                    {
                        Success = false,
                        Information = new List<string> { "Upload Folder Setting Missing" }
                    };
                }
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
