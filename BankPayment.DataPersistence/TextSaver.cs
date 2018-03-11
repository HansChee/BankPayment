using BankPayment.Models;
using BankPayment.Utility;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankPayment.DataPersistence
{
    public class TextSaver : ISaver
    {
        static readonly string path = ConfigurationHelper.GetSetting("filePath");
        
        static readonly ILog log = LogManager.GetLogger(typeof(TextSaver));

        public BpActionResult SavePaymentInfo(PaymentInfo paymentInfo)
        {
            BpActionResult result = null;
            try
            {
                string fileName = Guid.NewGuid().ToString();
                log.Info($"fileName: {fileName}");

                if (!String.IsNullOrEmpty(path))
                {
                    log.Info($"filePath: {path}");
                    if (!Directory.Exists(path))
                    {
                        log.Info("File path not exist, try to create");
                        Directory.CreateDirectory(path);
                    }
                    if (!File.Exists($"{path}{fileName}.txt"))
                    {
                        log.Info("File not exist, try to create");
                        
                        string text = JsonConvert.SerializeObject(paymentInfo);
                        log.Info($"Payment info serialized, detail: {text}");

                        text = SecurityHelper.Encrypt(text, fileName);
                        log.Info($"Encrypted text content: {text}");

                        File.WriteAllText($"{path}/{fileName}.txt", text);
                        log.Info($"File saved, path: {path}/{fileName}.txt");
                    }

                    result = new BpActionResult
                    {
                        Success = true,
                        Information = new List<string> { "Winner winner, chicken dinner." }
                    };
                }
                else
                {
                    log.Error($"File path not exist: {path}");
                    result = new BpActionResult
                    {
                        Success = false,
                        Information = new List<string> { "Upload Folder Setting Missing" }
                    };
                }
            }
            catch (Exception ex)
            {
                log.Error($"Exception: {ex.Message}; StackTrace: {ex.StackTrace}");
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
