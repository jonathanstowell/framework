using System;
using System.Web.Mvc;
using log4net;

namespace ThreeBytes.Core.Logging
{
    public class HandleErrorUsingLogger : HandleErrorAttribute
    {
        private readonly ILog logger;

        public HandleErrorUsingLogger()
        {
            logger = LogManager.GetLogger(GetType());
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (!context.ExceptionHandled)
                LogException(context.Exception);
        }

        private void LogException(Exception e)
        {
            logger.Error(e.Message, e);
        }
    }
}