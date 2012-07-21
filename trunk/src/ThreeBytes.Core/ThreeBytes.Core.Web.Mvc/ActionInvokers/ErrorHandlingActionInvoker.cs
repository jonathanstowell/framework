using System;
using System.Web.Mvc;

namespace ThreeBytes.Core.Web.Mvc.ActionInvokers
{
    public class ErrorHandlingActionInvoker : ControllerActionInvoker
    {
        private readonly IExceptionFilter filter;

        public ErrorHandlingActionInvoker(IExceptionFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            this.filter = filter;
        }

        protected override FilterInfo GetFilters(
        ControllerContext controllerContext,
        ActionDescriptor actionDescriptor)
        {
            var filterInfo =
            base.GetFilters(controllerContext,
            actionDescriptor);

            filterInfo.ExceptionFilters.Add(this.filter);

            return filterInfo;
        }
    }

}
