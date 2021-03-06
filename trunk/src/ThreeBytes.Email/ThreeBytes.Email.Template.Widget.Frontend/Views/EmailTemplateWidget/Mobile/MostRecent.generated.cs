﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBytes.Email.Template.Widget.Frontend.Views.EmailTemplateWidget.Mobile
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Script.Serialization;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using ThreeBytes.Core.Extensions.Mvc;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailTemplateWidget/Mobile/MostRecent.cshtml")]
    public class MostRecent : System.Web.Mvc.WebViewPage<dynamic>
    {
        public MostRecent()
        {
        }
        public override void Execute()
        {
WriteLiteral("<script type=\"text/javascript\">\r\n\r\n    var most_recent_templates_latest_list = {}" +
";\r\n\r\n    (function(index) {\r\n\r\n        most_recent_templates_latest_list = index" +
" = ko.mapping.fromJS(");


            
            #line 7 "..\..\Views\EmailTemplateWidget\Mobile\MostRecent.cshtml"
                                                                 Write(Html.Raw(string.Format("{{\"Items\" : {0}}}", new JavaScriptSerializer().Serialize(Model))));

            
            #line default
            #line hidden
WriteLiteral(");\r\n        \r\n        index.raiseDetails = function (obj) {\r\n                jQue" +
"ry(document).trigger(\'emailTemplateDetails\', [obj, \'home\']);\r\n            };\r\n  " +
"      \r\n        jQuery(function() {\r\n            ko.applyBindings(index, jQuery(" +
"\'#most_recent_templates-container\')[0]);\r\n        });\r\n        \r\n        setInte" +
"rval(function() {\r\n            jQuery.getJSON(\"EmailTemplateWidget/MostRecent\", " +
"function (data) {\r\n                ko.mapping.fromJS(data, index);          \r\n  " +
"          });\r\n        }, 1000);\r\n         \r\n    } (most_recent_templates_latest" +
"_list));\r\n    \r\n</script>\r\n\r\n<script id=\"most_recent_templates-list-grid-tmpl\" t" +
"ype=\"text/x-jquery-tmpl\">    \r\n    <li data-theme=\"c\" class=\"ui-btn ui-btn-icon-" +
"right ui-li-has-arrow ui-li ui-btn-up-c\">\r\n        <div class=\"ui-btn-inner ui-l" +
"i\" aria-hidden=\"true\">\r\n            <div class=\"ui-btn-text\">\r\n                <" +
"a href=\"#\" class=\"ui-link-inherit\" data-bind=\"click: function() { most_recent_te" +
"mplates_latest_list.raiseDetails($data) }\">\r\n                    <h3 class=\"ui-l" +
"i-heading\">${Name}</h3>\r\n                    <p class=\"ui-li-desc\">${Application" +
"Name}</p>\r\n                </a>\r\n            </div>\r\n            <span class=\"ui" +
"-icon ui-icon-arrow-r ui-icon-shadow\"></span>\r\n        </div>\r\n    </li>\r\n</scri" +
"pt>\r\n\r\n<div id=\"most_recent_templates-container\">\r\n    <h3>Most Created Template" +
"s</h3>\r\n    <ul data-role=\"listview\" data-inset=\"true\" data-bind=\"template: { na" +
"me: \'most_recent_templates-list-grid-tmpl\', foreach: Items }\" class=\"ui-listview" +
"\"></ul>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
