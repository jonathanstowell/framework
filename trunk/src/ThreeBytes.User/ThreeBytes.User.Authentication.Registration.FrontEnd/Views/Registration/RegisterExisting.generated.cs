﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBytes.User.Authentication.Registration.FrontEnd.Views.Registration
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
    using ThreeBytes.User.Authentication.Registration.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Registration/RegisterExisting.cshtml")]
    public class RegisterExisting : System.Web.Mvc.WebViewPage<ThreeBytes.User.Authentication.Registration.FrontEnd.Models.RegisterExistingViewModel>
    {
        public RegisterExisting()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\Registration\RegisterExisting.cshtml"
  
    ViewBag.Title = Resources.BrowserTitleRegister;


            
            #line default
            #line hidden
WriteLiteral("\r\n<section id=\"link-registation\">\r\n    <div id=\"link-registation-container\">\r\n   " +
"     <div class=\"hero-unit\"> \r\n            <h1>");


            
            #line 10 "..\..\Views\Registration\RegisterExisting.cshtml"
           Write(Resources.Register);

            
            #line default
            #line hidden
WriteLiteral("</h1> \r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"span6\"" +
">&nbsp;</div>\r\n            <div class=\"span5 well\"> \r\n");


            
            #line 15 "..\..\Views\Registration\RegisterExisting.cshtml"
                 if (Model.Success)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <h2>");


            
            #line 17 "..\..\Views\Registration\RegisterExisting.cshtml"
                   Write(Resources.RegistrationSuccess);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n");
  
            #line 18 "..\..\Views\Registration\RegisterExisting.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral(@"                    <p>
                        We already have a user for the email address you have provided who registered using either Facebook or Foursquare.
                        Please continue if you wish create an account and link it to the existing user.
                    </p>
");


            
            #line 25 "..\..\Views\Registration\RegisterExisting.cshtml"
                    

            
            #line default
            #line hidden
WriteLiteral(@"                    <table id=""paged-users-table"" class=""table table-striped table-bordered table-condensed"">
                        <thead>
                            <tr>
                                <th class=""header yellow"">
                                    Username
                                </th>
                                <th class=""header green"">
                                    Email
                                </th>
                                <th class=""header red"">
                                    Provider
                                </th>
                            </tr>
                        </thead>
                        <tbody id=""paged-users-tbody"">
");


            
            #line 41 "..\..\Views\Registration\RegisterExisting.cshtml"
                             foreach (var externalAuthentication in Model.ExternalUser.ExternalAuthentications)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <tr>        \r\n                                   " +
" <td>");


            
            #line 44 "..\..\Views\Registration\RegisterExisting.cshtml"
                                   Write(externalAuthentication.Username);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");


            
            #line 45 "..\..\Views\Registration\RegisterExisting.cshtml"
                                   Write(externalAuthentication.Email);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                    <td>");


            
            #line 46 "..\..\Views\Registration\RegisterExisting.cshtml"

                                   Write(externalAuthentication.ExternalAuthenticationType);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                </tr>\r\n");


            
            #line 48 "..\..\Views\Registration\RegisterExisting.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </tbody>\r\n                    </table>\r\n");


            
            #line 51 "..\..\Views\Registration\RegisterExisting.cshtml"

                    using (Html.BeginForm("RegisterExisting", "Registration", FormMethod.Post, new { id = "link-registration-form" }))
                    {

            
            #line default
            #line hidden
WriteLiteral("                         <fieldset>\r\n\r\n                             <div class=\"c" +
"learfix\">\r\n                                 ");


            
            #line 57 "..\..\Views\Registration\RegisterExisting.cshtml"
                            Write(Html.LabelFor(model => model.UserName, Resources.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                 <div class=\"input\">\r\n                         " +
"            ");


            
            #line 59 "..\..\Views\Registration\RegisterExisting.cshtml"
                                Write(Html.EditorFor(model => model.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 60 "..\..\Views\Registration\RegisterExisting.cshtml"
                                      if (!ViewData.ModelState.IsValidField("UserName"))
                                     {

            
            #line default
            #line hidden
WriteLiteral("                                         <div class=\"alert alert-error\">\r\n       " +
"                                      <a class=\"close\" data-dismiss=\"alert\">×</a" +
">\r\n                                             ");


            
            #line 64 "..\..\Views\Registration\RegisterExisting.cshtml"
                                        Write(Html.ValidationMessageFor(model => model.UserName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                         </div>\r\n");


            
            #line 66 "..\..\Views\Registration\RegisterExisting.cshtml"
                                     }

            
            #line default
            #line hidden
WriteLiteral("                                 </div>\r\n                                 \r\n     " +
"                        </div>\r\n\r\n                             <div class=\"clear" +
"fix\">\r\n                                 ");


            
            #line 72 "..\..\Views\Registration\RegisterExisting.cshtml"
                            Write(Html.LabelFor(model => model.Email, Resources.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                 <div class=\"input\">\r\n                         " +
"            ");


            
            #line 74 "..\..\Views\Registration\RegisterExisting.cshtml"
                                Write(Html.EditorFor(model => model.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 75 "..\..\Views\Registration\RegisterExisting.cshtml"
                                      if (!ViewData.ModelState.IsValidField("Email"))
                                     {

            
            #line default
            #line hidden
WriteLiteral("                                         <div class=\"alert alert-error\">\r\n       " +
"                                      <a class=\"close\" data-dismiss=\"alert\">×</a" +
">\r\n                                             ");


            
            #line 79 "..\..\Views\Registration\RegisterExisting.cshtml"
                                        Write(Html.ValidationMessageFor(model => model.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                         </div>\r\n");


            
            #line 81 "..\..\Views\Registration\RegisterExisting.cshtml"
                                     }

            
            #line default
            #line hidden
WriteLiteral("                                 </div>\r\n                             </div>\r\n\r\n " +
"                            <div class=\"clearfix\">\r\n                            " +
"     ");


            
            #line 86 "..\..\Views\Registration\RegisterExisting.cshtml"
                            Write(Html.LabelFor(model => model.Password, Resources.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                 <div class=\"input\">\r\n                         " +
"            ");


            
            #line 88 "..\..\Views\Registration\RegisterExisting.cshtml"
                                Write(Html.PasswordFor(model => model.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 89 "..\..\Views\Registration\RegisterExisting.cshtml"
                                      if (!ViewData.ModelState.IsValidField("Password"))
                                     {

            
            #line default
            #line hidden
WriteLiteral("                                         <div class=\"alert alert-error\">\r\n       " +
"                                      <a class=\"close\" data-dismiss=\"alert\">×</a" +
">\r\n                                             ");


            
            #line 93 "..\..\Views\Registration\RegisterExisting.cshtml"
                                        Write(Html.ValidationMessageFor(model => model.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                         </div>\r\n");


            
            #line 95 "..\..\Views\Registration\RegisterExisting.cshtml"
                                     }

            
            #line default
            #line hidden
WriteLiteral("                                 </div>\r\n                             </div>\r\n\r\n " +
"                            <div class=\"clearfix\">\r\n                            " +
"     ");


            
            #line 100 "..\..\Views\Registration\RegisterExisting.cshtml"
                            Write(Html.LabelFor(model => model.ConfirmPassword, Resources.ConfirmPassword));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                 <div class=\"input\">\r\n                         " +
"            ");


            
            #line 102 "..\..\Views\Registration\RegisterExisting.cshtml"
                                Write(Html.PasswordFor(model => model.ConfirmPassword));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 103 "..\..\Views\Registration\RegisterExisting.cshtml"
                                      if (!ViewData.ModelState.IsValidField("ConfirmPassword"))
                                     {

            
            #line default
            #line hidden
WriteLiteral("                                         <div class=\"alert alert-error\">\r\n       " +
"                                      <a class=\"close\" data-dismiss=\"alert\">×</a" +
">\r\n                                             ");


            
            #line 107 "..\..\Views\Registration\RegisterExisting.cshtml"
                                        Write(Html.ValidationMessageFor(model => model.ConfirmPassword));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                         </div>\r\n");


            
            #line 109 "..\..\Views\Registration\RegisterExisting.cshtml"
                                     }

            
            #line default
            #line hidden
WriteLiteral("                                 </div>\r\n                             </div>\r\n\r\n " +
"                            <div>\r\n                                <button class" +
"=\"btn btn-primary pull-right\" data-bind=\"click: register\">");


            
            #line 114 "..\..\Views\Registration\RegisterExisting.cshtml"
                                                                                                  Write(Resources.Register);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n                             </div>\r\n                         </fields" +
"et>\r\n");


            
            #line 117 "..\..\Views\Registration\RegisterExisting.cshtml"
                    }
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"page-footer\">\r\n        </" +
"div>\r\n    </div>\r\n</section>\r\n\r\n");



            #line 126 "..\..\Views\Registration\RegisterExisting.cshtml"
   
    if (!Model.Success)
    {
        using (Html.BeginScriptContext())
        {
            Html.AddScriptBlock(@"
        var registration = {};

        (function (index) {

            registration = index;

            index.register = function () {
                jQuery('#link-registration-form').submit();
            };

            jQuery(function () {
                ko.applyBindings(index, jQuery('#link-registation-container')[0]);
            });

        } (registration));");
        }
    }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
