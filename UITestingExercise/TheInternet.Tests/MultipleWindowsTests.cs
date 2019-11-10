using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheInternet.Tests
{
    [TestClass]
    public class MultipleWindowsTests : BaseWebPageTest
    {

        [TestMethod]
        public void ShouldSeeTextNewWindowInNewWindow()
        {
            new HomePage(Driver).ClickMultipleWindowsLink();
            var mw = new MultipleWindows(Driver);
            mw.NewWindowLink.Click();
            Driver.WindowHandles.Count.Should().Be(2);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            mw.NewWindowText.Text.Should().Be("New Window");
        }

    }
}
