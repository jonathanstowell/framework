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

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.Views.TeamView
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
    using ThreeBytes.Core.Security.Concrete;
    using ThreeBytes.ProjectHollywood.Team.View.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TeamView/Details.cshtml")]
    public class Details : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.Team.View.Entities.TeamViewEmployee>
    {
        public Details()
        {
        }
        public override void Execute()
        {

WriteLiteral(@"
<div id=""team-employee-details-container"">
    <div id=""team-employee-details-modal"" class=""modal modal-medium-wide hide fade"">
        <div class=""modal-header"">
            <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
            <h3>
                <span data-bind=""fadeInText:FirstName""></span> <span data-bind=""fadeInText: LastName""></span>
            </h3>
        </div>
        <div class=""modal-body"">
            <div class=""row"">
                <div class=""span3"">
                    <ul class=""thumbnails"">
                        <li class=""span3"">
                            <div class=""thumbnail"">
                                <img data-bind=""attr: { src: ProfileImageUrl() }"" />
                            </div>
                        </li>
                    </ul>
                </div>
                <div class=""span3"">
                    <fieldset>
                        <div class=""display-label"">");


            
            #line 24 "..\..\Views\TeamView\Details.cshtml"
                                              Write(Resources.JobTitle);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div class=\"display-field\"><span data-bind=\"fadeI" +
"nText:JobTitle\"></span></div>\r\n\r\n                        <div class=\"display-lab" +
"el\">");


            
            #line 27 "..\..\Views\TeamView\Details.cshtml"
                                              Write(Resources.Summary);

            
            #line default
            #line hidden
WriteLiteral(@"</div>
                        <div class=""display-field""><span data-bind=""fadeInText:Summary""></span></div>
                    </fieldset>
                </div>
            </div>
            <div id=""team-employee-history-container"" class=""row"" data-bind=""visible: History().length > 0"">
                <div class=""span5"">
                    <h2>");


            
            #line 34 "..\..\Views\TeamView\Details.cshtml"
                   Write(Resources.History);

            
            #line default
            #line hidden
WriteLiteral(@"</h2>
                    <table class=""table table-striped table-bordered table-condensed scrollable"">
                        <thead>
                            <tr>
                                <th>Date Time</th>
                                <th>");


            
            #line 39 "..\..\Views\TeamView\Details.cshtml"
                               Write(Resources.Operation);

            
            #line default
            #line hidden
WriteLiteral(@"</th>
                            </tr>
                        </thead>
                        <tbody id=""team-employee-history-tbody"" data-bind=""foreach: History"">
                            <tr>        
                                <td data-bind=""text: GetDate(LastModifiedDateTime)""></td>
                                <td data-bind=""text: Operation""></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""modal-footer"">
");


            
            #line 53 "..\..\Views\TeamView\Details.cshtml"
             if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "TeamManager" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <button class=\"btn btn-primary\" data-bind=\"click: raiseEdit\">");


            
            #line 55 "..\..\Views\TeamView\Details.cshtml"
                                                                        Write(Resources.Edit);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");



WriteLiteral("                <button class=\"btn btn-danger\" data-bind=\"click: raiseDelete\">");


            
            #line 56 "..\..\Views\TeamView\Details.cshtml"
                                                                         Write(Resources.Delete);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");


            
            #line 57 "..\..\Views\TeamView\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <button class=\"btn btn-danger\" data-bind=\"click: raiseClose\">Close</b" +
"utton>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");


            
            #line 63 "..\..\Views\TeamView\Details.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var team_employee_details = {};

        (function (index) {

            var hub = jQuery.connection.teamViewHub;

            team_employee_details = index;

            index.Id = ko.observable();
            index.ItemId = ko.observable();
            index.FirstName = ko.observable();
            index.LastName = ko.observable();
            index.JobTitle = ko.observable();
            index.ProfileImageLocation = ko.observable();
            index.ProfileThumbnailImageLocation = ko.observable();
            index.Summary = ko.observable();
            index.History = ko.observableArray();

            index.ProfileImageUrl = ko.computed(function() {
                if(index.ProfileThumbnailImageLocation() != '' && index.ProfileThumbnailImageLocation() != null && index.ProfileThumbnailImageLocation() != typeof('undefined'))
                    return '" + @Url.Action("GetProfileImage", "Team") + @"' + '/' + index.ProfileThumbnailImageLocation();

                return '" + @Url.Content("img/placeholder260x180.gif") + @"';
            });

            index.raiseClose = function () {
                index.detailModal.modal('hide');
            };

            index.raiseEdit = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('teamEmployeeEdit', [obj.ItemId()]);
            };

            index.raiseDelete = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('teamEmployeeDelete', [obj.ItemId()]);
            };

            hub.handleRenamedTeamEmployeeEventMessage = function(id, newFirstName, newLastName) {
                if (index.ItemId() != id)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;

                if (index.FirstName() != newFirstName)
                    index.FirstName(newFirstName);

                if (index.LastName() != newLastName)
                    index.LastName(newLastName);

                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleRenamedTeamEmployeeJobTitleEventMessage = function(id, newJobTitle) {
                if (index.ItemId() != id)
                    return;

                if (index.JobTitle() == newJobTitle)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;
                index.JobTitle(newJobTitle);
                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleUpdatedTeamEmployeeSummaryEventMessage = function(id, newSummary) {
                if (index.ItemId() != id)
                    return;

                if (index.Summary() == newSummary)
                    return;
                    
                ko.bindingHandlers.fadeInText.highlight = true;
                index.Summary(newSummary);
                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleTeamProfileImageUpdatedEventMessage = function(id, newProfileImageLocation, newProfileThumbnailImageLocation) {
                if (index.ItemId() != id)
                    return;

                if (index.ProfileImageLocation() != newProfileImageLocation)
                    index.ProfileImageLocation(newProfileImageLocation);

                if (index.ProfileThumbnailImageLocation() != newProfileThumbnailImageLocation)
                    index.ProfileThumbnailImageLocation(newProfileThumbnailImageLocation);
            };


            hub.handleDeletedTeamEmployeeEventMessage = function(id) {
                if (index.ItemId() != id)
                    return;

                jQuery(document).trigger('publishNotAllowedNotification', ['Employee No Longer Available.', 'This employee has been removed by another user. The window will automatically close.']);
                index.detailModal.modal('hide');
                index.Id(null);
            };

            jQuery(document).bind('teamEmployeeDetails', function (event, employee) {

                jQuery.getJSON('/Team/GetDetails/' + employee.Id(), function (data) {

                    index.Id(data.Id);
                    index.ItemId(data.ItemId);
                    index.FirstName(data.FirstName);
                    index.LastName(data.LastName);
                    index.JobTitle(data.JobTitle);
                    index.ProfileImageLocation(data.ProfileImageLocation);
                    index.ProfileThumbnailImageLocation(data.ProfileThumbnailImageLocation);
                    index.Summary(data.Summary);
                    index.History(data.History);

                    index.detailModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#team-employee-details-container')[0]);
                index.detailModal = jQuery('#team-employee-details-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (team_employee_details));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
