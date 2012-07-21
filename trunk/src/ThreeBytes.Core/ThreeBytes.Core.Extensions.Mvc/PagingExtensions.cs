using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class PagingExtensions
    {
        public static MvcHtmlString Paging<T>(this HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller) where T : class, IBusinessObject<T>
        {
            return Paging(htmlHelper, item, action, controller, "prev", "next", "first", "last", "pages-container");
        }

        public static MvcHtmlString Paging<T>(this HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller, string previousId, string nextId, string firstId, string lastId, string pageContainerId) where T : class, IBusinessObject<T>
        {
            if (item.TotalItemCount == 0)
                return null;

            TagBuilder divContainer = new TagBuilder("div");

            divContainer.AddCssClass("pagination");

            StringBuilder pagesHtml = new StringBuilder();

            TagBuilder unorderedList = new TagBuilder("ul");
            TagBuilder previous = buildPrevious(htmlHelper, item, action, controller, previousId);
            TagBuilder first = buildFirst(htmlHelper, item, action, controller, firstId);
            TagBuilder next = buildNext(htmlHelper, item, action, controller, nextId);
            TagBuilder last = buildLast(htmlHelper, item, action, controller, lastId);

            pagesHtml.Append(previous);
            pagesHtml.Append(first);
            pagesHtml.Append(buildPages(htmlHelper, item, action, controller, pageContainerId));
            pagesHtml.Append(last);
            pagesHtml.Append(next);

            unorderedList.InnerHtml = pagesHtml.ToString();
            divContainer.InnerHtml = unorderedList.ToString();

            return divContainer.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private static TagBuilder buildFirst<T>(HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller, string id) where T : class, IBusinessObject<T>
        {
            TagBuilder first;

            RouteValueDictionary containerHtmlAttributes = new RouteValueDictionary { { "data-bind", "css: { disabled: PageNumber() === 1 }" } };

            if (item.IsFirstPage)
            {
                first = buildListElement(htmlHelper, "First", action, controller, item.PageNumber, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function() { PageNumber(1); }", "disabled");
            }
            else
            {
                first = buildListElement(htmlHelper, "First", action, controller, 1, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function() { PageNumber(1); }");
            }

            return first;
        }

        private static TagBuilder buildPrevious<T>(HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller, string id) where T : class, IBusinessObject<T>
        {
            TagBuilder previous;

            RouteValueDictionary containerHtmlAttributes = new RouteValueDictionary { { "data-bind", "css: { disabled: PageNumber() === 1 }" } };

            if (item.IsFirstPage)
            {
                previous = buildListElement(htmlHelper, "← Previous", action, controller, item.PageNumber, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function (event) { navigate(event) }", "disabled");
            }
            else
            {
                previous = buildListElement(htmlHelper, "← Previous", action, controller, item.PageNumber - 1, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function (event) { navigate(event) }");
            }

            return previous;
        }

        private static string buildPages<T>(HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller, string id) where T : class, IBusinessObject<T>
        {
            TagBuilder pageContainer = new TagBuilder("span");

            RouteValueDictionary pageContainerHtmlAttributes = new RouteValueDictionary { { "data-bind", "template: 'paging-page-tmpl'" } };

            pageContainer.GenerateId(id);
            pageContainer.MergeAttributes(pageContainerHtmlAttributes);

            StringBuilder result = new StringBuilder();

            int firstPagingPage = 1;
            int lastPagingPage = item.PageCount;

            if (item.PageNumber > 5)
            {
                if (item.PageNumber > item.PageCount)
                {
                    firstPagingPage = item.PageNumber - 4;
                    lastPagingPage = item.PageNumber + 5;
                }
            }

            for (int i = firstPagingPage; i <= lastPagingPage; i++)
            {
                TagBuilder page;

                RouteValueDictionary containerHtmlAttributes = new RouteValueDictionary { { "data-bind", string.Format("css: {{ active: PageNumber() === {0} }}", i) } };

                page = buildListElement(htmlHelper, i.ToString(), action, controller, i, item.OriginalRequestDateTime, containerHtmlAttributes, null);

                if (i == item.PageNumber)
                    page.AddCssClass("active");

                result.Append(page);
            }

            pageContainer.InnerHtml = result.ToString();

            return pageContainer.ToString();
        }

        private static TagBuilder buildNext<T>(HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller, string id) where T : class, IBusinessObject<T>
        {
            TagBuilder next;

            RouteValueDictionary containerHtmlAttributes = new RouteValueDictionary { { "data-bind", "css: { disabled: PageNumber() === PageCount() }" } };

            if (item.IsLastPage || (item.IsLastPage && item.IsFirstPage))
            {
                next = buildListElement(htmlHelper, "Next →", action, controller, item.PageCount, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function (event) { navigate(event) }", "disabled");
            }
            else
            {
                next = buildListElement(htmlHelper, "Next →", action, controller, item.PageNumber + 1, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function (event) { navigate(event) }");
            }

            return next;
        }

        private static TagBuilder buildLast<T>(HtmlHelper htmlHelper, IPagedResult<T> item, string action, string controller, string id) where T : class, IBusinessObject<T>
        {
            TagBuilder last;

            RouteValueDictionary containerHtmlAttributes = new RouteValueDictionary { { "data-bind", "css: { disabled: PageNumber() === PageCount() }" } };

            if (item.IsLastPage || (item.IsLastPage && item.IsFirstPage))
            {
                last = buildListElement(htmlHelper, "Last", action, controller, item.PageCount, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function() { PageNumber(PageCount()); }", "disabled");
            }
            else
            {
                last = buildListElement(htmlHelper, "Last", action, controller, item.PageCount, item.OriginalRequestDateTime, id, containerHtmlAttributes, "click: function() { PageNumber(PageCount()); }");
            }

            return last;
        }

        private static TagBuilder buildListElement(HtmlHelper htmlHelper, string linkText, string action, string controller, int pageNumber, DateTime originalRequestDateTime, RouteValueDictionary containerHtmlAttributes, string linkDataBind, params string[] cssClasses)
        {
            return buildListElement(htmlHelper, linkText, action, controller, pageNumber, originalRequestDateTime, string.Empty, containerHtmlAttributes, linkDataBind, cssClasses);
        }

        private static TagBuilder buildListElement(HtmlHelper htmlHelper, string linkText, string action, string controller, int pageNumber, DateTime originalRequestDateTime, string id, RouteValueDictionary containerHtmlAttributes, string linkDataBind, params string[] cssClasses)
        {
            TagBuilder item = new TagBuilder("li");

            if (!string.IsNullOrEmpty(id))
                item.GenerateId(id + "-container");

            if (containerHtmlAttributes != null)
                item.MergeAttributes(containerHtmlAttributes);

            foreach (var cssClass in cssClasses)
            {
                item.AddCssClass(cssClass);
            }

            item.InnerHtml = htmlHelper.ActionLink(linkText, action, controller, new { page = pageNumber, datetime = originalRequestDateTime }, new { id = id, data_bind = linkDataBind}).ToString();

            return item;
        }
    }
}
