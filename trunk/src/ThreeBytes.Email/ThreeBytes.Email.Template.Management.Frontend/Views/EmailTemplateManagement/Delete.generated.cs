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

namespace ThreeBytes.Email.Template.Management.Frontend.Views.EmailTemplateManagement
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
    using ThreeBytes.Email.Template.Management.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailTemplateManagement/Delete.cshtml")]
    public class Delete : System.Web.Mvc.WebViewPage<ThreeBytes.Email.Template.Management.Entities.EmailTemplateManagementTemplate>
    {
        public Delete()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\EmailTemplateManagement\Delete.cshtml"
  
    ViewBag.Title = Resources.BrowserTitleDelete;


            
            #line default
            #line hidden
WriteLiteral(@"
<div id=""delete-template-container"">
    <div id=""email-template-delete-modal"" class=""modal hide fade"">
        <div class=""modal-header"">
            <a href=""#"" class=""close"" data-bind=""click: function() { email_template_delete.raiseClose() }"">×</a>
            <h3>");


            
            #line 11 "..\..\Views\EmailTemplateManagement\Delete.cshtml"
           Write(Resources.Delete);

            
            #line default
            #line hidden
WriteLiteral(" <span data-bind=\"text:Name\"></span> ");


            
            #line 11 "..\..\Views\EmailTemplateManagement\Delete.cshtml"
                                                                 Write(Resources.Template);

            
            #line default
            #line hidden
WriteLiteral(@"</h3>
        </div>
        <div id=""delete-template-form-container"" class=""modal-body"">
            <div data-bind=""error: GeneralErrors""></div>
            <p>Are you sure you wish to delete the <span data-bind=""text: Name""></span> template?</p>
        </div>
        <div class=""modal-footer"">
            <button type=""submit"" class=""btn btn-primary"" data-bind=""click: deleteTemplate"">");


            
            #line 18 "..\..\Views\EmailTemplateManagement\Delete.cshtml"
                                                                                       Write(Resources.ConfirmDelete);

            
            #line default
            #line hidden
WriteLiteral("</button>&nbsp;\r\n            <button type=\"submit\" class=\"btn btn-danger\" data-bi" +
"nd=\"click: function() { email_template_delete.raiseClose() }\">");


            
            #line 19 "..\..\Views\EmailTemplateManagement\Delete.cshtml"
                                                                                                                         Write(Resources.Cancel);

            
            #line default
            #line hidden
WriteLiteral("</button>&nbsp;\r\n            <button class=\"btn btn-danger\" data-bind=\"click: rai" +
"seClose\">Close</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");


            
            #line 25 "..\..\Views\EmailTemplateManagement\Delete.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var email_template_delete = {};

        (function (index) {

            email_template_delete = index;

            var val = ko.setupValidation([], []);
            val.createErrorCollections({Name: 0, General: 0}, index, 'delete-template-form-container');

            index.Id = ko.observable();
            index.Name = ko.observable();

            index.deleteTemplate = function () {
                jQuery.post('" + @Url.Action("Delete", "Template") + @"', { id: index.Id() }, function (dataReturned) {
                    if (dataReturned.IsValid) {
                        jQuery(document).trigger('emailTemplateDeleted', [dataReturned.Id]);
                        index.deleteModal.modal('hide');
                    }
                    else {
                        val.rebindValidations({Name: 0, General: 0}, index, dataReturned.Errors);
                    }
                });
            };

            index.raiseClose = function () {
                index.deleteModal.modal('hide');
            };

            jQuery(document).bind('emailTemplateDelete', function (event, id) {

                jQuery.getJSON('" + @Url.Action("Get", "TemplateManagement") + @"', { id: id }, function (data) {

                    index.Id(data.Id);
                    index.Name(data.Name);

                    index.deleteModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#delete-template-container')[0]);
                index.deleteModal = jQuery('#email-template-delete-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });
        } (email_template_delete));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591