﻿#define DEBUG_LOCAL
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.SystemConsole.Themes;

namespace CatelogService.API
{
    public class Program
    {

        //TODO: Make it configurable
#if DEBUG_LOCAL
        private const string ESK_SERVER_URL = "localhost";
#else
        private const string ESK_SERVER_URL = "elasticsearch";
#endif
        private const int SLEEP_SEC = 3;
        private const int MAX_ATTEMPT = 20;

        public static void Main(string[] args)
        {

            if (args != null && args.Length > 0 && args[0] == "CONSOLEDEBUG")
            {
                // This path is for local debugging
                //TODO: Move to configuration file
                //Console.WriteLine("In debug mode");

                Log.Logger = new LoggerConfiguration()
                    .WriteTo.ColoredConsole()
                    .CreateLogger();

                Log.Logger.Information("In debug mode");
            }
            else
            {
                if (EnsureDependentServicesAreUp() == false)
                {
                    Console.WriteLine("Some of the dependent services are not up so shutting down service");
                    return;
                }

                Console.WriteLine("All dependent services are up");


                // Enable logging for serilogger errors
                Serilog.Debugging.SelfLog.Enable(Console.Error);



                // Configure logging to serilogger and elastic
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(String.Format($"http://{ESK_SERVER_URL}:9200")))
                    {
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
                    })
                    .CreateLogger();

            }

            

            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Build().Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Expection while starting the host");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureLogging((hostingContext, config) =>
                //{
                //    config.ClearProviders();
                //})
                .UseSerilog()
                .UseStartup<Startup>();
                

        private static bool EnsureDependentServicesAreUp()
        {
            bool allDependentService = true;

            // Check for logging
            allDependentService = EnsureLoggingServiceUp();

            return allDependentService;
        }

        private static bool EnsureLoggingServiceUp()
        {
            bool isLoggingUp = false;

            String url = String.Format("http://{0}:9200", ESK_SERVER_URL);

            using (HttpClient client = new HttpClient())
            {

                var retryPolicy = Policy.Handle<Exception>(ex => ex.InnerException.GetType() == typeof(HttpRequestException))
                .WaitAndRetry(MAX_ATTEMPT, retryAttempt => TimeSpan.FromMilliseconds(SLEEP_SEC*1000), (result, timeSpan, retryCount, context) => {
                    Console.WriteLine($"Connecting to {url} Request failed with {result.Message}. Attempt {retryCount}");
                });

                retryPolicy.Execute(() =>
                {
                    

                    //client.GetAsync(url).Result;
                    using (HttpResponseMessage res = client.GetAsync(url).Result)
                    {
                        if (res.IsSuccessStatusCode == true)
                        {
                            Console.WriteLine("Was successful in connecting to log service");
                            isLoggingUp = true;
                        }
                    }
                });


            }

            return isLoggingUp;
        }

    }
}
