using System.Web.Mvc;
using System.Web.Routing;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class ImageExtensions
    {
        public static string ImageLink(this HtmlHelper helper, string id, string href, string title, string rel, string strImageURL, string alternateText, string strStyle)
        {
            return ImageLink(helper, id, href, title, rel, strImageURL, alternateText, strStyle, null);
        }

        public static string ImageLink(this HtmlHelper helper, string id, string href, string title, string rel, string strImageURL, string alternateText, string strStyle, object htmlAttributes)
        {
            // Create tag builder
            var builder = new TagBuilder("a");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("href", "/" + href); //form target URL
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("rel", rel);
            builder.InnerHtml = "<img src='" + strImageURL + "' alt='" + alternateText + "' style=\"" + strStyle + "\">"; //set the image as inner html
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            // Render tag
            return builder.ToString(TagRenderMode.Normal); //to add </a> as end tag
        }
    }
}
