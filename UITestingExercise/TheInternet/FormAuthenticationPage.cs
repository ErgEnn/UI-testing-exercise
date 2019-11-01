using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TheInternet
{
    public class FormAuthenticationPage : BaseWebDriverUser
    {
        private By _usernameField = By.Id("username");
        private By _passwordField = By.Id("password");
        private By _submitButton = By.XPath("//button[@type='submit']");


        public FormAuthenticationPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUsername(String username)
        {
            Driver.FindElement(_usernameField).SendKeys(username);
        }

        public void EnterPassword(String password)
        {
            Driver.FindElement(_passwordField).SendKeys(password);
        }

        public void ClickSubmit()
        {
            Driver.FindElement(_submitButton).Click();
        }

        public bool IsSuccessNotificationDisplayed()
        {
            return Driver.FindElements(NotificationHelper.Success).Any();
        }

        public bool IsErrorNotificationDisplayed()
        {
            return Driver.FindElements(NotificationHelper.Error).Any();
        }

        public bool IsUsernameErrorNotificationDisplayed()
        {
            return Driver.FindElement(NotificationHelper.Error).Text.Contains("Your username is invalid!");
        }

        public bool IsPasswordErrorNotificationDisplayed()
        {
            return Driver.FindElement(NotificationHelper.Error).Text.Contains("Your password is invalid!");
        }

        public bool IsLogoutSuccessNotificationDisplayed()
        {
            return Driver.FindElement(NotificationHelper.Success).Text.Contains("You logged out of the secure area!");
        }

    }
}