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
    public class FormAuthenticationPageTests : BaseWebPageTest
    {
        [TestMethod]
        public void ShouldLoginWithValidCredentials()
        {
            new HomePage(Driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(Driver);

            form.EnterUsername("tomsmith");
            form.EnterPassword("SuperSecretPassword!");
            form.ClickSubmit();

            form.IsSuccessNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldTryLoginWithInvalidCredentials()
        {
            new HomePage(Driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(Driver);

            form.EnterUsername("Peeter-Eeter Termomeeter");
            form.EnterPassword("CorrectHorseBatteryStaple");
            form.ClickSubmit();

            form.IsErrorNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSeeUsernameInvalidError()
        {
            new HomePage(Driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(Driver);

            form.ClickSubmit();

            form.IsUsernameErrorNotificationDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSeePasswordInvalidError()
        {
            new HomePage(Driver).ClickFormAuthenticationLink();
            FormAuthenticationPage form = new FormAuthenticationPage(Driver);

            form.EnterUsername("tomsmith");
            form.ClickSubmit();

            form.IsPasswordErrorNotificationDisplayed().Should().BeTrue();
        }
    }
}
