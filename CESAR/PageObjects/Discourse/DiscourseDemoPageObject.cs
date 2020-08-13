using OpenQA.Selenium;

namespace CESAR.PageObjects.Discourse
{
    public class DiscourseDemoPageObject
    {
        private string xDemoTitle = "//h1[@class='text-logo' and text()='Demo']";
        private string xNoMoreTopics = "//footer[@class='topic-list-bottom']//h3";
        private string xTopics = "//tr[contains(@class,'topic-list-item')]";
        public By GetDemoTitle()
        {
            return By.XPath(xDemoTitle);
        }
        public By GetNoMoreTopics()
        {
            return By.XPath(xNoMoreTopics);
        }
        public By GetTopics()
        {
            return By.XPath(xTopics);
        }
    }
}
