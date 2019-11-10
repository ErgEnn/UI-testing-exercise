using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TheInternet
{
    public class MultipleWindows : BaseWebDriverUser
    {

        private readonly By _newWindowLink = By.LinkText("Click Here");
        private readonly By _newWindowText = By.CssSelector("h3");

        public MultipleWindows(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement NewWindowLink => Driver.FindElement(_newWindowLink);

        public IWebElement NewWindowText => Driver.FindElement(_newWindowText);
    }
}
