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

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.Views.TeamManagement
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
    using ThreeBytes.ProjectHollywood.Team.Management.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TeamManagement/Create.cshtml")]
    public class Create : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.Team.Management.Entities.TeamManagementEmployee>
    {
        public Create()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\TeamManagement\Create.cshtml"
 if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "TeamManager" }))
{

            
            #line default
            #line hidden
WriteLiteral(@"    <div id=""create-team-employee-container"">
        <div id=""create-team-employee-modal"" class=""modal modal-medium-wide hide fade"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
                <h3>");


            
            #line 9 "..\..\Views\TeamManagement\Create.cshtml"
               Write(Resources.CreateTeamEmployee);

            
            #line default
            #line hidden
WriteLiteral(@"</h3>
            </div>
            <div class=""modal-body modal-body-scrollable"">
                <div data-bind=""error: GeneralErrors""></div>
                <form id=""create-team-employee-form"">
                    <fieldset>
                        <div class=""row"">
                            <div class=""span3 columns"">
                                <div class=""clearfix""> 
                                    ");


            
            #line 18 "..\..\Views\TeamManagement\Create.cshtml"
                               Write(Html.LabelFor(model => model.FirstName, Resources.FirstName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        \r\n                                    <div class=\"input input-small-mar" +
"gin\">\r\n                                        ");


            
            #line 21 "..\..\Views\TeamManagement\Create.cshtml"
                                   Write(Html.TextBoxFor(model => model.FirstName, new { @data_val = "true", @data_val_required = "'First Name' should not be empty.", @data_val_length = "'First Name' must be a string with a maximum length of 35.", @data_val_length_max = "35", @data_bind = "value: FirstName" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                                        <div data-valmsg-for=""FirstName"" data-valmsg-replace=""true"" data-bind=""error: FirstNameErrors""></div>
                                    </div>
                                </div>

                                <div class=""clearfix""> 
                                    ");


            
            #line 27 "..\..\Views\TeamManagement\Create.cshtml"
                               Write(Html.LabelFor(model => model.LastName, Resources.LastName));

            
            #line default
            #line hidden
WriteLiteral("\r\n        \r\n                                    <div class=\"input input-small-mar" +
"gin\">\r\n                                        ");


            
            #line 30 "..\..\Views\TeamManagement\Create.cshtml"
                                   Write(Html.TextBoxFor(model => model.LastName, new { @data_val = "true", @data_val_required = "'Last Name' should not be empty.", @data_val_length = "'Last Name' must be a string with a maximum length of 35.", @data_val_length_max = "35", @data_bind = "value: LastName" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                                        <div data-valmsg-for=""LastName"" data-valmsg-replace=""true"" data-bind=""error: LastNameErrors""></div>
                                    </div>
                                </div>

                                <div class=""clearfix""> 
                                    ");


            
            #line 36 "..\..\Views\TeamManagement\Create.cshtml"
                               Write(Html.LabelFor(model => model.LastName, Resources.JobTitle));

            
            #line default
            #line hidden
WriteLiteral("\r\n        \r\n                                    <div class=\"input input-small-mar" +
"gin\">\r\n                                        ");


            
            #line 39 "..\..\Views\TeamManagement\Create.cshtml"
                                   Write(Html.TextBoxFor(model => model.JobTitle, new { @data_val = "true", @data_val_required = "'Job Title' should not be empty.", @data_val_length = "'Job Title' must be a string with a maximum length of 50.", @data_val_length_max = "50", @data_bind = "value: JobTitle" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        <div data-valmsg-for=\"JobTitle\" data-va" +
"lmsg-replace=\"true\" data-bind=\"error: JobTitleErrors\"></div>\r\n                  " +
"                  </div>\r\n                                </div>\r\n              " +
"                  \r\n                                <div class=\"clearfix image\">" +
"\r\n                                    <label for=\"team-profile-image\">Profile Im" +
"age <input type=\"file\" id=\"team-profile-image\" name=\"team-profile-image\" /></lab" +
"el>\r\n                                    <div data-bind=\"error: ProfileImageLoca" +
"tionErrors\"></div>\r\n                                    <span class=\"label label" +
"-success\" data-bind=\"visible: HasImageBeenUploaded\">Upload Success</span>\r\n\r\n   " +
"                                 <div data-valmsg-for=\"ProfileImageLocation\" dat" +
"a-valmsg-replace=\"true\" data-bind=\"error: ProfileImageLocationErrors\"></div>\r\n  " +
"                                  <input type=\"hidden\" id=\"ProfileImageLocation\"" +
" name=\"ProfileImageLocation\" data-bind = \"value: ProfileImageLocation\" />\r\n     " +
"                               <input type=\"hidden\" id=\"ProfileThumbnailImageLoc" +
"ation\" name=\"ProfileThumbnailImageLocation\" data-bind = \"value: ProfileThumbnail" +
"ImageLocation\" />\r\n                                </div>\r\n                     " +
"       </div>\r\n                            <div class=\"span3 columns\">\r\n        " +
"                        <div id=\"team-profile-image-container\">\r\n               " +
"                     <ul class=\"thumbnails\">\r\n                                  " +
"      <li class=\"span3\">\r\n                                            <div class" +
"=\"thumbnail\">\r\n                                                <img data-bind=\"a" +
"ttr: { src: ProfileImageUrl() }\" />\r\n                                           " +
"     <div class=\"caption\"></div>\r\n                                            </" +
"div>\r\n                                        </li>\r\n                           " +
"         </ul>\r\n                                </div>\r\n                        " +
"    </div>\r\n                        </div>\r\n                        <div>\r\n     " +
"                       <div class=\"columns\">\r\n                                <d" +
"iv class=\"clearfix\">\r\n                                    ");


            
            #line 70 "..\..\Views\TeamManagement\Create.cshtml"
                               Write(Html.LabelFor(model => model.Summary, Resources.Summary));

            
            #line default
            #line hidden
WriteLiteral("\r\n        \r\n                                    <div class=\"input input-small-mar" +
"gin\">\r\n                                        ");


            
            #line 73 "..\..\Views\TeamManagement\Create.cshtml"
                                   Write(Html.TextAreaFor(model => model.Summary, new { @data_val = "true", @data_val_required = "'Summary' should not be empty.", @data_bind = "value: Summary" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                                        <div data-valmsg-for=""Summary"" data-valmsg-replace=""true"" data-bind=""error: SummaryErrors""></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class=""modal-footer"">
                <button type=""submit"" class=""btn btn-primary"" data-bind=""click: save"">");


            
            #line 83 "..\..\Views\TeamManagement\Create.cshtml"
                                                                                 Write(Resources.SaveChanges);

            
            #line default
            #line hidden
WriteLiteral("</button>&nbsp;\r\n                <button type=\"submit\" class=\"btn btn-danger\" dat" +
"a-bind=\"click: raiseClose\">");


            
            #line 84 "..\..\Views\TeamManagement\Create.cshtml"
                                                                                      Write(Resources.Cancel);

            
            #line default
            #line hidden
WriteLiteral("</button>&nbsp;\r\n            </div>\r\n        </div>\r\n    </div>\r\n");


            
            #line 88 "..\..\Views\TeamManagement\Create.cshtml"

    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"
        var team_employee_create = {};

        (function (index) {

            team_employee_create = index;

            var val = ko.setupValidation([], []);
            val.createErrorCollections({FirstName: 0, LastName: 0, JobTitle: 0, ProfileImageLocation: 0, Summary: 0, General: 0}, index, 'create-team-employee-form');

            index.FirstName = ko.observable();
            index.LastName = ko.observable();
            index.JobTitle = ko.observable();
            index.ProfileImageLocation = ko.observable();
            index.ProfileThumbnailImageLocation = ko.observable();
            index.Summary = ko.observable();

            index.HasImageBeenUploaded = ko.observable(false);

            index.ProfileImageUrl = ko.computed(function() {
                return index.HasImageBeenUploaded() ? '" + @Url.Action("GetProfileImage", "Team") + @"' + '/' + index.ProfileThumbnailImageLocation() : '" + @Url.Content("img/placeholder260x180.gif") + @"';
            });

            index.toJS = function() {
                return { 
                    FirstName: index.FirstName() == null ? '' : index.FirstName(), 
                    LastName: index.LastName() == null ? '' : index.LastName(),
                    JobTitle: index.JobTitle() == null ? '' : index.JobTitle(),  
                    ProfileImageLocation: index.ProfileImageLocation() == null ? '' : index.ProfileImageLocation(),  
                    ProfileThumbnailImageLocation: index.ProfileThumbnailImageLocation() == null ? '' : index.ProfileThumbnailImageLocation(),  
                    Summary: index.Summary() == null ? '' : index.Summary()
                }
            };

            jQuery(document).bind('teamEmployeeCreate', function() {
                index.clear();
                index.createModal.modal('show');
            });

            index.raiseClose = function () {
                index.createModal.modal('hide');
            };

            index.save = function (form) {
                if(!jQuery('#create-team-employee-form').valid())
                    return;

                jQuery.post('" + @Url.Action("Create", "Team") + @"', index.toJS(), function (dataReturned) {
                    if (dataReturned.IsValid) {
                        jQuery(document).trigger('teamEmployeeCreated');
                        jQuery(document).trigger('publishProcessingNotification', ['Processing team member creation.', 'We are currently processing your request to create ' + index.FirstName() + ' ' + index.LastName() + '.']);
                        index.createModal.modal('hide');
                    }
                    else {
                        val.rebindValidations({FirstName: 0, LastName: 0, JobTitle: 0, ProfileImageLocation: 0, Summary: 0, General: 0}, index, dataReturned.Errors);
                    }
                });
            };

            index.clear = function() {
                index.FirstName(null);
                index.LastName(null);
                index.ProfileImageLocation(null);
                index.ProfileThumbnailImageLocation(null);
                index.JobTitle(null);
                index.Summary(null);

                index.HasImageBeenUploaded(false);

                val.clearValidations({FirstName: 0, LastName: 0, JobTitle: 0, ProfileImageLocation: 0, Summary: 0, General: 0}, index);
            };

            jQuery(function () {
                jQuery('#team-profile-image').makeAsyncUploader({
                    upload_url: '" + @Url.Action("ImageUpload", "Home") + @"',
                    flash_url: '" + @Url.Content("~/js/libs/swfupload.swf") + @"',
                    button_image_url: '" + @Url.Content("~/img/blankButton.png") + @"',
	                file_types : '*.jpg;*.jpeg;*.png;*.bmp;*.gif',
                    upload_success_handler: function(file, data, response) {
                        var item = jQuery.parseJSON(data);                        

                        if (item.Result.IsValid) {
                            index.ProfileImageLocation(item.Filename);
                            index.ProfileThumbnailImageLocation(item.ThumbnailName);
                            index.HasImageBeenUploaded(true);
                        }
                        else {
                            val.rebindValidations({
                                ProfileImageLocation: 0,
                                General: 0
                            }, index, item.Result.Errors);
                        }
                    }
                });

                ko.applyBindings(index, jQuery('#create-team-employee-container')[0]);
                index.createModal = jQuery('#create-team-employee-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });

        } (team_employee_create));");
    }
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
