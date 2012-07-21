using System;
using System.Web.Mvc;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class DateExtensions
    {
        public static string Date(this HtmlHelper htmlHelper, DateTime? dateTime)
        {
            return Date(htmlHelper, dateTime, "dd/MM/yyyy HH:mm:ss");
        }

        public static string Date(this HtmlHelper htmlHelper, DateTime? dateTime, string dateFormat)
        {
            if (dateTime == null)
            {
                return "Not Set";
            }

            return ((DateTime)dateTime).ToString(dateFormat);
        }
    }
}
