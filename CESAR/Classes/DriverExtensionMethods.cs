using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CESAR.Classes
{
    public static class SeleniumExtensionMethods
    {
        public static bool IsElementPresent(this IWebDriver _driver, By ele)
        {
            try
            {
                return (_driver.FindElements(ele).Count > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
