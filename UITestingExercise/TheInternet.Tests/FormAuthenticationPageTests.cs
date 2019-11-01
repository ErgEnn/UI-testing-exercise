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
    public class FormAuthenticationPageTests
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void OpenDriver()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }

        [TestMethod]
        public void ShouldBeAtHomePage()
        {
            HomePage homePage = new HomePage(_driver);

            homePage.IsAt().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldLoginWithValidCredentials()
        {
            new HomePage(_driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(_driver);

            form.EnterUsername("tomsmith");
            form.EnterPassword("SuperSecretPassword!");
            form.ClickSubmit();

            form.IsSuccessNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldTryLoginWithInvalidCredentials()
        {
            new HomePage(_driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(_driver);

            form.EnterUsername("Peeter-Eeter Termomeeter");
            form.EnterPassword("CorrectHorseBatteryStaple");
            form.ClickSubmit();

            form.IsErrorNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSeeUsernameInvalidError()
        {
            new HomePage(_driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(_driver);

            form.ClickSubmit();

            form.IsUsernameErrorNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSeePasswordInvalidError()
        {
            new HomePage(_driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(_driver);

            form.EnterUsername("tomsmith");
            form.ClickSubmit();

            form.IsPasswordErrorNotificationDisplayed().Should().BeTrue();
        }

        [TestCleanup]
        public void CloseDriver()
        {
            _driver.Close();
        }
    }
}
