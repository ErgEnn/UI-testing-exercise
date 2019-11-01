using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TheInternet
{
    public class SecureAreaPage : BaseWebDriverUser
    {

        private readonly By _logoutButton = By.CssSelector(".button.secondary.radius");

        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }


        public bool IsSuccessfulLoginNotificationDisplayed()
        {
            return Driver.FindElement(NotificationHelper.Success).Text.Contains("You logged into a secure area!");
        }

        public IWebElement LogoutButton()
        {
            return Driver.FindElement(_logoutButton);
        }
    }
}
