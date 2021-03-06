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

namespace ThreeBytes.Email.Dashboard.Host.Frontend.Views.EmailDashboardHost
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
    
    #line 1 "..\..\Views\EmailDashboardHost\Index.cshtml"
    using ThreeBytes.Core.Security.Concrete;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/EmailDashboardHost/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\EmailDashboardHost\Index.cshtml"
  
	Page.Title = "Email System Dashboard";


            
            #line default
            #line hidden
WriteLiteral("\r\n<section id=\"home\">\r\n    <div class=\"row\">    \r\n\t    <div class=\"span12\">      " +
"\t\t\r\n\t      \t<div class=\"widget big-stats-container\">\t\t\r\n\t      \t\t<div class=\"wid" +
"get-content\">\t\t\t\r\n\t\t\t      \t<div id=\"big_stats\" class=\"cf\">\r\n");


            
            #line 12 "..\..\Views\EmailDashboardHost\Index.cshtml"
  						 Html.RenderAction("DailyStatistic", "DispatchDaily"); 	

            
            #line default
            #line hidden

            
            #line 13 "..\..\Views\EmailDashboardHost\Index.cshtml"
  						 Html.RenderAction("MonthlyStatistic", "DispatchMonthly"); 	

            
            #line default
            #line hidden

            
            #line 14 "..\..\Views\EmailDashboardHost\Index.cshtml"
                           Html.RenderAction("QuarterlyStatistic", "DispatchQuarterly"); 

            
            #line default
            #line hidden

            
            #line 15 "..\..\Views\EmailDashboardHost\Index.cshtml"
                           Html.RenderAction("YearlyStatistic", "DispatchYearly"); 

            
            #line default
            #line hidden
WriteLiteral(@"					</div>				
				</div>					
			</div>
	    </div>	      	
	</div>
    <div class=""row""> 
        <div class=""span8"">
            <div class=""widget"">
                <div class=""widget-header"">
                    <i class=""icon-signal""></i>
                    <h3>Email Statistics</h3>
                </div>
                <div class=""widget-content"">
                    <div class=""row"">
                        <div class=""span3"">
");


            
            #line 31 "..\..\Views\EmailDashboardHost\Index.cshtml"
                               Html.RenderAction("DailyStatistics", "DispatchDaily"); 

            
            #line default
            #line hidden

            
            #line 32 "..\..\Views\EmailDashboardHost\Index.cshtml"
                               Html.RenderAction("MonthlyStatistics", "DispatchMonthly"); 

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n                        <div class=\"span4\">\r\n");


            
            #line 35 "..\..\Views\EmailDashboardHost\Index.cshtml"
                               Html.RenderAction("QuarterlyStatistics", "DispatchQuarterly"); 

            
            #line default
            #line hidden

            
            #line 36 "..\..\Views\EmailDashboardHost\Index.cshtml"
                               Html.RenderAction("YearlyStatistics", "DispatchYearly"); 

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n                    </div>\r\n                </div" +
">\r\n            </div>\r\n        </div>\r\n        <div class=\"span4\">\r\n");


            
            #line 43 "..\..\Views\EmailDashboardHost\Index.cshtml"
               Html.RenderAction("MostRecent", "EmailDispatchWidget"); 

            
            #line default
            #line hidden

            
            #line 44 "..\..\Views\EmailDashboardHost\Index.cshtml"
               Html.RenderAction("MostRecent", "EmailTemplateWidget"); 

            
            #line default
            #line hidden
WriteLiteral("        </div>   \r\n    </div>\r\n</section>\r\n\r\n");


            
            #line 49 "..\..\Views\EmailDashboardHost\Index.cshtml"
   Html.RenderAction("Details", "EmailDispatchView");

            
            #line default
            #line hidden

            
            #line 50 "..\..\Views\EmailDashboardHost\Index.cshtml"
   Html.RenderAction("Details", "EmailTemplateView");

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 52 "..\..\Views\EmailDashboardHost\Index.cshtml"
 if (((ThreeBytesPrincipal) Context.User).IsInAnyRoles(new[] { "Admin", "EmailTemplateManager" }))
{
    { Html.RenderAction("Edit", "EmailTemplateManagement"); }
}

            
            #line default
            #line hidden
WriteLiteral("        \r\n");


            
            #line 57 "..\..\Views\EmailDashboardHost\Index.cshtml"
 if (((ThreeBytesPrincipal) Context.User).IsInAnyRoles(new[] { "Admin", "EmailTemplateManager" }))
{ 
    { Html.RenderAction("Delete", "EmailTemplateManagement"); }
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
