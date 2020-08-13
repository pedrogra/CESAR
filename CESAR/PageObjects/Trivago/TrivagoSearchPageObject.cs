using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CESAR.PageObjects.Trivago
{
    public class TrivagoSearchPageObject
    {
        private string xMapButton =     "//button[contains(@class,'map-list')]";
        private string xSelectSortBy =  "//select[@id='mf-select-sortby']";
        private string xListHotels =    "//li[contains(@class,'hotel-item')]";

        public By GetMapButton()
        {
            return By.XPath(xMapButton);
        }

        public By GetSortSelect()
        {
            return By.XPath(xSelectSortBy);
        }

        public By GetHotels()
        {
            return By.XPath(xListHotels);
        }

        
    }
}
