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

namespace ThreeBytes.User.Role.Management.Frontend.Views.RoleManagement
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
    using ThreeBytes.User.Role.Management.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/RoleManagement/Edit.cshtml")]
    public class Edit : System.Web.Mvc.WebViewPage<ThreeBytes.User.Role.Management.Entities.RoleManagementRole>
    {
        public Edit()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\RoleManagement\Edit.cshtml"
  
    ViewBag.Title = Resources.Edit;


            
            #line default
            #line hidden
WriteLiteral("\r\n<div id=\"user-role-edit-container\">\r\n    <div id=\"user-role-edit-modal\" class=\"" +
"modal hide fade\">\r\n        <div class=\"modal-header\">\r\n            <a href=\"#\" c" +
"lass=\"close\" data-bind=\"click: raiseClose\">×</a>\r\n            <h3>");


            
            #line 10 "..\..\Views\RoleManagement\Edit.cshtml"
           Write(Resources.EditRole);

            
            #line default
            #line hidden
WriteLiteral(@"</h3>            
        </div>
        <div class=""modal-body"">
            <div data-bind=""error: GeneralErrors""></div>
            <form id=""rename-role-form"">
                <fieldset>
                    <div class=""clearfix""> 
                        ");


            
            #line 17 "..\..\Views\RoleManagement\Edit.cshtml"
                   Write(Html.LabelFor(model => model.Name, Resources.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n        \r\n                        <div class=\"input\">\r\n                        " +
"    ");


            
            #line 20 "..\..\Views\RoleManagement\Edit.cshtml"
                       Write(Html.TextBoxFor(model => model.Name, new { @data_val = "true", @data_val_required = "'Name' should not be empty.", @data_val_length = "'Name' must be a string with a maximum length of 20.", @data_val_length_max = "20", @data_bind = "value: Name" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <button type=\"submit\" class=\"btn btn-primary\" data-" +
"bind=\"click: rename\">");


            
            #line 21 "..\..\Views\RoleManagement\Edit.cshtml"
                                                                                               Write(Resources.Rename);

            
            #line default
            #line hidden
WriteLiteral(@"</button>
                            <div data-valmsg-for=""Name"" data-valmsg-replace=""true"" data-bind=""error: NameErrors""></div>
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


            
            #line 36 "..\..\Views\RoleManagement\Edit.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var user_role_edit = {};

        (function (index) {

            user_role_edit = index;

            var hub = jQuery.connection.roleManagementHub;

            var val = ko.setupValidation([], []);
            val.createErrorCollections({Name: 0, General: 0}, index, 'rename-role-form');
            var dmp = new diff_match_patch();

            index.Id = ko.observable();
            index.Name = ko.observable();
            index.currentViewersViewModel = new ko.currentlyViewingComponent.viewModel({
                hub: hub,
                id: index.Id,
                modalSelector: '#user-role-edit-modal'
            });

            index.rename = function (form) {
                if(!jQuery('#rename-role-form').valid())
                    return;

                jQuery.post('" + @Url.Action("Rename", "RoleManagement") + @"', {
                    'id': index.Id(),
                    'name': index.Name()
                }, function (dataReturned) {
                    if (dataReturned.IsValid) {
                        jQuery(document).trigger('userRoleUpdated', index);
                        index.editModal.modal('hide');
                    }
                    else {
                        val.rebindValidations({Name: 0, General: 0}, index, dataReturned.Errors);   
                    }
                });
            };

            index.raiseClose = function () {
                index.editModal.modal('hide');
            };

            index.raiseDetails = function () {
                jQuery(document).trigger('userRoleDetails', [index]);
                index.editModal.modal('hide');
            }

            jQuery(document).bind('userRoleEdit', function (event, id) {

                jQuery.getJSON('" + @Url.Action("GetNewsArticleForUpdateOrDelete", "RoleManagement") + @"', { id: id }, function (data) {

                    index.Id(data.Role.Id);
                    index.Name(data.Role.Name);

                    index.currentViewersViewModel.initialiseCurrentViewers(data.CurrentlyViewingUsers);

                    val.clearValidations({Name: 0, General: 0}, index);
                    index.editModal.modal('show');
                });
            });

            hub.handleIHaveEdited = function(id, property, content) {
                if (index.Id() != id)
                    return;

                if (index[property] == undefined)
                    return;

                dmp.Match_Distance = 1000;
                dmp.Match_Threshold = 0.5;
                dmp.Patch_DeleteThreshold = 0.5;

                var patches = dmp.patch_make(index[property](), content);
                var results = dmp.patch_apply(patches, index[property]());
                index[property](results[0]);
            };

            jQuery(function () {
                ko.applyBindings(index, jQuery('#user-role-edit-container')[0]);
                index.editModal = jQuery('#user-role-edit-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });

                jQuery('#rename-role-form > fieldset > div > div > input#Name').blur(function(event) {
                    hub.iHaveEdited(index.Id(), 'Name', index.Name());
                });
            });
        } (user_role_edit));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
