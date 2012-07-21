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

namespace ThreeBytes.User.Profile.View.Frontend.Views.ProfileView
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
    
    #line 1 "..\..\Views\ProfileView\Links.cshtml"
    using System.Web.Script.Serialization;
    
    #line default
    #line hidden
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using ThreeBytes.Core.Extensions.Mvc;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ProfileView/Links.cshtml")]
    public class Links : System.Web.Mvc.WebViewPage<ThreeBytes.User.Profile.View.Entities.UserProfileViewProfile>
    {
        public Links()
        {
        }
        public override void Execute()
        {


WriteLiteral("\r\n<div id=\"user-profile-links-container\">\r\n    <h2>Links</h2>\r\n    <span data-bin" +
"d=\"visible: hasFacebook() == false\"><img class=\"link\" src=\"");


            
            #line 6 "..\..\Views\ProfileView\Links.cshtml"
                                                                        Write(Url.Content("~/img/facebook-nonactive-48x48.png"));

            
            #line default
            #line hidden
WriteLiteral("\" data-bind=\"click: raiseLinkFacebook\" /></span>\r\n    <span data-bind=\"visible: h" +
"asFacebook\"><a data-bind=\"attr: { href: facebookUrl }\" target=\"_blank\"><img src=" +
"\"");


            
            #line 7 "..\..\Views\ProfileView\Links.cshtml"
                                                                                                           Write(Url.Content("~/img/facebook-48x48.png"));

            
            #line default
            #line hidden
WriteLiteral("\"/></a></span>\r\n    <span data-bind=\"visible: hasFoursquare() == false\"><img clas" +
"s=\"link\" src=\"");


            
            #line 8 "..\..\Views\ProfileView\Links.cshtml"
                                                                          Write(Url.Content("~/img/foursquare-nonactive-48x48.png"));

            
            #line default
            #line hidden
WriteLiteral("\" data-bind=\"click: raiseLinkFoursquare\" /></span>\r\n    <span data-bind=\"visible:" +
" hasFoursquare\"><a data-bind=\"attr: { href: foursquareUrl }\" target=\"_blank\"><im" +
"g src=\"");


            
            #line 9 "..\..\Views\ProfileView\Links.cshtml"
                                                                                                               Write(Url.Content("~/img/foursquare-48x48.png"));

            
            #line default
            #line hidden
WriteLiteral("\"/></a></span>\r\n    <span data-bind=\"visible: hasTwitter() == false\"><img class=\"" +
"link\" src=\"");


            
            #line 10 "..\..\Views\ProfileView\Links.cshtml"
                                                                       Write(Url.Content("~/img/twitter-nonactive-48x48.png"));

            
            #line default
            #line hidden
WriteLiteral("\" data-bind=\"click: raiseLinkTwitter\" /></span>\r\n    <span data-bind=\"visible: ha" +
"sTwitter\"><a data-bind=\"attr: { href: twitterUrl }\" target=\"_blank\"><img src=\"");


            
            #line 11 "..\..\Views\ProfileView\Links.cshtml"
                                                                                                         Write(Url.Content("~/img/twitter-48x48.png"));

            
            #line default
            #line hidden
WriteLiteral("\"/></a></span>\r\n</div>\r\n\r\n");


            
            #line 14 "..\..\Views\ProfileView\Links.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"    
        var user_profile_links  = {};

        (function (index) {
        
            user_profile_links = index = ko.mapping.fromJS(" + @Html.Raw(new JavaScriptSerializer().Serialize(Model)) + @");

            index.getProvider = function(search) {
                return ko.utils.arrayFirst(index.ExternalAuthentications(), function(item) {
                   return item.ExternalAuthenticationType() == search;
                });
            };

            index.hasProvider = function(search) {
                return index.getProvider(search) != null;
            };

            index.hasFacebook = ko.computed(function() {
                return index.hasProvider(0);   
            });

            index.hasFoursquare = ko.computed(function() {
                return index.hasProvider(1);
            });

            index.hasTwitter = ko.computed(function() {
                return index.hasProvider(2);
            });

            index.facebookUrl = ko.computed(function() {
                var provider = index.getProvider(0);

                if (provider == null)
                    return '';

                return 'http://www.facebook.com/profile.php?id=' + provider.ExternalIdentifier();
            });

            index.foursquareUrl = ko.computed(function() {
                var provider = index.getProvider(1);

                if (provider == null)
                    return '';

                return 'http://foursquare.com/user/' + provider.ExternalIdentifier();
            });

            index.twitterUrl = ko.computed(function() {
                var provider = index.getProvider(2);

                if (provider == null)
                    return '';

                return 'https://twitter.com/account/redirect_by_id?id=' + provider.ExternalIdentifier();
            });

            index.raiseLinkFacebook = function() {
                jQuery(document).trigger('linkFacebook', index.ItemId());   
            };

            index.raiseLinkFoursquare = function() {
                jQuery(document).trigger('linkFoursquare', index.ItemId());
            };

            index.raiseLinkTwitter = function() {
                jQuery(document).trigger('linkTwitter', index.ItemId());
            };

            jQuery(function() {
                ko.applyBindings(index, jQuery('#user-profile-links-container')[0]);
            });

        } (user_profile_links));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
