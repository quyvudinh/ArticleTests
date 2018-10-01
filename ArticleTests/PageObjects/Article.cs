using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace ClassLibrary1.PageObject
{
    public class Article:CommonAction
    {
        public Article(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        private IWebDriver driver;
        #region Elements
        //New button
        public By btnNew = By.Id("toolbar-new");
        //Article info
        public By txtTitle = By.Id("jform_title");
        public By cbbStatus = By.Id("jform_state_chzn");
        public By cbbCategory = By.XPath("//div[@id='jform_catid_chzn']//b");
        public By Description = By.Id("tinymce");
        //Status button
        public By btnEdit = By.Id("toolbar-edit");
        public By btnPublish = By.Id("toolbar-publish");
        public By btnUnpublish = By.Id("toolbar-unpublish");
        public By btnArchive = By.Id("toolbar-archive");

        //Filter button
        public By btnFilter = By.ClassName("js-stools-btn-filter");
        public By StatusFilter = By.XPath("//div[@id='filter_published_chzn']//b");
        //Status combobox
        public By Status = By.XPath("//div[@id='filter_published_chzn']//b");
        //Status filter
        public By Archivedfilter = By.XPath("//div[@id='filter_published_chzn']//li[contains(.,'Archived')]");
        public By Publishedfilter = By.XPath("//div[@id='filter_published_chzn']//li[contains(.,'Published')]");
        public By Unpublishedfilter = By.XPath("//div[@id='filter_published_chzn']//li[contains(.,'Unpublished')]");
        //Type save
        public By btnSave = By.ClassName("btn-success");
        public By btnSaveandClose = By.ClassName("button-save");
        //Message
        public By MessageSuccess = By.XPath("//div[@class = 'alert alert-success']/div[@class = 'alert-message']");
        #endregion

        #region Action
        public void CheckonCreatedArticle()
        {

        }
        public void FilterArticlebyStatus(By status)
        {
            driver.FindElement(btnFilter).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(StatusFilter).Click();
            driver.FindElement(status).Click();
        }
        public void EnterArticleInfo(string title, string category, string status, string description)
        {
            EnterText(txtTitle, title);
            driver.SwitchTo().Frame("jform_articletext_ifr");
            EnterText(Description, description);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(cbbStatus).Click();
            driver.FindElement(By.XPath("//li[contains(.,\""+status+"\")]")).Click();
            driver.FindElement(cbbCategory).Click();
            driver.FindElement(By.XPath("//div[@id='jform_catid_chzn']//li[text()=\""+category+"\"]")).Click();
        }
        public void CheckArticleSaved(string title, string category, string status, string text)
        {
            // Check message Article saved
            //Assert.AreEqual(message, driver.FindElement(By.XPath("//div[@class = 'alert alert-success']/div[@class = 'alert-message']")).Text);
            // Click on Article title
            driver.FindElement(By.XPath("//a[contains(.,\"" + title + "\")]")).Click();
            // Check all info entered
            if (text != null)
            {
                driver.SwitchTo().Frame("jform_articletext_ifr");
                Assert.AreEqual(text, driver.FindElement(By.XPath("//body[@id='tinymce']/p")).Text);
                driver.SwitchTo().DefaultContent();
            }
            if (category != null)
            {
                Assert.AreEqual(driver.FindElement(By.XPath("//div[@id='jform_catid_chzn']//span")).Text, category);
            }
            if (status !=null)
            {
                Assert.AreEqual(driver.FindElement(By.XPath("//div[@id='jform_state_chzn']//span")).Text, status);
            }
        }
        #endregion
    }
}
