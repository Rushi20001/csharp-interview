using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewConsoleTest
{
    public class CompositeLoggerClass : ILogger
    {
        private readonly List<ILogger> _loggers;

        public CompositeLoggerClass( List<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public async Task<LogResult> LogAsync(string message)
        {
            var results = await Task.WhenAll(_loggers.Select(logger => logger.LogAsync(message)));

            bool isSuccess = results.All(r => r.Success);
            string combinedErrors = string.Join(";  ", results.Where(r => !r.Success).Select(r => r.ErrorMessage));

            return new LogResult
            {
                Success = isSuccess,
                ErrorMessage = isSuccess ? null : combinedErrors
            };
        }
    }
}
