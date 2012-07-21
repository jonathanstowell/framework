﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBytes.Email.Dispatch.Widget.Frontend.Views.EmailDispatchWidget
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
    using ThreeBytes.Email.Dispatch.Widget.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailDispatchWidget/MostRecent.cshtml")]
    public class MostRecent : System.Web.Mvc.WebViewPage<IList<ThreeBytes.Email.Dispatch.Widget.Entities.EmailDispatchWidgetEmailMessage>>
    {
        public MostRecent()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\EmailDispatchWidget\MostRecent.cshtml"
  
    ViewBag.Title = Resources.BrowserTitle;


            
            #line default
            #line hidden
WriteLiteral("    \r\n<div id=\"most-recent-dispatched-emails-container\">\r\n    <h3>");


            
            #line 8 "..\..\Views\EmailDispatchWidget\MostRecent.cshtml"
   Write(Resources.MostRecentlyDispatchedEmails);

            
            #line default
            #line hidden
WriteLiteral(@"</h3>
    <p data-bind=""visible: Items().length == 0"">No emails to display</p>
    <table id=""most-recent-dispatched-emails-table"" class=""table table-striped table-bordered table-condensed"" data-bind=""visible: Items().length > 0"">
        <thead>
            <tr>
                <th>
                    ");


            
            #line 14 "..\..\Views\EmailDispatchWidget\MostRecent.cshtml"
               Write(Resources.To);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");


            
            #line 17 "..\..\Views\EmailDispatchWidget\MostRecent.cshtml"
               Write(Resources.Subject);

            
            #line default
            #line hidden
WriteLiteral(@"
                </th>
            </tr>
        </thead>
        <tbody id=""most-recent-dispatched-emails-tbody"" data-bind=""foreach: Items"">
            <tr data-bind=""click: function(event) { $parent.raiseDetails($data); }"" class=""selectable"">        
                <td data-bind=""text: To""></td>
                <td data-bind=""text: Subject""></td>
            </tr>
        </tbody>
    </table>
</div>

");


            
            #line 30 "..\..\Views\EmailDispatchWidget\MostRecent.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var most_recent_dispatched_emails_latest_list = {};

        (function(index) {

            dispatched_emails_latest_list = index = ko.mapping.fromJS(" + @Html.Raw(string.Format("{{\"Items\" : {0}}}", new JavaScriptSerializer().Serialize(Model))) + @");
            
            index.raiseDetails = function(obj) {
                jQuery(document).trigger('dispatchedEmailDetails', [obj]);
            };

            jQuery(function() {
                ko.applyBindings(index, jQuery('#most-recent-dispatched-emails-container')[0]);
            });
        
            setInterval(function() {
                jQuery.getJSON('" + @Url.Action("MostRecent", "EmailDispatchWidget") + @"', function (data) {
                    ko.mapping.fromJS(data, index);          
                });
            }, 5000);
         
        } (most_recent_dispatched_emails_latest_list));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
