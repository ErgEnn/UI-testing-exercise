using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TheInternet
{
    public static class NotificationHelper
    {

        public static readonly By Success = By.CssSelector(".flash.success");
        public static readonly By Error = By.CssSelector(".flash.error");

    }
}
