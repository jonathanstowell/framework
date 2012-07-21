using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class CustomValidationExtensions
    {
        // ValidationSummary

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper)
        {
            return CustomValidationSummary(htmlHelper, false /* excludePropertyErrors */ );
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            return CustomValidationSummary(htmlHelper, excludePropertyErrors, null /* message */);
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, string message)
        {
            return CustomValidationSummary(htmlHelper, false /* excludePropertyErrors */, message, (object)null /* htmlAttributes */);
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message)
        {
            return CustomValidationSummary(htmlHelper, excludePropertyErrors, message, (object)null /* htmlAttributes */);
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, string message, object htmlAttributes)
        {
            return CustomValidationSummary(htmlHelper, false /* excludePropertyErrors */, message, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message, object htmlAttributes)
        {
            return CustomValidationSummary(htmlHelper, excludePropertyErrors, message, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, string message, IDictionary<string, object> htmlAttributes)
        {
            return CustomValidationSummary(htmlHelper, false /* excludePropertyErrors */, message, htmlAttributes);
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors, string message, IDictionary<string, object> htmlAttributes)
        {
            MvcHtmlString originalValidation = ValidationExtensions.ValidationSummary(htmlHelper, excludePropertyErrors, message, htmlAttributes);

            StringBuilder divAlertMessageErrorContainer = new StringBuilder();

            TagBuilder divAlertMessageError = new TagBuilder("div");

            divAlertMessageError.AddCssClass("validation-summary-valid");
            divAlertMessageError.AddCssClass("alert-message");
            divAlertMessageError.AddCssClass("block-message");
            divAlertMessageError.AddCssClass("error");
            divAlertMessageError.MergeAttribute("data-valmsg-summary", "true");
            divAlertMessageError.MergeAttribute("data-alert", "alert");

            TagBuilder hrefClose = new TagBuilder("a");

            hrefClose.AddCssClass("close");
            hrefClose.InnerHtml = "&times;";

            TagBuilder pSummaryContainer = new TagBuilder("p");

            pSummaryContainer.InnerHtml = originalValidation.ToString();

            divAlertMessageErrorContainer.Append(hrefClose);
            divAlertMessageErrorContainer.Append(pSummaryContainer);

            divAlertMessageError.InnerHtml = divAlertMessageErrorContainer.ToString();

            return divAlertMessageError.ToMvcHtmlString(TagRenderMode.Normal);
        } 
    }
}
