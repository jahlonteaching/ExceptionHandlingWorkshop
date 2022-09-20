using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWorkshop.Domain
{
    public class Log : ILog
    {
        private ILogger _logger = NullLoggerFactory.Instance.CreateLogger("My Logger");
        void ILog.LogException(Exception exception)
        {
            _logger.LogError(exception,"","");   
        }
    }
}
