using System;
using System.Globalization;
using System.Web.Mvc;
using NServiceBus;
using ThreeBytes.Logging.Messages.ExternalEvents;

namespace ThreeBytes.Core.Logging
{
    public class HandleErrorWithNServiceBus : HandleErrorAttribute
    {
        private readonly IBus bus;

        public HandleErrorWithNServiceBus(IBus bus)
        {
            this.bus = bus;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            if (!context.ExceptionHandled)
                LogException(context.Exception);
        }

        private void LogException(Exception e)
        {
            bus.Send<ILogExceptionExternalCommandMessage>(x =>
            {
                x.InnerException = e.InnerException == null ? string.Empty : e.InnerException.Message.ToString(CultureInfo.InvariantCulture);
                x.Message = e.Message;
                x.Source = e.Source;
                x.StackTrace = e.StackTrace;
            });
        }
    }
}