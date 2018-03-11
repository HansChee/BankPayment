using log4net;
using log4net.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;
using System.Xml;

namespace BankPayment.WebApp
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            InitLog();

            log.Info("Application - Main is invoked");

            // run the web
            BuildWebHost(args).Run();
        }

        static void InitLog()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly()
                , typeof(log4net.Repository.Hierarchy.Hierarchy));

            XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
