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

namespace ThreeBytes.Email.Template.Management.Frontend.Views.EmailTemplateManagement.Mobile
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailTemplateManagement/Mobile/Create.cshtml")]
    public class Create : System.Web.Mvc.WebViewPage<ThreeBytes.Email.Template.Management.Entities.EmailTemplateManagementTemplate>
    {
        public Create()
        {
        }
        public override void Execute()
        {

WriteLiteral("<div id=\"create\" data-role=\"page\">\r\n    <div data-role=\"header\">\r\n        <h1>Cre" +
"ate</h1>\r\n    </div>\r\n    <div data-role=\"content\">\r\n        <div id=\"create-tem" +
"plate-container\">\r\n            <div data-role=\"fieldcontain\">\r\n                ");


            
            #line 9 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 10 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.TextBoxFor(model => model.Name, new { @data_bind = "value: Name" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 11 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div data-role=\"fieldcontain\">\r\n               " +
" ");


            
            #line 14 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.ApplicationName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 15 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.TextBoxFor(model => model.ApplicationName, new { @data_bind = "value: ApplicationName" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 16 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.ApplicationName));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div data-role=\"fieldcontain\">\r\n               " +
" ");


            
            #line 19 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.From));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 20 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.TextBoxFor(model => model.From, new { @data_bind = "value: From" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 21 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.From));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div data-role=\"fieldcontain\">\r\n               " +
" ");


            
            #line 24 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.Subject));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 25 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.TextBoxFor(model => model.Subject, new { @data_bind = "value: Subject" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 26 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Subject));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div data-role=\"fieldcontain\">\r\n               " +
" ");


            
            #line 29 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.Body));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 30 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.TextAreaFor(model => model.Body, new { @data_bind = "value: Body" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 31 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Body));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div data-role=\"fieldcontain\">\r\n               " +
" ");


            
            #line 34 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.IsHtml));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 35 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.CheckBoxFor(model => model.IsHtml, new { @data_bind = "value: IsHtml" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 36 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div data-role=\"fieldcontain\">\r\n               " +
" ");


            
            #line 39 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.LabelFor(model => model.Encoding));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 40 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.EnumDropDownListFor(model => model.Encoding));

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 41 "..\..\Views\EmailTemplateManagement\Mobile\Create.cshtml"
           Write(Html.ValidationMessageFor(model => model.Encoding));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <a href=\"#\" data-bind=\"click: function() { emai" +
"l_template_create.save() }\" data-role=\"button\" data-icon=\"check\" data-theme=\"b\">" +
"Submit</a>\r\n            <a href=\"#\" data-bind=\"click: function() { email_templat" +
"e_create.raiseBack() }\" data-role=\"button\" data-icon=\"arrow-l\" data-theme=\"a\">Ba" +
"ck</a>\r\n        </div>\r\n    </div>\r\n    <div data-role=\"footer\">\r\n        <h4>De" +
"signed and built by <a href=\"http://www.threebytes.co.uk\" target=\"_blank\">Three " +
"Bytes</a>.</h4>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    va" +
"r email_template_create = {};\r\n\r\n    (function (index) {\r\n\r\n        email_templa" +
"te_create = index;\r\n\r\n        index.Id = ko.observable();\r\n        index.Name = " +
"ko.observable();\r\n        index.ApplicationName = ko.observable();\r\n        inde" +
"x.From = ko.observable();\r\n        index.Subject = ko.observable();\r\n        ind" +
"ex.Body = ko.observable();\r\n        index.IsHtml = ko.observable();\r\n        ind" +
"ex.Encoding = ko.observable();\r\n\r\n        index.raiseBack = function () {\r\n     " +
"       jQuery(document).trigger(\'emailTemplateHost\');\r\n        };\r\n\r\n        ind" +
"ex.save = function (form) {\r\n            var data = jQuery(form).serialize();\r\n\r" +
"\n            jQuery.post(\"Template/Create\", data, function (dataReturned) {\r\n   " +
"             if (dataReturned.IsValid) {\r\n                    jQuery(document).t" +
"rigger(\'emailTemplateCreated\');\r\n                }\r\n            });\r\n        };\r" +
"\n\r\n        jQuery(document).bind(\'emailTemplateCreate\', function () {\r\n         " +
"   jQuery.mobile.changePage(\"#create\", \"flip\", true, false);\r\n        });\r\n\r\n   " +
"     jQuery(function () {\r\n            ko.applyBindings(index, jQuery(\'#create-t" +
"emplate-container\')[0]);\r\n        });\r\n\r\n    } (email_template_create));\r\n</scri" +
"pt>");


        }
    }
}
#pragma warning restore 1591
