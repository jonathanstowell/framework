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

namespace ThreeBytes.Email.Template.View.Frontend.Views.EmailTemplateView.Mobile
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
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using ThreeBytes.Core.Extensions.Mvc;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailTemplateView/Mobile/Details.cshtml")]
    public class Details : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Details()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div id=\"details\" data-role=\"page\">\r\n    <div id=\"details-template-container\">\r\n " +
"       <div data-role=\"header\">\r\n            <h1><span data-bind=\"text:Name\"></s" +
"pan> Details</h1>\r\n        </div>\r\n        <div data-role=\"content\">\r\n          " +
"  <fieldset class=\"ui-grid-a\">\r\n                <div class=\"ui-block-a\">Name</di" +
"v>\r\n                <div class=\"ui-block-b\"><span data-bind=\"text:Name\"></span><" +
"/div>\r\n            </fieldset>\r\n            <fieldset class=\"ui-grid-a\">\r\n      " +
"          <div class=\"ui-block-a\">Application Name</div>\r\n                <div c" +
"lass=\"ui-block-b\"><span data-bind=\"text:ApplicationName\"></span></div>\r\n        " +
"    </fieldset>\r\n            <fieldset class=\"ui-grid-a\">\r\n                <div " +
"class=\"ui-block-a\">From</div>\r\n                <div class=\"ui-block-b\"><span dat" +
"a-bind=\"text:From\"></span></div>\r\n            </fieldset>\r\n            <fieldset" +
" class=\"ui-grid-a\">\r\n                <div class=\"ui-block-a\">Subject</div>\r\n    " +
"            <div class=\"ui-block-b\"><span data-bind=\"text:Subject\"></span></div>" +
"\r\n            </fieldset>\r\n            <div data-role=\"collapsible\" data-theme=\"" +
"b\">\r\n                <h3>Body</h3>\r\n                <p><span data-bind=\"text:Bod" +
"y\"></span></p>\r\n            </div>\r\n            <fieldset class=\"ui-grid-a\">\r\n  " +
"              <div class=\"ui-block-a\">IsHtml</div>\r\n                <div class=\"" +
"ui-block-b\"><span data-bind=\"text:IsHtml\"></span></div>\r\n            </fieldset>" +
"\r\n            <fieldset class=\"ui-grid-a\">\r\n                <div class=\"ui-block" +
"-a\">Encoding</div>\r\n                <div class=\"ui-block-b\"><span data-bind=\"tex" +
"t:Encoding\"></span></div>\r\n            </fieldset>\r\n            <a href=\"#\" data" +
"-bind=\"click: function() { email_template_details.raiseEdit() }\" data-role=\"butt" +
"on\" data-icon=\"check\" data-theme=\"b\">Edit</a>\r\n            <a href=\"#\" data-bind" +
"=\"click: function() { email_template_details.raiseDelete() }\" data-role=\"button\"" +
" data-icon=\"delete\" data-theme=\"b\">Delete</a>\r\n            <a href=\"#\" data-bind" +
"=\"click: function() { email_template_details.raiseBack() }\" data-role=\"button\" d" +
"ata-icon=\"arrow-l\" data-theme=\"a\">Back</a>\r\n        </div>\r\n        <div data-ro" +
"le=\"footer\">\r\n            <h4>Designed and built by <a href=\"http://www.threebyt" +
"es.co.uk\" target=\"_blank\">Three Bytes</a>.</h4>\r\n        </div>\r\n    </div>\r\n</d" +
"iv>\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    var email_template_details = {};\r\n" +
"\r\n    (function (index) {\r\n\r\n        email_template_details = index;\r\n\r\n        " +
"index.Id = ko.observable();\r\n        index.ItemId = ko.observable();\r\n        in" +
"dex.Name = ko.observable();\r\n        index.ApplicationName = ko.observable();\r\n " +
"       index.From = ko.observable();\r\n        index.Subject = ko.observable();\r\n" +
"        index.Body = ko.observable();\r\n        index.IsHtml = ko.observable();\r\n" +
"        index.Encoding = ko.observable();\r\n        index.History = ko.observable" +
"Array();\r\n\r\n        index.Back = ko.observable();\r\n\r\n        index.raiseBack = f" +
"unction () {\r\n            if (index.Back() == \'list\') {\r\n                jQuery(" +
"document).trigger(\'emailTemplateHost\');\r\n            }\r\n\r\n            if (index." +
"Back() == \'home\') {\r\n                jQuery(document).trigger(\'home\');\r\n        " +
"    }\r\n        };\r\n\r\n        index.raiseEdit = function () {\r\n            jQuery" +
"(document).trigger(\'emailTemplateEdit\', [index.ItemId()]);\r\n        };\r\n\r\n      " +
"  index.raiseDelete = function () {\r\n            jQuery(document).trigger(\'email" +
"TemplateDelete\', [index.ItemId()]);\r\n        };\r\n\r\n        jQuery(document).bind" +
"(\'emailTemplateDetails\', function (event, template, back) {\r\n\r\n            index" +
".Back(back);\r\n            \r\n            if (index.Back() != \'list\') {\r\n         " +
"       index.Back(\'home\');\r\n            }\r\n\r\n            jQuery.getJSON(\"Templat" +
"e/Details/\" + template.Id(), function (data) {\r\n\r\n                index.Id(data." +
"Id);\r\n                index.ItemId(data.ItemId);\r\n                index.Name(dat" +
"a.Name);\r\n                index.ApplicationName(data.ApplicationName);\r\n        " +
"        index.From(data.From);\r\n                index.Subject(data.Subject);\r\n  " +
"              index.Body(data.Body);\r\n                index.IsHtml(data.IsHtml);" +
"\r\n                index.Encoding(data.Encoding);\r\n                index.History(" +
"data.History);\r\n\r\n                jQuery.mobile.changePage(\"#details\", \"flip\", t" +
"rue, false);\r\n            });\r\n        });\r\n\r\n        jQuery(function () {\r\n    " +
"        ko.applyBindings(index, jQuery(\'#details-template-container\')[0]);\r\n    " +
"    });\r\n    } (email_template_details));\r\n</script>");


        }
    }
}
#pragma warning restore 1591
