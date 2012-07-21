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

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Views.Foursquare
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Foursquare/Link.cshtml")]
    public class Link : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Link()
        {
        }
        public override void Execute()
        {
WriteLiteral(@"<div id=""link-foursquare-container"">
    <div id=""link-foursquare-modal"" class=""modal hide fade"">
        <div class=""modal-header"">
            <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
            <h3>Link Foursquare Account</h3>
        </div>
        <div class=""modal-body"">
            Please click link if you would like to link a foursquare account to <span data-bind=""text: Username""></span>.
        </div>
        <div class=""modal-footer"">
            <button class=""btn btn-primary"" data-bind=""click: link"">Link</button>
            <button class=""btn btn-danger"" data-bind=""click: raiseClose"">Close</button>
        </div>
    </div>
</div>

");


            
            #line 17 "..\..\Views\Foursquare\Link.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var link_foursquare_account = {};

        (function (index) {

            link_foursquare_account = index;

            index.Username = ko.observable();

            index.link = function () {
                window.location = '" + @Url.Action("LinkAccount", "Foursquare") + @"?redirectUrl=' + window.location;
            };

            index.raiseClose = function () {
                index.displayModal.modal('hide');
            };

            jQuery(document).bind('linkFoursquare', function (event, id) {
                jQuery.getJSON('" + @Url.Action("GetDetails", "Foursquare") + @"', { id: id }, function (data) {
                    index.Username(data.Username);
                    index.displayModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#link-foursquare-container')[0]);
                index.displayModal = jQuery('#link-foursquare-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (link_foursquare_account));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
