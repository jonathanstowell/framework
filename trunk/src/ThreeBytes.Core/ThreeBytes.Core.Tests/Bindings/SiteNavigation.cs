using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ThreeBytes.Core.Tests.Helpers;

namespace ThreeBytes.Core.Tests.Bindings
{
    [Binding]
    public class SiteNavigation
    {
        [Given(@"I am on the site home page")]
        public void GivenIAmOnTheSiteHomePage()
        {
            WebBrowser.Current.GoTo("http://localhost/");
        }
    }
}
