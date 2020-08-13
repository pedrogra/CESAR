using CESAR.Classes;
using CESAR.PageObjects.Discourse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CESAR.Steps
{
    [Binding]
    public sealed class DiscourseStepDefinition
    {
        IWebDriver driver = Global.driver;
        DiscourseHomePageObject homePO;
        DiscourseDemoPageObject demoPO;

        [Given(@"I Navigate to ""(.*)"" and click on ""(.*)""")]
        public void GivenINavigateToAndClickOn(string url, string menuOption)
        {
            homePO = new DiscourseHomePageObject();
            demoPO = new DiscourseDemoPageObject();

            driver.Navigate().GoToUrl(url);
            driver.FindElement(homePO.GetDemoMenu()).Click();

            Global.TabSwitch(1);
            IWebElement title = driver.FindElement(demoPO.GetDemoTitle());
            Assert.AreEqual("Demo", title.Text);
        }

        [When(@"I scrolldown until the bottom of the page\.")]
        public void WhenIScrolldownUntilTheBottomOfThePage_()
        {
            demoPO = new DiscourseDemoPageObject();

            do
            {
                Global.ScrollDown();

            } while (!driver.IsElementPresent(demoPO.GetNoMoreTopics()));

            Global.ScrollToAnElement(demoPO.GetNoMoreTopics());
        }

        [Then(@"I print the expect information\.")]
        public void ThenIPrintSomeInformation_()
        {
            demoPO = new DiscourseDemoPageObject();
            List<Topic> topics = new List<Topic>();

            foreach(IWebElement topic in driver.FindElements(demoPO.GetTopics()))
            {
                Topic t = new Topic();
                t.Title = topic.FindElement(By.XPath(".//span[@class='link-top-line']/a")).Text;

                string views = topic.FindElement(By.XPath(".//td[contains(@class,'num views')]/span")).GetAttribute("Title").Replace(",", "");
                t.Views = int.Parse(Regex.Replace(views, "[^0-9.]", string.Empty));

                t.IsLocked = topic.FindElements(By.XPath(".//span[@class='topic-status']/*[contains(@class,'lock')]")).Count > 0;

                t.Category = string.Empty;
                if(topic.FindElements(By.XPath(".//div[@class='link-bottom-line']/a")).Count > 0 )
                    t.Category = topic.FindElement(By.XPath(".//div[@class='link-bottom-line']/a")).Text;

                topics.Add(t);
            }
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.WriteLine("");
            Trace.WriteLine("[RESULTADO]");
            Trace.WriteLine("");
            //A descrição de todos os tópicos fechados (são os que tem um cadeado ao lado esquerdo do título)
            Trace.WriteLine("A descrição de todos os topicos fechados são:");
            topics.Where(t => t.IsLocked).ToList().ForEach(delegate(Topic t1) {
                Trace.WriteLine($" - {t1.Title}");
            });
            Trace.WriteLine("");
            //Quantidade de itens de cada categoria e dos que não possui categoria
            Trace.WriteLine("Quantidade de itens de cada categoria e dos que não possui categoria");
            var groups = topics.GroupBy(t => t.Category).Select(t => new Topic{ Category = t.Key, Views = t.Count() }).OrderBy(t => t.Views);
            groups.ToList().ForEach(delegate(Topic t1) {
                t1.Category = t1.Category.Length > 0 ? t1.Category : "empty";
                Trace.WriteLine($"- { t1.Category } - {t1.Views}");
            });
            Trace.WriteLine("");
            //O título do tópico que contém o maior número de views
            Trace.WriteLine($"O titulo com maior numeros de views é: {topics.OrderByDescending(t => t.Views).First().Title} com {topics.OrderByDescending(t => t.Views).First().Views} views.");
            Trace.WriteLine("");
        }
    }
}
