using System;
using OpenQA.Selenium;

namespace TheInternet
{
    public class HomePage : BaseWebDriverUser
    {

        private readonly By _mainTitle = By.TagName("h1");
        private readonly By _formAuthenticationLink = By.LinkText("Form Authentication");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsAt()
        {
            return Driver.FindElement(_mainTitle).Text == "Welcome to the-internet";
        }

        public void ClickFormAuthenticationLink()
        {
            Driver.FindElement(_formAuthenticationLink).Click();
        }

        
    }
}
