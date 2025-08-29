using InterviewConsoleTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting application...");

        var fileLogger = new FileLoggerClass("log.txt");

        
        var consoleLogger = new ConsoleLoggerClass();

        
        
        var compositeLogger = new CompositeLoggerClass(new List<ILogger> { fileLogger, consoleLogger });

        LogResult result = await compositeLogger.LogAsync("log message.");

        if (result.Success)
        {
            Console.WriteLine("Logging succeeded.");
        }
        else
        {
            Console.WriteLine("Logging failed: " + result.ErrorMessage);
        }
        Console.WriteLine("Application finished.");
    }
}
