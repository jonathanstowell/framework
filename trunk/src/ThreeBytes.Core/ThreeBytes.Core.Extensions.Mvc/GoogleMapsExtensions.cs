using System.Text;
using System.Web.Mvc;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class GoogleMapsExtensions
    {
        public static MvcHtmlString GoogleStaticMap(this HtmlHelper htmlHelper,
                             string title,
                             double latitude,
                             double longitude,
                             int width, 
                             int height,
                             int zoom = 15,
                             string language = "en")
        {
            string googleApiUrl = "http://maps.googleapis.com/maps/api/staticmap?sensor=false";

            StringBuilder url = new StringBuilder();

            url.Insert(0, googleApiUrl);

            url.Append("&language=");
            url.Append(language);

            url.Append("&zoom=");
            url.Append(zoom.ToString());

            url.Append("&size=");
            url.Append(width.ToString());
            url.Append("x");
            url.Append(height.ToString());

            url.Append("&markers=");
            url.Append(latitude.ToString());
            url.Append(",");
            url.Append(longitude.ToString());

            var imgTag = new TagBuilder("img");

            imgTag.MergeAttribute("src", url.ToString());
            imgTag.MergeAttribute("style", "border:1px solid black;");
            imgTag.MergeAttribute("alt", title);

            return MvcHtmlString.Create(imgTag.ToString(TagRenderMode.SelfClosing));
        }
    }
}
