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

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.Views.NewsView
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
    using ThreeBytes.ProjectHollywood.News.View.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/NewsView/Details.cshtml")]
    public class Details : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.News.View.Entities.NewsViewNewsArticle>
    {
        public Details()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\NewsView\Details.cshtml"
  
    ViewBag.Title = "";


            
            #line default
            #line hidden
WriteLiteral(@"
<div id=""details-news-article-container"">
    <div id=""news-article-details-modal"" class=""modal modal-medium-wide hide fade"">
        <div class=""modal-header"">
            <a href=""#"" class=""close"" data-bind=""click: raiseClose"">×</a>
            <h3>
                <span data-bind=""fadeInText:Title""></span> <span class=""pull-right"" data-bind=""fadeInText: GetDate(CreationDateTime())""></span>
            </h3>
        </div>
        <div class=""modal-body modal-body-scrollable"">
            <div class=""row"">
                <div class=""span12"">
                    <fieldset>
                        <div class=""display-field""><span data-bind=""fadeInText:Content""></span></div>
                    </fieldset>
                </div>
            </div>
");


            
            #line 23 "..\..\Views\NewsView\Details.cshtml"
             if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div id=\"news-article-history-container\" class=\"row\" data-bind=\"v" +
"isible: History().length > 0\">\r\n                    <div class=\"span6 well-large" +
"\">\r\n                        <h2>");


            
            #line 27 "..\..\Views\NewsView\Details.cshtml"
                       Write(Resources.History);

            
            #line default
            #line hidden
WriteLiteral(@"</h2>
                        <table class=""table table-striped table-bordered table-condensed scrollable"">
                            <thead>
                                <tr>
                                    <th>Date Time</th>
                                    <th>");


            
            #line 32 "..\..\Views\NewsView\Details.cshtml"
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


            
            #line 44 "..\..\Views\NewsView\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div class=\"modal-footer\">\r\n");


            
            #line 47 "..\..\Views\NewsView\Details.cshtml"
             if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <button class=\"btn btn-primary\" data-bind=\"click: raiseEdit\">");


            
            #line 49 "..\..\Views\NewsView\Details.cshtml"
                                                                        Write(Resources.Edit);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");



WriteLiteral("                <button class=\"btn btn-danger\" data-bind=\"click: raiseDelete\">");


            
            #line 50 "..\..\Views\NewsView\Details.cshtml"
                                                                         Write(Resources.Delete);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");


            
            #line 51 "..\..\Views\NewsView\Details.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("            <button class=\"btn btn-danger\" data-bind=\"click: raiseClose\">Close</b" +
"utton>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");


            
            #line 57 "..\..\Views\NewsView\Details.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        var news_article_details = {};

        (function (index) {

            news_article_details = index;

            var hub = jQuery.connection.newsViewHub;

            index.Id = ko.observable();
            index.ItemId = ko.observable();
            index.CreatedBy = ko.observable();
            index.CreationDateTime = ko.observable();
            index.Title = ko.observable();
            index.Content = ko.observable();
            index.History = ko.observableArray();

            index.raiseClose = function () {
                index.detailModal.modal('hide');
            };

            index.raiseEdit = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('newsArticleEdit', [obj.ItemId()]);
            };

            index.raiseDelete = function (obj) {
                index.detailModal.modal('hide');
                jQuery(document).trigger('newsArticleDelete', [obj.ItemId()]);
            };

            hub.handleRenamedNewsArticleTitleEventMessage = function(id, newTitle) {
                if (index.Id() != id)
                    return;

                if (index.Title() == newTitle)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;
                index.Title(newTitle);
                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleUpdatedNewsArticleContentEventMessage = function(id, newContent) {
                if (index.Id() != id)
                    return;

                if (index.Content() == newContent)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;
                index.Content(newContent);
                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleDeletedNewsArticleEventMessage = function(id) {
                if (index.ItemId() != id)
                    return;

                jQuery(document).trigger('publishNotAllowedNotification', ['News Article No Longer Available.', 'This news article has been removed by another user. The window will automatically close.']);
                index.detailModal.modal('hide');
                index.Id(null);
            };

            jQuery(document).bind('newsArticleDetails', function (event, newsArticle) {

                jQuery.getJSON('/News/GetDetails/' + newsArticle.Id(), function (data) {

                    index.Id(data.Id);
                    index.ItemId(data.ItemId);
                    index.CreatedBy(data.CreatedBy);
                    index.CreationDateTime(data.CreationDateTime);
                    index.Title(data.Title);
                    index.Content(data.Content);
                    index.History(data.History);

                    index.detailModal.modal('show');
                });
            });

            jQuery(function () {
                ko.applyBindings(index, jQuery('#details-news-article-container')[0]);
                index.detailModal = jQuery('#news-article-details-modal').modal({ backdrop: true, closeOnEscape: true, modal: true, show: false });
            });

        } (news_article_details));");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591