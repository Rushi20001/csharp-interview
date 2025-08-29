using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewConsoleTest
{
    public class FileLoggerClass : ILogger
    {
        private readonly string _filePath;

        public FileLoggerClass(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<LogResult> LogAsync(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, append: true))
                {
                    await writer.WriteLineAsync(message);
                }
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
                    ErrorMessage = $"Error: {ex.Message}" 
                };
            }
        }

         
        }
    
}
