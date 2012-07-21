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

namespace ThreeBytes.User.Authentication.UserManagement.Frontend.Views.AuthenticationUserManagement
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
    using ThreeBytes.User.Authentication.UserManagement.Frontend.Models;
    using ThreeBytes.User.Authentication.UserManagement.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/AuthenticationUserManagement/Manage.cshtml")]
    public class Manage : System.Web.Mvc.WebViewPage<UpdateUserViewModel>
    {
        public Manage()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\AuthenticationUserManagement\Manage.cshtml"
  
    ViewBag.Title = Resources.BrowserTitle;


            
            #line default
            #line hidden
WriteLiteral("\r\n<div id=\"user-management-container\">\r\n    <div id=\"user-management-modal\" class" +
"=\"modal hide fade\">\r\n        <div class=\"modal-header\">\r\n            <a href=\"#\"" +
" class=\"close\" data-bind=\"click: raiseClose\">×</a>\r\n            <h3>");


            
            #line 10 "..\..\Views\AuthenticationUserManagement\Manage.cshtml"
           Write(Resources.Manage);

            
            #line default
            #line hidden
WriteLiteral(@" <span data-bind=""text: Username""></span></h3>
        </div>
        <div class=""modal-body"">
            <div>
                <span data-bind=""error: GeneralErrors""></span>
            </div>
            <form>
                <div class=""alert-message block-message error hide"">
                    <a class=""close"" href=""#"">×</a>               
                </div>
                <fieldset>
                    <div class=""clearfix"">
                        ");


            
            #line 22 "..\..\Views\AuthenticationUserManagement\Manage.cshtml"
                   Write(Html.Label(Resources.Roles));

            
            #line default
            #line hidden
WriteLiteral(@"
                        <div class=""input"">
                            <select data-bind=""options: AvailableRoles, optionsText: 'Name', optionsValue: 'Id', value: AddRoleId, optionsCaption: 'Choose...'""></select>
                            <button class=""btn btn-primary"" data-bind=""click: saveAssociation"">");


            
            #line 25 "..\..\Views\AuthenticationUserManagement\Manage.cshtml"
                                                                                          Write(Resources.AddRole);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n                            <div data-bind=\"error: RolesErrors\"></div>" +
"\r\n                        </div>\r\n                    </div>\r\n                  " +
"  <div class=\"clearfix\">\r\n                        ");


            
            #line 30 "..\..\Views\AuthenticationUserManagement\Manage.cshtml"
                   Write(Html.Label("User Roles"));

            
            #line default
            #line hidden
WriteLiteral(@"
                        <div class=""input"">
                            <select data-bind=""options: Roles, optionsText: 'Name', optionsValue: 'Id', value: RemoveRoleId, optionsCaption: 'Choose...'""></select>
                            <button class=""btn btn-danger"" data-bind=""click: removeAssociation"">Remove Role</button>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
        <div class=""modal-footer"">
            <div data-bind=""currentlyViewingComponent: currentViewersViewModel""></div>
            <button class=""btn btn-info"" data-bind=""click: raiseDetails"">Details</button>
            <button class=""btn btn-danger"" data-bind=""click: raiseClose"">Close</button>
        </div>
    </div>
</div>

");


            
            #line 47 "..\..\Views\AuthenticationUserManagement\Manage.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var user_management = {};

        (function (index) {

            user_management = index;

            var hub = jQuery.connection.userManagementHub;

            var val = ko.setupValidation([], []);
            val.createErrorCollections({Roles: 0, General: 0}, index);

            index.Id = ko.observable();
            index.AddRoleId = ko.observable();
            index.RemoveRoleId = ko.observable();
            index.Username = ko.observable();
            index.Roles = ko.observableArray();
            index.SystemRoles = ko.mapping.fromJS(" + @Html.Raw(new JavaScriptSerializer().Serialize(Model.Roles)) + @");

            index.AvailableRoles = ko.dependentObservable(function() {
                var results = [];
                ko.utils.arrayForEach(index.SystemRoles(), function(item) {
                    var assigned = false;
                    ko.utils.arrayForEach(index.Roles(), function(role) {
                        if (item.Id() == role.Id()) {
                            assigned = true;
                        }
                    });

                    if (!assigned) {
                        results.push(item);
                    }
                });

                return results;
            }, index);

            index.saveAssociation = function () {
                jQuery.post('" + @Url.Action("CreateUserRoleAssociation", "AuthenticationUserManagement") + @"', { 'userId': index.Id(), 'roleId': index.AddRoleId() }, function (dataReturned) {
                    if (dataReturned.IsValid) {
                        index.manageModal.modal('hide');
                        jQuery.connection.hub.start(function () { hub.addedRole(index.Id(), index.AddRoleId()); });
                    }
                    else {
                        val.rebindValidations({Roles: 0, General: 0}, index, dataReturned.Errors);
                    }
                });
            };

            index.removeAssociation = function () {
                jQuery.post('" + @Url.Action("RemoveUserRoleAssociation", "AuthenticationUserManagement") + @"', { 'userId': index.Id(), 'roleId': index.RemoveRoleId() }, function (dataReturned) {
                    if (dataReturned.IsValid) {
                        index.manageModal.modal('hide');
                        jQuery.connection.hub.start(function () { hub.removedRole(index.Id(), index.AddRoleId()); });
                    }
                    else {
                        val.rebindValidations({Roles: 0, General: 0}, index, dataReturned.Errors);
                    }
                });
            };  

            index.raiseClose = function () {
                index.manageModal.modal('hide');
            };

            index.raiseDetails = function () {
                jQuery(document).trigger('userDetails', [index]);
                index.manageModal.modal('hide');
            }

            index.currentViewersViewModel = new ko.currentlyViewingComponent.viewModel({
                hub: hub,
                id: index.Id,
                modalSelector: '#user-management-modal'
            });

            hub.handleAddedRole = function (userId, roleId) {
                if (index.Id() != userId)
                    return;

                var findRole = ko.utils.arrayFirst(index.Roles(), function (item) {
                    return item.Id() == roleId;
                });

                if (findRole == null) {                    
                    var noLongerAvailableRole = ko.utils.arrayFirst(index.SystemRoles(), function (item) {
                        return item.Id() == roleId;
                    });
                    
                    if (noLongerAvailableRole != null)
                        index.Roles.push(noLongerAvailableRole);
                }
            };

            hub.handleRemovedRole = function (userId, roleId) {
                if (index.Id() != userId)
                    return;

                index.Roles.remove(function (item) {
                    return item.Id() == roleId;
                });
            };

            jQuery(document).bind('userManage', function (event, id) {

                jQuery.getJSON('" + @Url.Action("GetUserForUpdateOrDelete", "AuthenticationUserManagement") + @"', { id: id }, function (data) {

                    index.Id(data.User.Id);
                    index.Username(data.User.Username);

                    index.Roles.removeAll();

                    index.currentViewersViewModel.initialiseCurrentViewers(data.CurrentlyViewingUsers);

                    ko.utils.arrayForEach(data.User.Roles, function(item) {
                        index.Roles.push(ko.mapping.fromJS(item));
                    });

                    index.manageModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#user-management-container')[0]);
                index.manageModal = jQuery('#user-management-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (user_management));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
