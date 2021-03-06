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

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Views.ThespianView
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
    using ThreeBytes.ProjectHollywood.Thespian.View.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ThespianView/Details.cshtml")]
    public class Details : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Models.ThespianDetailsViewModel>
    {
        public Details()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\ThespianView\Details.cshtml"
  
    ViewBag.Title = "";


            
            #line default
            #line hidden
WriteLiteral(@"
<div id=""thespian-details-container"">
    <div id=""thespian-details-modal"" class=""modal modal-medium-wide hide fade"">
        <div class=""modal-header"">
            <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
            <h3>
                <span data-bind=""fadeInText:FirstName""></span> <span data-bind=""fadeInText:LastName""></span> ");


            
            #line 12 "..\..\Views\ThespianView\Details.cshtml"
                                                                                                        Write(Resources.Details);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </h3>\r\n        </div>\r\n        <div class=\"modal-body modal-body-sc" +
"rollable\">\r\n            <div class=\"row\">\r\n                <div class=\"span3\">\r\n" +
"                    <ul class=\"thumbnails\">\r\n                        <li class=\"" +
"span3\">\r\n                            <div class=\"thumbnail\">\r\n                  " +
"              <img data-bind=\"attr: { src: ProfileImageUrl() }\" />\r\n            " +
"                </div>\r\n                        </li>\r\n                    </ul>" +
"\r\n                    <fieldset>\r\n                        <div class=\"display-la" +
"bel\">Summary</div>\r\n                        <div class=\"display-field\"><span dat" +
"a-bind=\"fadeInText:Summary\"></span></div>\r\n\r\n                        <div class=" +
"\"display-label\">Twitter</div>\r\n                        <div class=\"display-field" +
"\"><span data-bind=\"fadeInText:Twitter\"></span></div>\r\n\r\n                        " +
"<div class=\"display-label\">Facebook</div>\r\n                        <div class=\"d" +
"isplay-field\"><span data-bind=\"fadeInText:Facebook\"></span></div>\r\n\r\n           " +
"             <div class=\"display-label\">Spotlight</div>\r\n                       " +
" <div class=\"display-field\"><span data-bind=\"fadeInText:Spotlight\"></span></div>" +
"\r\n\r\n                        <div class=\"display-label\">Imdb</div>\r\n             " +
"           <div class=\"display-field\"><span data-bind=\"fadeInText:Imdb\"></span><" +
"/div>\r\n                    </fieldset>\r\n                </div>\r\n                " +
"<div class=\"span3\">\r\n                    <fieldset>\r\n                        <di" +
"v class=\"display-label\">");


            
            #line 44 "..\..\Views\ThespianView\Details.cshtml"
                                              Write(Resources.FirstName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div class=\"display-field\"><span data-bind=\"fadeI" +
"nText:FirstName\"></span></div>\r\n\r\n                        <div class=\"display-la" +
"bel\">");


            
            #line 47 "..\..\Views\ThespianView\Details.cshtml"
                                              Write(Resources.LastName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div class=\"display-field\"><span data-bind=\"fadeI" +
"nText:LastName\"></span></div>\r\n\r\n                        <div class=\"display-lab" +
"el\">Date Of Birth</div>\r\n                        <div class=\"display-field\"><spa" +
"n data-bind=\"fadeInText: GetDate(DateOfBirth())\"></span></div>\r\n\r\n              " +
"          <div class=\"display-label\">Gender</div>\r\n                        <div " +
"class=\"display-field\"><span data-bind=\"fadeInText:Gender\"></span></div>\r\n\r\n     " +
"                   <div class=\"display-label\">Location</div>\r\n                  " +
"      <div class=\"display-field\"><span data-bind=\"fadeInText:Location\"></span></" +
"div>\r\n\r\n                        <div class=\"display-label\">Height</div>\r\n       " +
"                 <div class=\"display-field\"><span data-bind=\"fadeInText:Height\">" +
"</span></div>\r\n\r\n                        <div class=\"display-label\">Weight</div>" +
"\r\n                        <div class=\"display-field\"><span data-bind=\"fadeInText" +
":Weight\"></span></div>\r\n\r\n                        <div class=\"display-label\">Pla" +
"ying Age</div>\r\n                        <div class=\"display-field\"><span data-bi" +
"nd=\"fadeInText:PlayingAge\"></span></div>\r\n\r\n                        <div class=\"" +
"display-label\">Eye Colour</div>\r\n                        <div class=\"display-fie" +
"ld\"><span data-bind=\"fadeInText:EyeColour\"></span></div>\r\n\r\n                    " +
"    <div class=\"display-label\">Hair Length</div>\r\n                        <div c" +
"lass=\"display-field\"><span data-bind=\"fadeInText:HairLength\"></span></div>\r\n    " +
"                </fieldset>\r\n                </div>\r\n            </div>\r\n");


            
            #line 76 "..\..\Views\ThespianView\Details.cshtml"
             if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "ThespianManager" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div class=\"row\"data-bind=\"visible: History().length > 0\">\r\n     " +
"               <div class=\"span6\">\r\n                        <h2>");


            
            #line 80 "..\..\Views\ThespianView\Details.cshtml"
                       Write(Resources.History);

            
            #line default
            #line hidden
