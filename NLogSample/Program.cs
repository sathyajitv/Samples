

#region Namespaces

using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace NLogSample
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly object SyncObj = new object();

        //------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            //These messages are written using logging configuration from the app.config file
            LogMessages(Log);

            //Logging configuration is replaced from within code
            ConfigureLoggingFromCode();
            LogMessages(Log);

            //File logging is added from within code. 
            ConfigureLoggingToFile();
            LogMessages(Log);

            //Log to multiple files with dynamic configuration
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10; ++i)
            {
                int j = i;
                Task task = Task.Factory.StartNew(() => LogToFileWithDynamicConfiguration(j));
                tasks.Add(task);
            }

            Console.WriteLine("Waiting for threads to complete");
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Threads completed. Press any key to exit.");
            Console.ReadKey();
        }

        private static void LogMessages(Logger log)
        {
            log.Info("-----------------------------------------------------");
            log.Trace("This is a trace message");
            log.Debug("This is a debug message");
            log.Info("This is an informational message");
            log.Error(new Exception(), "This is an error message");
            log.Fatal("This is a fatal message");
        }

        private static void ConfigureLoggingFromCode()
        {
            var config = new LoggingConfiguration();
            var consoleTarget = new ConsoleTarget
            {
                Name   = "console",
                Layout = "${longdate}|${level:lowercase=true}|${logger}|${message}",
            };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget, "*");
            LogManager.Configuration = config;
        }

        private static void ConfigureLoggingToFile()
        {
            LoggingConfiguration config = LogManager.Configuration;
            var fileTarget = new FileTarget()
            {
                Name         = "logfile",
                Layout       = "${longdate}|${level:lowercase=true}|${logger}|${message}",
                FileName     = "logfile.txt",
                KeepFileOpen = false,
            };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget, "*");
            LogManager.Configuration = config;
        }

        private static void LogToFileWithDynamicConfiguration(int loggerId)
        {
            Console.WriteLine(loggerId);
            
            lock (SyncObj)
            {
                LoggingConfiguration config = LogManager.Configuration;
                var fileTarget = new FileTarget()
                {
                    Name = $"logfile-{loggerId}",
                    Layout = "${longdate}|${level:uppercase=true}| ${message}",
                    FileName = $"logfile-{loggerId}.txt",
                    KeepFileOpen = false,
                };
                config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget, $"logger-{loggerId}");
                LogManager.Configuration = config;
            }

            Logger logger = LogManager.GetLogger($"logger-{loggerId}");
            Random r = new Random();

            for (int i = 0; i < 100; ++i)
            {
                logger.Warn($"Iteration through loop {i} using logger {logger.Name}");
                Thread.Sleep(r.Next(100, 500));
            }
        }

    }
}


