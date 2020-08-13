using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CESAR
{
    public static class Global
    {
        public static IWebDriver driver;
        public static string mainWindow = string.Empty;

        public static void TabSwitch(int tabPosition)
        {
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs.ElementAt(tabPosition));
        }

        public static void ScrollToAnElement(By xElement)
        {
            var element = driver.FindElement(xElement);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void WaitForLoad(int seconds = 5)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