WriteLiteral(@"</h2>
                        <table class=""table table-striped table-bordered table-condensed scrollable"">
                            <thead>
                                <tr>
                                    <th>Date Time</th>
                                    <th>");


            
            #line 85 "..\..\Views\ThespianView\Details.cshtml"
                                   Write(Resources.Operation);

            
            #line default
            #line hidden
WriteLiteral(@"</th>
                                </tr>
                            </thead>
                            <tbody id=""role-tbody"" data-bind=""foreach: History"">
                                <tr>        
                                    <td data-bind=""text: GetDate(LastModifiedDateTime)""></td>
                                    <td data-bind=""text: Operation""></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
");


            
            #line 97 "..\..\Views\ThespianView\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div class=\"modal-footer\">\r\n");


            
            #line 100 "..\..\Views\ThespianView\Details.cshtml"
             if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "ThespianManager" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <button class=\"btn btn-primary\" data-bind=\"click: raiseEdit\">");


            
            #line 102 "..\..\Views\ThespianView\Details.cshtml"
                                                                        Write(Resources.Edit);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");



WriteLiteral("                <button class=\"btn btn-danger\" data-bind=\"click: raiseDelete\">");


            
            #line 103 "..\..\Views\ThespianView\Details.cshtml"
                                                                         Write(Resources.Delete);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");


            
            #line 104 "..\..\Views\ThespianView\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <button class=\"btn btn-danger\" data-bind=\"click: raiseClose\">Close</b" +
"utton>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");


            
            #line 110 "..\..\Views\ThespianView\Details.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var thespian_details = {};

        (function (index) {

            var hub = jQuery.connection.thespianViewHub;

            thespian_details = index;

            index.Id = ko.observable();
            index.ItemId = ko.observable();
            index.FirstName = ko.observable();
            index.ProfileImageLocation = ko.observable();
            index.ProfileThumbnailImageLocation = ko.observable();
            index.LastName = ko.observable();
            index.DateOfBirth = ko.observable();
            index.Gender = ko.observable();
            index.Location = ko.observable();
            index.Height = ko.observable();
            index.Weight = ko.observable();
            index.PlayingAge = ko.observable();
            index.EyeColour = ko.observable();
            index.HairLength = ko.observable();
            index.Summary = ko.observable();
            index.Twitter = ko.observable();
            index.Facebook = ko.observable();
            index.Spotlight = ko.observable();
            index.Imdb = ko.observable();
            index.ThespianType = ko.observable();

            index.ProfileImageUrl = ko.computed(function() {
                if(index.ProfileThumbnailImageLocation() != '' && index.ProfileThumbnailImageLocation() != null && index.ProfileThumbnailImageLocation() != typeof('undefined'))
                    return '" + @Url.Action("GetProfileImage", "OurClients") + @"' + '/' + index.ProfileThumbnailImageLocation();

                return '" + @Url.Content("img/placeholder260x180.gif") + @"';
            });

            index.History = ko.observableArray();

            index.raiseClose = function () {
                index.detailModal.modal('hide');
            };

            index.raiseEdit = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('thespianEdit', [obj.ItemId()]);
            };

            index.raiseDelete = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('thespianDelete', [obj.ItemId()]);
            };

            hub.handleRenamedThespianEventMessage = function(id, newFirstName, newLastName) {
                if (index.ItemId() != id)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;

                if (index.FirstName() != newFirstName)
                    index.FirstName(newFirstName);

                if (index.LastName() != newLastName)
                    index.LastName(newLastName);

                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleThespianProfileImageUpdatedEventMessage = function(id, newProfileImageLocation, newProfileThumbnailImageLocation) {
                if (index.ItemId() != id)
                    return;

                if (index.ProfileImageLocation() != newProfileImageLocation)
                    index.ProfileImageLocation(newProfileImageLocation);

                if (index.ProfileThumbnailImageLocation() != newProfileThumbnailImageLocation)
                    index.ProfileThumbnailImageLocation(newProfileThumbnailImageLocation);
            };

            hub.handleDeletedThespianEventMessage = function(id) {
                if (index.ItemId() != id)
                    return;

                jQuery(document).trigger('publishNotAllowedNotification', ['Thespian No Longer Available.', 'This thespian has been removed by another user. The window will automatically close.']);
                index.detailModal.modal('hide');
                index.Id(null);
            };

            jQuery(document).bind('thespianDetails', function (event, thespian) {

                jQuery.getJSON('/OurClients/GetDetails/' + thespian.Id(), function (data) {

                    index.Id(data.Id);
                    index.ItemId(data.ItemId);
                    index.FirstName(data.FirstName);
                    index.LastName(data.LastName);
                    index.ProfileImageLocation(data.ProfileImageLocation);
                    index.ProfileThumbnailImageLocation(data.ProfileThumbnailImageLocation);
                    index.DateOfBirth(data.DateOfBirth);
                    index.Gender(data.Gender);
                    index.Location(data.Location);
                    index.Height(data.Height);
                    index.Weight(data.Weight);
                    index.PlayingAge(data.PlayingAge);
                    index.EyeColour(data.EyeColour);
                    index.HairLength(data.HairLength);
                    index.Summary(data.Summary);
                    index.Twitter(data.Twitter);
                    index.Facebook(data.Facebook);
                    index.Spotlight(data.Spotlight);
                    index.Imdb(data.Imdb);
                    index.ThespianType(data.ThespianType);

                    index.History(data.History);

                    index.detailModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#thespian-details-container')[0]);
                index.detailModal = jQuery('#thespian-details-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (thespian_details));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
