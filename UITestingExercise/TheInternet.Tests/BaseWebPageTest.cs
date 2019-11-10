using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TheInternet.Tests
{
    public abstract class BaseWebPageTest
    {

        protected IWebDriver Driver { get; set; }

        [TestInitialize]
        public  virtual void OpenDriver()
        {
            Driver = new FirefoxDriver();
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }

        [TestCleanup]
        public void CloseDriver()
        {
            Driver.Dispose();
        }

    }
}
