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
    public class SecureAreaPageTests : BaseWebPageTest
    {
        [TestInitialize]
        public override void OpenDriver()
        {
            base.OpenDriver();
            NavigateAndLogin();
        }

        private void NavigateAndLogin()
        {
            new HomePage(Driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(Driver);

            form.EnterUsername("tomsmith");
            form.EnterPassword("SuperSecretPassword!");
            form.ClickSubmit();
        }

        [TestCleanup]
        public void CloseDriver()
        {
            Driver.Close();
        }

        [TestMethod]
        public void ShouldSeeLoginSuccessNotification()
        {
            SecureAreaPage secure = new SecureAreaPage(Driver);
            secure.IsSuccessfulLoginNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSeeLogoutSuccessDisplayed()
        {
            FormAuthenticationPage form = new FormAuthenticationPage(Driver);
            SecureAreaPage secure = new SecureAreaPage(Driver);
            secure.LogoutButton().Click();
            form.IsLogoutSuccessNotificationDisplayed().Should().BeTrue();
        }


    }
}
