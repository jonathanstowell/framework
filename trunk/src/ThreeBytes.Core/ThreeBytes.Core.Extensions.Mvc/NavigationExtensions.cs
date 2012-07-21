using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class NavigationExtensions
    {
        public static IHtmlString RenderNavigation(this HtmlHelper htmlHelper, Navigation navigation)
        {
            return htmlHelper.Raw(AddNavigation(htmlHelper, navigation.NavigationNodes));
        }

        public static string AddNavigation(HtmlHelper htmlHelper, IList<NavigationNode> nodes)
        {
            StringBuilder navOutput = new StringBuilder();
            navOutput.Append("<ul class=\"nav\">");
            foreach (var navigationNode in nodes)
            {
                navOutput.Append(AddNavigationNode(htmlHelper, navigationNode));
            }
            navOutput.Append("</ul>");

            return navOutput.ToString();
        }

        private static string AddSubMenu(HtmlHelper htmlHelper, IList<NavigationNode> nodes)
        {
            StringBuilder subOutput = new StringBuilder();
            subOutput.Append("<ul class=\"dropdown-menu\">");
            foreach (var navigationNode in nodes)
            {
                subOutput.Append(AddNavigationNode(htmlHelper, navigationNode));
            }
            subOutput.Append("</ul>");

            return subOutput.ToString();
        }

        public static string AddNavigationNode(HtmlHelper htmlHelper, NavigationNode node)
        {
            StringBuilder nodeOutput = new StringBuilder();

            if (node.Children.Count == 0)
            {
                nodeOutput.Append("<li>");
            }
            else
            {
                nodeOutput.Append("<li class=\"dropdown\">");
            }

            if (node.Children.Count == 0)
            {
                nodeOutput.Append(htmlHelper.ActionLink(node.Name, node.Action, node.Controller).ToString());
            }
            else
            {
                nodeOutput.Append(string.Format(@"<a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">{0}<b class=""caret""></b></a>", node.Name));
                nodeOutput.Append(AddSubMenu(htmlHelper, node.Children));
            }

            nodeOutput.Append("</li>");

            return nodeOutput.ToString();
        }

        public static IHtmlString RenderMobileNavigation(this HtmlHelper htmlHelper, Navigation navigation, string dataTheme, string dataContentTheme)
        {
            return htmlHelper.Raw(AddMobileNavigation(htmlHelper, navigation.NavigationNodes, dataTheme, dataContentTheme));
        }

        public static string AddMobileNavigation(HtmlHelper htmlHelper, IList<NavigationNode> nodes, string dataTheme, string dataContentTheme)
        {
            StringBuilder navOutput = new StringBuilder();

            foreach (var navigationNode in nodes)
            {
                navOutput.Append(AddMobileNavigationNode(htmlHelper, navigationNode, dataTheme, dataContentTheme));
            }

            return navOutput.ToString();
        }

        public static string AddMobileNavigationNode(HtmlHelper htmlHelper, NavigationNode node, string dataTheme, string dataContentTheme)
        {
            StringBuilder nodeOutput = new StringBuilder();

            if (node.Children.Count > 0)
            {
                nodeOutput.Append(string.Format("<div data-role=\"collapsible\" data-theme=\"{0}\" data-content-theme=\"{1}\">", dataTheme, dataContentTheme));
            }

            if (node.Children.Count == 0)
            {
                nodeOutput.Append(htmlHelper.ActionLink(node.Name, node.Action, node.Controller, null, new { data_role="button", rel="external" }).ToString());
            }
            else
            {
                nodeOutput.Append(AddMobileSubMenu(htmlHelper, node.Children));
            }

            if (node.Children.Count > 0)
            {
                nodeOutput.Append("</div>");
            }

            return nodeOutput.ToString();
        }

        private static string AddMobileSubMenu(HtmlHelper htmlHelper, IList<NavigationNode> nodes)
        {
            StringBuilder subOutput = new StringBuilder();

            foreach (var navigationNode in nodes)
            {
                subOutput.Append(AddNavigationNode(htmlHelper, navigationNode));
            }

            return subOutput.ToString();
        }
    }
}

