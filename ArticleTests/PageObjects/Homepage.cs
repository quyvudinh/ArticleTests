using OpenQA.Selenium;

namespace ClassLibrary1.PageObject
{
    public class Homepage
    {
        private IWebDriver driver;
        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public By btnArticle = By.ClassName("icon-stack");
        public By btnMedia = By.ClassName("icon-pictures");
    }
}
