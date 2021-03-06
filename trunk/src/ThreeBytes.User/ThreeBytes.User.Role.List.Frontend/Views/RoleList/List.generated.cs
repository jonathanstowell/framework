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

namespace ThreeBytes.User.Role.List.Frontend.Views.RoleList
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
    using ThreeBytes.User.Role.List.Frontend.Models;
    using ThreeBytes.User.Role.List.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/RoleList/List.cshtml")]
    public class List : System.Web.Mvc.WebViewPage<PagedRoleListRoleViewModel>
    {
        public List()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\RoleList\List.cshtml"
  
    ViewBag.Title = Resources.Index;


            
            #line default
            #line hidden
WriteLiteral(@"<div id=""latest-user-roles-container"">
    <div data-bind=""latestItems: latestViewModel""></div>
</div>
<div id=""paged-user-roles-container"">   
    <div data-bind=""pagedGrid: pagedViewModel, pagedGridTemplate: 'paged-user-roles-table-tmpl'""></div>
</div>

<script type=""text/x-jquery-tmpl"" id=""paged-user-roles-table-tmpl"">
    <div class=""widget widget-table"">
        <div class=""widget-header"">
            <i class=""icon-th-list""></i>
            <h3>System Roles</h3>
            <div class=""pull-right-menu"">
                <em>");


            
            #line 18 "..\..\Views\RoleList\List.cshtml"
               Write(Resources.There);

            
            #line default
            #line hidden
WriteLiteral(@"&nbsp;<span data-bind=""text:is_are""></span>&nbsp;<span data-bind=""text:totalItemCount""></span>&nbsp;<span data-bind=""text:plural""></span></em>
                <button class=""btn btn-primary"" data-bind=""click: additionalFunctions.raiseCreate"">Create</button>
            </div>
        </div>
        <div class=""widget-content"">
            <table id=""paged-user-roles-table""  class=""table table-striped table-bordered table-condensed"">
                <thead>
                    <tr>
                        <th class=""header yellow"" data-bind=""click: setOrderBy.bind($data, 'Name'), css: { headerSortDown: orderBy() == 'Name' && isAsc(), headerSortUp: orderBy() == 'Name' && !isAsc() }"">
                            ");


            
            #line 27 "..\..\Views\RoleList\List.cshtml"
                       Write(Resources.RoleName);

            
            #line default
            #line hidden
WriteLiteral(@"
                        </th>
                        <th class=""header green"" data-bind=""click: setOrderBy.bind($data, 'CreationDateTime'), css: { headerSortDown: orderBy() == 'CreationDateTime' && isAsc(), headerSortUp: orderBy() == 'CreationDateTime' && !isAsc() }"">
                            ");


            
            #line 30 "..\..\Views\RoleList\List.cshtml"
                       Write(Resources.Creation);

            
            #line default
            #line hidden
WriteLiteral(@"
                        </th>
                        <th class=""header red"" data-bind=""click: setOrderBy.bind($data, 'LastModifiedDateTime'), css: { headerSortDown: orderBy() == 'LastModifiedDateTime' && isAsc(), headerSortUp: orderBy() == 'LastModifiedDateTime' && !isAsc() }"">
                            ");


            
            #line 33 "..\..\Views\RoleList\List.cshtml"
                       Write(Resources.LastModified);

            
            #line default
            #line hidden
WriteLiteral(@"
                        </th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tbody id=""paged-user-roles-tbody"" data-bind=""foreach: items"">
                    <tr>        
                        <td data-bind=""text: Name""></td>
                        <td data-bind=""text: CreationDateTime""></td>
                        <td data-bind=""text: LastModifiedDateTime""></td>
                        <td>
                            <div class=""btn-group open"">
                                <button class=""btn btn-primary dropdown-toggle"" data-toggle=""dropdown"">Select <span class=""caret""></span></button>
                                <ul class=""dropdown-menu"">
                                    <li><a href=""#"" data-bind=""click: function(event) { $parent.additionalFunctions.raiseEdit($data); }"">");


            
            #line 48 "..\..\Views\RoleList\List.cshtml"
                                                                                                                                    Write(Resources.Edit);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                                    <li><a href=\"#\" data-bind=\"click: " +
"function(event) { $parent.additionalFunctions.raiseDetails($data); }\">");


            
            #line 49 "..\..\Views\RoleList\List.cshtml"
                                                                                                                                       Write(Resources.Details);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                                </ul>\r\n                            </d" +
"iv>\r\n                        </td>\r\n                    </tr>\r\n                <" +
"/tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</script>\r\n\r\n");


            
            #line 60 "..\..\Views\RoleList\List.cshtml"
   
    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"
        var user_role_latest_list  = {};
    
        (function (index) {

            var itemMapping = {
			    'CreationDateTime': ko.utils.getDateFromJson('dd/MMM HH:mm'),
                'LastModifiedDateTime': ko.utils.getDateFromJson('dd/MMM HH:mm')
		    };

            var itemViewModel = function(data) {
			    ko.mapping.fromJS(data, itemMapping, this);
		    };

            var mapping = {	
			    'Items': {
				    create: function(options) {
					    return new itemViewModel(options.data);
				    }
			    }
		    };
        
            user_role_latest_list = index = ko.mapping.fromJS(" + @Html.Raw(new JavaScriptSerializer().Serialize(Model.MostRecentResult)) + @", mapping);

            index.latestViewModel = new ko.latestItems.viewModel({
                controller: 'Roles/List',
                action: 'GetNewerThan',
                data: index,
                singular: 'Role',
                plural: 'Roles',
                loadPageCallback: function(data) {
                    ko.mapping.fromJS(data, index);
                },
                divIdentifier: 'latest-user-roles-container',
                pagingComponentIdentifier: 'paged-user-roles',
                columns: [
                    { headerText: 'Name', rowText: 'Name' },
                    { headerText: 'Creation', rowText: 'CreationDateTime' },
                    { headerText: 'Last Modified', rowText: 'LastModifiedDateTime' }
                ]
            });

            jQuery(function() {
                ko.applyBindings(index, jQuery('#latest-user-roles-container')[0]);
            });     

        } (user_role_latest_list));


        var user_roles_paged_list  = {};

        (function (index) {

            var itemMapping = {
			    'CreationDateTime': ko.utils.getDateFromJson('dd/MMM HH:mm'),
                'LastModifiedDateTime': ko.utils.getDateFromJson('dd/MMM HH:mm')
		    };

            var itemViewModel = function(data) {
			    ko.mapping.fromJS(data, itemMapping, this);
		    };

            var mapping = {	
			    'Items': {
				    create: function(options) {
					    return new itemViewModel(options.data);
				    }
			    }
		    };

            index = ko.mapping.fromJS(" + @Html.Raw(new JavaScriptSerializer().Serialize(Model.PagedResult)) + @", mapping);

            jQuery(document).bind('userRoleUpdated', function (event, item) {
                var update = ko.utils.arrayFirst(index.Items(), function(obj) {
                    return obj.Id() === item.Id();
                });

                update.Name(item.Name());
                update.LastModifiedDateTime(ko.utils.getFormatedDateTimeNow());
            });

            index.pagedViewModel = new ko.pagedGrid.viewModel({
                controller: 'Roles',
                action: 'GetPage',
                data: index,
                singular: 'Role',
                plural: 'Roles',
                pagingComponentIdentifier: 'paged-user-roles',
                loadPageCallback: function(data) {
                    ko.mapping.fromJS(data, index);
                },
                columns: [
                    { headerText: 'Name', rowText: 'Name' },
                    { headerText: 'Application Name', rowText: 'ApplicationName' },
                    { headerText: 'Creation Date Time', rowText: 'CreationDateTime' },
                    { headerText: 'Last Modified Date Time', rowText: 'LastModifiedDateTime' }
                ],
                additionalFunctions: {
                    raiseEdit: function (obj) {
                        jQuery(document).trigger('userRoleEdit', [obj.Id()]);
                    },
                    raiseDetails: function (obj) {
                        jQuery(document).trigger('userRoleDetails', [obj]);
                    },
                    raiseCreate: function () {
                        jQuery(document).trigger('userRoleCreate');
                    }
                }
            });
        
            jQuery(function() {
                ko.applyBindings(index, jQuery('#paged-user-roles-container')[0]);
            });

        } (user_roles_paged_list));");
    }


            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
