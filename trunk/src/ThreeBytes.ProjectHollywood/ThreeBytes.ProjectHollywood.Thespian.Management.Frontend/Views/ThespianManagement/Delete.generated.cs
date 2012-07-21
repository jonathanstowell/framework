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

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Views.ThespianManagement
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
    using MvcContrib;
    using ThreeBytes.Core.Extensions.Mvc;
    using ThreeBytes.Core.Security.Concrete;
    using ThreeBytes.ProjectHollywood.Thespian.Management.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ThespianManagement/Delete.cshtml")]
    public class Delete : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.Thespian.Management.Entities.ThespianManagementThespian>
    {
        public Delete()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\ThespianManagement\Delete.cshtml"
 if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "ThespianManager" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <div id=\"delete-thespian-container\">\r\n        <div id=\"delete-thespian-modal\"" +
" class=\"modal hide fade\">\r\n            <div class=\"modal-header\">\r\n             " +
"   <a href=\"#\" class=\"close\" data-bind=\"click: raiseClose\">×</a>\r\n              " +
"  <h3>");


            
            #line 9 "..\..\Views\ThespianManagement\Delete.cshtml"
               Write(Resources.Delete);

            
            #line default
            #line hidden
WriteLiteral(@" <span data-bind=""fadeInText: FirstName""></span> <span data-bind=""fadeInText: LastName""></span></h3>
            </div>
            <div id=""delete-thespian-form-container"" class=""modal-body"">
                <div data-bind=""error: GeneralErrors""></div>
                <p>Are you sure you wish to delete <span data-bind=""fadeInText: FirstName""></span> <span data-bind=""fadeInText: LastName""></span>?</p>
            </div>
            <div class=""modal-footer"">
                <button type=""submit"" class=""btn btn-primary"" data-bind=""click: deleteThespian"">");


            
            #line 16 "..\..\Views\ThespianManagement\Delete.cshtml"
                                                                                           Write(Resources.ConfirmDelete);

            
            #line default
            #line hidden
WriteLiteral("</button>&nbsp;\r\n                <button type=\"submit\" class=\"btn btn-danger\" dat" +
"a-bind=\"click: raiseClose\">");


            
            #line 17 "..\..\Views\ThespianManagement\Delete.cshtml"
                                                                                      Write(Resources.Cancel);

            
            #line default
            #line hidden
WriteLiteral("</button>&nbsp;\r\n            </div>\r\n        </div>\r\n    </div>\r\n");


            
            #line 21 "..\..\Views\ThespianManagement\Delete.cshtml"

    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"
        var actor_delete = {};

        (function (index) {

            actor_delete = index;

            var hub = jQuery.connection.thespianManagementDeletionHub;

            var val = ko.setupValidation([], []);
            val.createErrorCollections({General: 0}, index, 'delete-thespian-form-container');

            index.Id = ko.observable();
            index.FirstName = ko.observable();
            index.LastName = ko.observable();

            index.deleteThespian = function (form) {
                jQuery.post('" + @Url.Action("Delete", "OurClients") + @"', { 'id': index.Id() }, function (returnedData) {
                    if (returnedData.IsValid) {
                        jQuery(document).trigger('thespianDeleted', [returnedData.Id]);
                        jQuery(document).trigger('publishProcessingNotification', ['Processing client deletion.', 'We are currently processing your request to delete ' + index.FirstName() + ' ' + index.LastName() + '.']);
                        index.deleteModal.modal('hide');
                    }
                    else {
                        val.rebindValidations({General: 0}, index, returnedData.Errors);
                    }
                });
            };

            index.raiseClose = function () {
                index.deleteModal.modal('hide');
            };

            hub.handleRenamedThespianEventMessage = function(id, newFirstName, newLastName) {
                if (index.Id() != id)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;

                if (index.FirstName() != newFirstName)
                    index.FirstName(newFirstName);

                if (index.LastName() != newLastName)
                    index.LastName(newLastName);

                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleDeletedThespianEventMessage = function(id) {
                if (index.Id() != id)
                    return;

                jQuery(document).trigger('publishNotAllowedNotification', ['Thespian No Longer Available.', 'This thespian has been removed by another user. The window will automatically close.']);
                index.deleteModal.modal('hide');
                index.Id(null);
            };

            jQuery(document).bind('thespianDelete', function (event, id) {

                jQuery.getJSON('" + @Url.Action("Get", "ThespianManagement") + @"', { id: id }, function (data) {

                    index.Id(data.Thespian.Id);
                    index.FirstName(data.Thespian.FirstName);
                    index.LastName(data.Thespian.LastName);

                    index.deleteModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#delete-thespian-container')[0]);
                index.deleteModal = jQuery('#delete-thespian-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (actor_delete));");
    }
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
