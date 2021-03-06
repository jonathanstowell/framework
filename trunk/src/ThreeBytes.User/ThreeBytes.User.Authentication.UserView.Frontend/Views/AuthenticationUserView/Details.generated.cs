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

namespace ThreeBytes.User.Authentication.UserView.Frontend.Views.AuthenticationUserView
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
    using ThreeBytes.User.Authentication.UserView.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/AuthenticationUserView/Details.cshtml")]
    public class Details : System.Web.Mvc.WebViewPage<ThreeBytes.User.Authentication.UserView.Entities.AuthenticationUserViewUser>
    {
        public Details()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\AuthenticationUserView\Details.cshtml"
  
    ViewBag.Title = Resources.BrowserTitle;


            
            #line default
            #line hidden
WriteLiteral(@"
<div id=""user-details-container"">
    <div id=""user-details-modal"" class=""modal modal-medium-wide hide fade"">
        <div class=""modal-header"">
            <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
            <h3>
                <span data-bind=""text: Username""></span> ");


            
            #line 11 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                    Write(Resources.Details);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </h3>\r\n        </div>\r\n        <div class=\"modal-body modal-body-sc" +
"rollable\">\r\n            <div class=\"row\">\r\n                <div class=\"span7 wel" +
"l-large\">\r\n                    <h3>\r\n                        ");


            
            #line 18 "..\..\Views\AuthenticationUserView\Details.cshtml"
                   Write(Resources.Details);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </h3>\r\n\r\n                    <div id=\"user-properties-conta" +
"iner\" class=\"row\">\r\n                        <div class=\"span2 well-small\">\r\n    " +
"                        <div class=\"display-label\">");


            
            #line 23 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.Username);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            <div class=\"display-field\"><span data-bind=\"t" +
"ext: Username\"></span></div>\r\n\r\n                            <div class=\"display-" +
"label\">");


            
            #line 26 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.ApplicationName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            <div class=\"display-field\"><span data-bind=\"t" +
"ext: ApplicationName\"></span></div>\r\n\r\n                            <div class=\"d" +
"isplay-label\">");


            
            #line 29 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.Email);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            <div class=\"display-field\"><span data-bind=\"t" +
"ext: Email\"></span></div>\r\n                        </div>\r\n\r\n                   " +
"     <div class=\"span2 well-small\">\r\n                            <div class=\"dis" +
"play-label\">");


            
            #line 34 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.IsVerified);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            <div class=\"display-field\"><span data-bind=\"t" +
"ext: IsVerified\"></span></div>\r\n\r\n                            <div class=\"displa" +
"y-label\">");


            
            #line 37 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.IsLockedOut);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            <div class=\"display-field\"><span data-bind=\"t" +
"ext: IsLockedOut\"></span></div>\r\n\r\n                            <div class=\"displ" +
"ay-label\">");


            
            #line 40 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.Creation);

            
            #line default
            #line hidden
WriteLiteral(@"</div>
                            <div class=""display-field""><span data-bind=""text: GetDate(CreationDateTime())""></span></div>
                        </div>
                        <div class=""span2 well-small"">
                            <div class=""display-label"">");


            
            #line 44 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                                  Write(Resources.LastModified);

            
            #line default
            #line hidden
WriteLiteral(@"</div>
                            <div class=""display-field""><span data-bind=""text: GetDate(LastModifiedDateTime())""></span></div>
                        </div>
                    </div>
                </div>
            </div>
             <div class=""row"" data-bind=""visible: Roles().length > 0"">
                <div id=""user-roles-section-container"" class=""span6 well-large"">
                    <h3>
                        Roles
                    </h3>

                    <div id=""user-roles-container"" data-bind=""foreach: Roles"">
                        <div class=""display-field""><span data-bind=""text: Name""></span></div>
                    </div>
                </div>
            </div>
            <div id=""user-history-section-container"" class=""row"" data-bind=""visible: History().length > 0"">
                <div class=""span6 well-large"">
                    <h3>
                        ");


            
            #line 64 "..\..\Views\AuthenticationUserView\Details.cshtml"
                   Write(Resources.History);

            
            #line default
            #line hidden
WriteLiteral(@"
                    </h3>
                    <div id=""user-history-container"">
                        <table class=""table table-striped table-bordered table-condensed scrollable"">
                            <thead>
                                <tr>
                                    <th>Date Time</th>
                                    <th>");


            
            #line 71 "..\..\Views\AuthenticationUserView\Details.cshtml"
                                   Write(Resources.Operation);

            
            #line default
            #line hidden
WriteLiteral(@"</th>
                                </tr>
                            </thead>
                            <tbody id=""user-role-tbody"" data-bind=""foreach: History"">
                                <tr>        
                                    <td data-bind=""text: GetDate(LastModifiedDateTime)""></td>
                                    <td data-bind=""text: Operation""></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class=""modal-footer"">
            <button class=""btn btn-primary"" data-bind=""click: raiseManage"">Manage</button>
            <button class=""btn btn-danger"" data-bind=""click: raiseClose"">Close</button>
        </div>
    </div>
</div>

");


            
            #line 92 "..\..\Views\AuthenticationUserView\Details.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var user_details = {};

        (function (index) {

            user_details = index;

            index.Id = ko.observable();
            index.ItemId = ko.observable();
            index.Username = ko.observable();
            index.ApplicationName = ko.observable();
            index.Email = ko.observable();
            index.IsVerified = ko.observable();
            index.IsLockedOut = ko.observable();
            index.CreationDateTime = ko.observable();
            index.LastModifiedDateTime = ko.observable();
            index.History = ko.observableArray();
            index.Roles = ko.observableArray();

            index.detailsVisible = ko.observable(true);
            index.rolesVisible = ko.observable(true);
            index.historyVisible = ko.observable(true);

            index.raiseClose = function () {
                index.detailModal.modal('hide');
            };

            index.raiseManage = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('userManage', index.ItemId());
            };

            index.raiseDelete = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('userDelete', index.ItemId());
            };

            jQuery(document).bind('userDetails', function (event, user) {

                jQuery.getJSON('" + @Url.Action("GetDetails", "User") + @"', { id: user.Id() }, function (data) {

                    index.Id(data.Id);
                    index.ItemId(data.ItemId);
                    index.Username(data.Username);
                    index.ApplicationName(data.ApplicationName);
                    index.Email(data.Email);
                    index.IsVerified(data.IsVerified);
                    index.IsLockedOut(data.IsLockedOut);
                    index.CreationDateTime(data.CreationDateTime);
                    index.LastModifiedDateTime(data.LastModifiedDateTime);
                    index.History(data.History);

                    index.Roles.removeAll();

                    jQuery.each(data.Roles, function() {
                        index.Roles.push(ko.mapping.fromJS(this));
                    });

                    index.detailModal.modal('show');
                });
            });

            index.toggleDetails = function() {

                if (index.detailsVisible()) {
                    index.detailsVisible(false);
                } else {
                    index.detailsVisible(true);
                }

                jQuery('#user-properties-container').slideToggle(500);  
            };

            index.toggleRoles = function() {

                if (index.rolesVisible()) {
                    index.rolesVisible(false);
                } else {
                    index.rolesVisible(true);
                }

                jQuery('#user-roles-container').slideToggle(500);
            };

            index.toggleHistory = function() {
                
                if (index.historyVisible()) {
                    index.historyVisible(false);
                } else {
                    index.historyVisible(true);
                }

                jQuery('#user-history-container').slideToggle(500);
            };

            jQuery(function () {
                ko.applyBindings(index, jQuery('#user-details-container')[0]);
                index.detailModal = jQuery('#user-details-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (user_details));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
