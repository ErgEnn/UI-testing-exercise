using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheInternet.Tests
{
    [TestClass]
    public class HomePageTests : BaseWebPageTest
    {

        [TestMethod]
        public void ShouldBeAtHomePage()
        {
            HomePage homePage = new HomePage(Driver);

            homePage.IsAt().Should().BeTrue();
        }

    }
}
