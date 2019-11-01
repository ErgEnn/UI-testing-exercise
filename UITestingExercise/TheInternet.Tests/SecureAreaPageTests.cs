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
    public class SecureAreaPageTests
    {

        private IWebDriver _driver;

        [TestInitialize]
        public void OpenDriver()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            NavigateAndLogin();
        }

        private void NavigateAndLogin()
        {
            new HomePage(_driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(_driver);

            form.EnterUsername("tomsmith");
            form.EnterPassword("SuperSecretPassword!");
            form.ClickSubmit();
        }

        [TestCleanup]
        public void CloseDriver()
        {
            _driver.Close();
        }

        [TestMethod]
        public void ShouldSeeLoginSuccessNotification()
        {
            SecureAreaPage secure = new SecureAreaPage(_driver);
            secure.IsSuccessfulLoginNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSeeLogoutSuccessDisplayed()
        {
            FormAuthenticationPage form = new FormAuthenticationPage(_driver);
            SecureAreaPage secure = new SecureAreaPage(_driver);
            secure.LogoutButton().Click();
            form.IsLogoutSuccessNotificationDisplayed().Should().BeTrue();
        }


    }
}
