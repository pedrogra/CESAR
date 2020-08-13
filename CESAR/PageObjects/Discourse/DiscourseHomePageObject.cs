using OpenQA.Selenium;

namespace CESAR.PageObjects.Discourse
{
    public class DiscourseHomePageObject
    {
        private string xDemo = "//nav[@id='main']//a[text()='Demo']";
        public By GetDemoMenu()
        {
            return By.XPath(xDemo);
        }
    }
}
