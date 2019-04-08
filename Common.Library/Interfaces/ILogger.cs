using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Library.Interfaces
{
    public interface ILogger
    {
        void Debug(object message);
        void Error(object message);
    }
}
