using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace CESAR.Classes
{
    [Binding]
    public class Hooks
    {
        
        [BeforeScenario]
        public void DriverOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito", "start-maximized"); // incognito and maximized.
            Global.driver = new ChromeDriver("../../../Drivers/",chromeOptions);
        }
        
        [AfterScenario]
        public void Dispose()
        {
            Global.driver.Quit();
            Global.driver.Dispose();
        }



    }
}
