using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingWorkshop.Domain
{
    public interface ILog
    {
        void LogException(Exception exception);
    }
}
