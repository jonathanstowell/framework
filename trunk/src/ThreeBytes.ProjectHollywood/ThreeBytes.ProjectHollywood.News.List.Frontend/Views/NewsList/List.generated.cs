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

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.Views.NewsList
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
    using ThreeBytes.Core.Security.Concrete;
    using ThreeBytes.ProjectHollywood.News.List.Frontend.Models;
    using ThreeBytes.ProjectHollywood.News.List.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/NewsList/List.cshtml")]
    public class List : System.Web.Mvc.WebViewPage<PagedNewsListNewsArticleViewModel>
    {
        public List()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\NewsList\List.cshtml"
  
    ViewBag.Title = @Resources.BrowserTitle;


            
            #line default
            #line hidden
WriteLiteral(@"<div id=""latest-news-articles-container"">
    <div data-bind=""latestItems: latestViewModel"" class=""span9""></div>
</div>
<div id=""paged-news-articles-container"">
    <div data-bind=""pagedGrid: pagedViewModel, pagedGridTemplate: 'paged-news-articles-table-tmpl'""></div>
</div>
<script type=""text/x-jquery-tmpl"" id=""paged-news-articles-table-tmpl"">
    <div id=""paged-news-articles-container"" data-bind=""visible: items().length > 0, foreach: items"">
        <div class=""widget news-article"">
            <div class=""widget-header"">
                <i class=""icon-list-alt""></i>
                <h3 data-bind=""fadeInText: Title""></h3>
                <div class=""pull-right-menu"">
");


            
            #line 18 "..\..\Views\NewsList\List.cshtml"
                     if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
                    {

            
            #line default
            #line hidden
WriteLiteral(@"                        <div class=""btn-group open btn-toolbar"">
                            <button class=""btn btn-primary dropdown-toggle"" data-toggle=""dropdown"">Options <span class=""caret""></span></button>
                            <ul class=""dropdown-menu"">
                                <li><a href=""#"" data-bind=""click: function(event) { $parent.additionalFunctions.raiseDetails($data); }"">More</a></li>
                                <li class=""divider""></li>
                                <li><a href=""#"" data-bind=""click: function(event) { $parent.additionalFunctions.raiseEdit($data); }"">");


            
            #line 25 "..\..\Views\NewsList\List.cshtml"
                                                                                                                                Write(Resources.Edit);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                                <li><a href=\"#\" data-bind=\"click: func" +
"tion(event) { $parent.additionalFunctions.raiseDelete($data); }\">");


            
            #line 26 "..\..\Views\NewsList\List.cshtml"
                                                                                                                                  Write(Resources.Delete);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                            </ul>\r\n                        </div>\r\n");


            
            #line 29 "..\..\Views\NewsList\List.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button class=\"btn btn-primary\" data-bind=\"click: functio" +
"n(event) { $parent.additionalFunctions.raiseDetails($data); }\">More</button>\r\n");


            
            #line 33 "..\..\Views\NewsList\List.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral(@"                </div>
            </div>
            <div class=""widget-content"">
                <div class=""news-item-detail"">
                    <p class=""news-item-preview"" data-bind=""fadeInText: Content""></p>
                </div>
                <div class=""news-item-date"">
                    <span class=""news-item-day""><span data-bind=""fadeInText: CreationDateTime""></span></span>
                    by <span class=""news-item-month""><span data-bind=""fadeInText: CreatedBy""></span></span>
                </div>
            </div>
        </div>
    </div>
</script>
");


            
            #line 48 "..\..\Views\NewsList\List.cshtml"
   
    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"
        var news_articles_latest_list  = {};
    
        (function (index) {

            var itemMapping = {
			    'CreationDateTime': ko.utils.getTimeAgoFromJson(),
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
        
            news_articles_latest_list = index = ko.mapping.fromJS(" + @Html.Raw(new JavaScriptSerializer().Serialize(Model.MostRecentResult)) + @", mapping);

            index.latestViewModel = new ko.latestItems.viewModel({
                controller: 'News/List',
                action: 'GetNewerThan',
                data: index,
                singular: '" + @Resources.NewsArticle + @"',
                plural: '" + @Resources.NewsArticles + @"',
                loadPageCallback: function(data) {
                    ko.mapping.fromJS(data, index);
                },
                divIdentifier: 'latest-news-articles-container',
                pagingComponentIdentifier: 'paged-news-articles',
                columns: [
                    { headerText: 'Created By', rowText: 'CreatedBy' },
                    { headerText: 'Created On', rowText: 'CreationDateTime' },
                    { headerText: 'Title', rowText: 'Title' }
                ]
            });

            jQuery(function() {
                ko.applyBindings(index, jQuery('#latest-news-articles-container')[0]);
            });
        
        } (news_articles_latest_list));
    
        var news_articles_list  = {};

        (function (index) {

            var itemMapping = {
			    'CreationDateTime': ko.utils.getTimeAgoFromJson(),
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
        
            news_articles_list = index = ko.mapping.fromJS(" + @Html.Raw(new JavaScriptSerializer().Serialize(Model.PagedResult)) + @", mapping);

            index.HighlightEdits = ko.observable(false);

            index.pagedViewModel = new ko.pagedGrid.viewModel({
                controller: 'News',
                action: 'GetPage',
                data: index,
                singular: '" + @Resources.NewsArticle + @"',
                plural: '" + @Resources.NewsArticles + @"',
                pagingComponentIdentifier: 'paged-news-articles',
                loadPageCallback: function(data) {
                    ko.mapping.fromJS(data, index);
                },
                columns: [
                    { headerText: 'Created By', rowText: 'CreatedBy' },
                    { headerText: 'Created On', rowText: 'CreationDateTime' },
                    { headerText: 'Title', rowText: 'Title' },
                    { headerText: 'Content', rowText: 'Content' }
                ],
                additionalFunctions: {
                    raiseEdit: function (obj) {
                        jQuery(document).trigger('newsArticleEdit', [obj.Id()]);
                    },
                    raiseDetails: function (obj) {
                        jQuery(document).trigger('newsArticleDetails', [obj]);
                    },
                    raiseDelete: function (obj) {
                        jQuery(document).trigger('newsArticleDelete', [obj.Id()]);
                    }
                },
                updateEvent: null,
                deleteEvent: null
            });

            var hub = jQuery.connection.newsListHub;

            hub.handleRenamedNewsArticleTitleEventMessage = function(id, newTitle) {
                var update = ko.utils.arrayFirst(index.Items(), function(item) {
                    return item.Id() == id;
                });

                if (update == null)
                    return;

                if (update.Title() == newTitle)
                    return;
                
                ko.bindingHandlers.fadeInText.highlight = true;
                update.Title(newTitle);
                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleUpdatedNewsArticleContentEventMessage = function(id, newContent) {
                var update = ko.utils.arrayFirst(index.Items(), function(item) {
                    return item.Id() == id;
                });

                if (update == null)
                    return;

                if (update.Content() == newContent)
                    return;

                ko.bindingHandlers.fadeInText.highlight = true;
                update.Content(newContent);
                ko.bindingHandlers.fadeInText.highlight = false;
            };

            hub.handleDeletedNewsArticleEventMessage = function(id) {
                var toDelete = ko.utils.arrayFirst(index.Items(), function(item) {
                    return item.Id() == id;
                });

                if (toDelete == null)
                    return;

                index.Items.remove(toDelete);
                index.TotalItemCount((index.TotalItemCount() - 1))
            };

            jQuery(function() {
                ko.applyBindings(index, jQuery('#paged-news-articles-container')[0]);
            });

        } (news_articles_list));");
    }


            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
