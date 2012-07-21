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

namespace ThreeBytes.User.Authentication.Login.Frontend.Views.Login
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
    using ThreeBytes.User.Authentication.Login.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Login/Login.cshtml")]
    public class Login : System.Web.Mvc.WebViewPage<ThreeBytes.User.Authentication.Login.Frontend.Models.LoginViewModel>
    {
        public Login()
        {
        }
        public override void Execute()
        {
WriteLiteral(" ");


WriteLiteral("           \r\n");


            
            #line 3 "..\..\Views\Login\Login.cshtml"
  
    ViewBag.Title = Resources.BrowserTitle;


            
            #line default
            #line hidden
WriteLiteral("\r\n<section id=\"login\">\r\n    <div id=\"login-container\">\r\n        <div class=\"hero-" +
"unit\"> \r\n            <h1>");


            
            #line 10 "..\..\Views\Login\Login.cshtml"
           Write(Resources.Login);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"span8 c" +
"olumns\">&nbsp;</div>\r\n            <div class=\"span4 columns\">\r\n                <" +
"div id=\"login-form-container\">\r\n");


            
            #line 16 "..\..\Views\Login\Login.cshtml"
                     using (Html.BeginForm("Login", "Login", FormMethod.Post, new { id = "login-form", @class="well" }))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <fieldset>\r\n                            ");


            
            #line 19 "..\..\Views\Login\Login.cshtml"
                       Write(Html.TextBoxFor(model => model.Username, new { placeholder="Username or Email"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 20 "..\..\Views\Login\Login.cshtml"
                             if (!ViewData.ModelState.IsValidField("Username"))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <div class=\"alert alert-error\">\r\n                " +
"                    <a class=\"close\" data-dismiss=\"alert\">×</a>\r\n               " +
"                     ");


            
            #line 24 "..\..\Views\Login\Login.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Username));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n");


            
            #line 26 "..\..\Views\Login\Login.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("\r\n                            ");


            
            #line 28 "..\..\Views\Login\Login.cshtml"
                       Write(Html.PasswordFor(model => model.Password, new { placeholder="Password"}));

            
            #line default
            #line hidden
WriteLiteral(" \r\n                            <button class=\"btn btn-primary\" data-bind=\"click: " +
"login\">Sign in</button>\r\n");


            
            #line 30 "..\..\Views\Login\Login.cshtml"
                             if (!ViewData.ModelState.IsValidField("Password"))
                             {

            
            #line default
            #line hidden
WriteLiteral("                                 <div class=\"alert alert-error\">\r\n               " +
"                      <a class=\"close\" data-dismiss=\"alert\">×</a>\r\n             " +
"                        ");


            
            #line 34 "..\..\Views\Login\Login.cshtml"
                                Write(Html.ValidationMessageFor(model => model.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                 </div>\r\n");


            
            #line 36 "..\..\Views\Login\Login.cshtml"
                             }

            
            #line default
            #line hidden
WriteLiteral("                                \r\n                            <label class=\"check" +
"box\">\r\n                                ");


            
            #line 39 "..\..\Views\Login\Login.cshtml"
                           Write(Html.CheckBoxFor(model => model.RememberMe));

            
            #line default
            #line hidden
WriteLiteral(" Remember me <span class=\"separator\">·</span> <a href=\"#\" data-bind=\"click: raise" +
"ForgottenPasswordOpen\">Forgotten Password?</a>\r\n                            </la" +
"bel>\r\n\r\n                        </fieldset>\r\n");


            
            #line 43 "..\..\Views\Login\Login.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n                <hr />\r\n                <div id=\"registat" +
"ion-container\">\r\n");


            
            #line 47 "..\..\Views\Login\Login.cshtml"
                       Html.RenderAction("PartialRegister", "Registration"); 

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n        <div id=\"logi" +
"n-footer-container\" class=\"page-footer\"></div>\r\n    </div>\r\n\r\n");


            
            #line 54 "..\..\Views\Login\Login.cshtml"
       Html.RenderAction("ResetPassword", "PasswordManagement"); 

            
            #line default
            #line hidden
WriteLiteral("</section>\r\n\r\n");


            
            #line 57 "..\..\Views\Login\Login.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var login = {};

        (function (index) {

            login = index;

            index.login = function () {
                jQuery('#login-form').submit();
            };

            index.raiseForgottenPasswordOpen = function() {
                jQuery(document).trigger('resetPassword');
            };

            jQuery(function () {
                ko.applyBindings(index, jQuery('#login-form-container')[0]);
            });

        } (login));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
