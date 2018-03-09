using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankPayment.Utility
{
    public class ConfigurationHelper
    {
        static IConfiguration Configuration { get; set; }

        // when use configurationHelper in test project,
        // make sure "appsettings.json" is in "[TestProject]\bin\Debug\netcoreapp2.0" folder
        static ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public static string GetSetting(string key)
        {
            return Configuration?[key];
        }
    }
}
