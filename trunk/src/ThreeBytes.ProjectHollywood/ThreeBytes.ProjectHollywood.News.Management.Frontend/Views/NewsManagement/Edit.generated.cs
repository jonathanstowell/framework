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

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Views.NewsManagement
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
    using ThreeBytes.ProjectHollywood.News.Management.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/NewsManagement/Edit.cshtml")]
    public class Edit : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.News.Management.Entities.NewsManagementNewsArticle>
    {
        public Edit()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\NewsManagement\Edit.cshtml"
 if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
{

            
            #line default
            #line hidden
WriteLiteral(@"    <div id=""edit-news-article-container"">
        <div id=""edit-news-article-modal"" class=""modal modal-medium-wide hide fade"">
            <div class=""modal-header"">
                <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
                <h3>");


            
            #line 9 "..\..\Views\NewsManagement\Edit.cshtml"
               Write(Resources.Edit);

            
            #line default
            #line hidden
WriteLiteral(" <span data-bind=\"fadeInText: Title\"></span> ");


            
            #line 9 "..\..\Views\NewsManagement\Edit.cshtml"
                                                                           Write(Resources.NewsArticle);

            
            #line default
            #line hidden
WriteLiteral(@"</h3>
            </div>
            <div id=""edit-news-article-forms-container"" class=""modal-body modal-body-scrollable"">
                <div data-bind=""error: GeneralErrors""></div>
                <form id=""rename-newsarticle-form"">
                    <fieldset>
                        <div class=""clearfix"">
                            ");


            
            #line 16 "..\..\Views\NewsManagement\Edit.cshtml"
                       Write(Html.LabelFor(model => model.Title, Resources.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <div class=\"input input-small-margin\">\r\n           " +
"                     ");


            
            #line 18 "..\..\Views\NewsManagement\Edit.cshtml"
                           Write(Html.TextBoxFor(model => model.Title, new { @data_val = "true", @data_val_required = "'Title' should not be empty.", @data_val_length = "'Title' must be a string with a maximum length of 100.", @data_val_length_max = "100", @data_bind = "value: Title" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <button type=\"submit\" class=\"btn btn-primary\" d" +
"ata-bind=\"click: saveTitle\">");


            
            #line 19 "..\..\Views\NewsManagement\Edit.cshtml"
                                                                                                      Write(Resources.Rename);

            
            #line default
            #line hidden
WriteLiteral(@"</button> 
                                <div data-valmsg-for=""Title"" data-valmsg-replace=""true"" data-bind=""error: TitleErrors""></div>
                            </div>
                        </div>
                    </fieldset>
                </form>
                <form id=""update-content-newsarticle-form"">
                    <fieldset>
                        <div class=""clearfix"">
                            ");


            
            #line 28 "..\..\Views\NewsManagement\Edit.cshtml"
                       Write(Html.LabelFor(model => model.Content, Resources.Content));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <div class=\"input input-small-margin\">\r\n           " +
"                     ");


            
            #line 30 "..\..\Views\NewsManagement\Edit.cshtml"
                           Write(Html.TextAreaFor(model => model.Content, new { @data_val = "true", @data_val_required = "'Content' should not be empty.", @data_bind = "value: Content" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <button type=\"submit\" class=\"btn btn-primary\" d" +
"ata-bind=\"click: saveContent\">");


            
            #line 31 "..\..\Views\NewsManagement\Edit.cshtml"
                                                                                                        Write(Resources.Update);

            
            #line default
            #line hidden
WriteLiteral(@"</button>
                                <div data-valmsg-for=""Content"" data-valmsg-replace=""true"" data-bind=""error: ContentErrors""></div>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class=""modal-footer"">
                <div data-bind=""currentlyViewingComponent: currentViewersViewModel""></div>
                <button class=""btn btn-info"" data-bind=""click: raiseDetails"">Details</button>
                <button class=""btn btn-danger"" data-bind=""click: raiseDelete"">Delete</button>
                <button class=""btn btn-danger"" data-bind=""click: raiseClose"">Close</button>
            </div>
        </div>
    </div>
");


            
            #line 46 "..\..\Views\NewsManagement\Edit.cshtml"

    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"
        var news_article_edit = {};

        (function (index) {

            news_article_edit = index;

            var hub = jQuery.connection.newsManagementHub;

            var val = ko.setupValidation([], []);
            val.createErrorCollections({Title: 0, Content: 0, General: 0}, index, 'edit-news-article-forms-container');

            index.Id = ko.observable();
            index.Title = ko.observable();
            index.Content = ko.observable();

            var originalTitle;
            var originalContent;

            index.currentViewersViewModel = new ko.currentlyViewingComponent.viewModel({
                hub: hub,
                id: index.Id,
                modalSelector: '#edit-news-article-modal'
            });

            index.saveTitle = function (form) {
                if(!jQuery('#rename-newsarticle-form').valid())
                    return;

                jQuery.post('" + @Url.Action("RenameTitle", "News") + @"', {
                    'id': index.Id(),
                    'title': index.Title()
                }, function (dataReturned) {
                    if (dataReturned.IsValid) {
                        jQuery(document).trigger('newsArticleUpdated', [index]);
                        jQuery(document).trigger('publishProcessingNotification', ['Processing news article title change.', 'We are currently processing your request to rename the news article from ' + originalTitle + ' to ' + index.Title() + '.']);
                    }
                    else {
                        val.rebindValidations({Title: 0, Content: 0, General: 0}, index, dataReturned.Errors);
                    }
                });
            };

            index.saveContent = function (form) {
                if(!jQuery('#update-content-newsarticle-form').valid())
                    return;

                jQuery.post('" + @Url.Action("UpdateContent", "News") + @"', {
                    'id': index.Id(),
                    'content': index.Content()
                }, function (dataReturned) {
                    if (dataReturned.IsValid) {
                        jQuery(document).trigger('newsArticleUpdated', [index]);
                        jQuery(document).trigger('publishProcessingNotification', ['Processing news article content change.', 'We are currently processing your request to update the content of the news article ' + originalTitle + '.']);
                    }
                    else {
                        val.rebindValidations({Title: 0, Content: 0, General: 0}, index, dataReturned.Errors);
                    }
                });
            };

            index.raiseDelete = function (obj) {
                index.editModal.modal('hide');
                jQuery(document).trigger('newsArticleDelete', [obj.ItemId()]);
            };

            index.raiseClose = function () {
                index.editModal.modal('hide');
            };

            index.raiseDetails = function () {
                jQuery(document).trigger('newsArticleDetails', [index]);
                index.editModal.modal('hide');
            }

            hub.handleRenamedNewsArticleTitleEventMessage = function(id, newTitle) {
                if (index.Id() != id)
                    return;

                if (index.Title() == newTitle)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;
                index.Title(newTitle);
                ko.bindingHandlers.fadeInText.highlight = false;

                originalTitle = index.Title();
            };

            hub.handleUpdatedNewsArticleContentEventMessage = function(id, newContent) {
                if (index.Id() != id)
                    return;

                if (index.Content() == newContent)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;
                index.Content(newContent);
                ko.bindingHandlers.fadeInText.highlight = false;

                originalContent = index.Content();
            };

            hub.handleDeletedNewsArticleEventMessage = function(id) {
                if (index.Id() != id)
                    return;

                jQuery(document).trigger('publishNotAllowedNotification', ['News Article No Longer Available.', 'This news article has been removed by another user. The window will automatically close.']);
                index.editModal.modal('hide');
                index.Id(null);
            };

            jQuery(document).bind('newsArticleEdit', function (event, id) {

                jQuery.getJSON('" + @Url.Action("Get", "NewsManagement") + @"', { id: id }, function (data) {

                    index.Id(data.NewsArticle.Id);
                    index.Title(data.NewsArticle.Title);
                    index.Content(data.NewsArticle.Content);

                    originalTitle = index.Title();
                    originalContent = index.Content();

                    index.currentViewersViewModel.initialiseCurrentViewers(data.CurrentlyViewingUsers);

                    val.clearValidations({Title: 0, Content: 0, General: 0}, index);

                    index.editModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#edit-news-article-container')[0]);
                index.editModal = jQuery('#edit-news-article-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });

        } (news_article_edit));");
    }
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
