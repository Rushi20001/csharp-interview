using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewConsoleTest
{
    public  class ConsoleLoggerClass : ILogger
    {
        public async Task<LogResult> LogAsync(string message)
        {
            try
            {
                await Task.Run(() => Console.WriteLine($"ConsoleLogger: {message}"));
                return new LogResult
                { 
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new LogResult
                { 
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
