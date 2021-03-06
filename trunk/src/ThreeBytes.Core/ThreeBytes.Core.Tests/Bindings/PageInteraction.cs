﻿using NUnit.Framework;
using TechTalk.SpecFlow;
using ThreeBytes.Core.Tests.Helpers;
using WatiN.Core;

namespace ThreeBytes.Core.Tests.Bindings
{
    [Binding]
    public class PageInteraction
    {
        [When("I click the \"(.*)\" link")]
        public void WhenIClickALinkNamed(string linkName)
        {
            var link = WebBrowser.Current.Link(Find.ByText(linkName));

            if (!link.Exists)
                Assert.Fail(string.Format("Could not find {0} link on the page", linkName));

            link.Click();
        }

        [When("I click the \"(.*)\" button")]
        public void WhenIClickAButtonWithValue(string buttonValue)
        {
            var button = WebBrowser.Current.Button(Find.ByValue(buttonValue));

            if (!button.Exists)
                Assert.Fail(string.Format("Could not find {0} button on the page", buttonValue));

            button.Click();
        }
    }
}
