using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CESAR.PageObjects.Trivago
{
    class TrivagoHomePageObject
    {
        private string xSearchText = "//input[@type='search']";
        private string xSearchButton = "//button[contains(@class,'search-button')]";



        public By GetSearchMenu()
        {
            return By.XPath(xSearchText);
        }

        public By GetSearchButton()
        {
            return By.XPath(xSearchButton);
        }
    }
}
