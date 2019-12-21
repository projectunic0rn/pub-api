using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Mailer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureLogging(logging =>
            {
                // The default project template calls CreateDefaultBuilder, 
                // which adds the following logging providers: Console, Debug 
                // EventSource
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
                // TODO Configure external logging provider.
            })
            .UseStartup<Startup>();
    }
}
