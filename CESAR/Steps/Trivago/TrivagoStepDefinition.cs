using CESAR.PageObjects.Trivago;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CESAR.Steps.Trivago
{
    [Binding]
    public sealed class TrivagoStepDefinition
    {
        TrivagoHomePageObject triHomePO;
        TrivagoSearchPageObject triSearchPO;
        IWebDriver driver = Global.driver;
        [Given(@"I navigate to ""(.*)"" and search for ""(.*)""")]
        public void GivenINavigateToAndSearchFor(string url, string destination)
        {
            triHomePO = new TrivagoHomePageObject();
            driver.Navigate().GoToUrl(url);
            Global.WaitForLoad(2);

            driver.FindElement(triHomePO.GetSearchMenu()).SendKeys(destination);
            Thread.Sleep(3000);

            driver.FindElement(triHomePO.GetSearchButton()).Click(); 
        }

        [Then(@"I sort my result by ""(.*)"" and click on the map button\.")]
        public void ThenISortMyResultByAndClickOnTheMapButton_(string sortOption)
        {
            triSearchPO = new TrivagoSearchPageObject();
            Global.WaitForLoad();

            IWebElement sortSelectElement = driver.FindElement(triSearchPO.GetSortSelect());
            SelectElement sortObject = new SelectElement(sortSelectElement);
            
            sortObject.SelectByText(sortOption);
            
            //driver.FindElement(triSearchPO.GetMapButton()).Click();
        }

        [Then(@"I print the expect result for Hotel number (\d+)\.")]
        public void ThenIPrintTheExpectResult_(int number)
        {
            triSearchPO = new TrivagoSearchPageObject();
            Global.WaitForLoad();

            var hotels = driver.FindElements(triSearchPO.GetHotels());
            IWebElement selectedHotel = hotels.ElementAt(number-1);

            string nome = selectedHotel.FindElement(By.XPath(".//h3[@class='m-0']")).Text;
            string estrelas = selectedHotel.FindElements(By.XPath(".//span[contains(@class,'icon-ic star')]")).Count().ToString(); //icon-ic star
            string oferta = selectedHotel.FindElement(By.XPath(".//header[contains(@class,'accommodation-list__header')]")).Text;
            string preco = selectedHotel.FindElement(By.XPath(".//div[contains(@class,'accommodation-list__prices')]")).Text;
            string comodidades = selectedHotel.FindElement(By.XPath(".//p[contains(@class,'accommodation-list')]")).Text; 


            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.WriteLine("");
            Trace.WriteLine("[RESULTADO]");
            Trace.WriteLine("");
            Trace.WriteLine($"Nome: {nome} Estrelas: {estrelas} estrela(s)");
            Trace.WriteLine($"Oferta da empresa: {oferta} Preço: {preco}");
            Trace.WriteLine($"Comodidades do quarto:: {comodidades}");

            Assert.AreEqual(hotels.Count,25);
        }
    }
}
