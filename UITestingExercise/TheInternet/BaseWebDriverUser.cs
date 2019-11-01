using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TheInternet
{
    public abstract class BaseWebDriverUser
    {
        protected IWebDriver Driver { get; set; }

        protected BaseWebDriverUser(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
