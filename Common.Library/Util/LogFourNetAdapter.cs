using Common.Library.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Library.Util
{
    public class LogFourNetAdapter : ILogger
    {
        private readonly ILog log;

        public LogFourNetAdapter()
        {
            this.log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(object message)
        {
            this.log.Debug(message);
        }

        public void Error(object message)
        {
            this.log.Error(message);
        }
    }
}
