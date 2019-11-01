using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TheInternet
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementOrDefault(this IWebDriver driver, By by)
        {
            return driver.FindElements(by).FirstOrDefault();
        }
    }
}
