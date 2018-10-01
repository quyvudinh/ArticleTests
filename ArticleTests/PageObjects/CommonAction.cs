using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ClassLibrary1
{
    public class CommonAction
    {
        private IWebDriver driver;
        public CommonAction(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickObj(By element)
        {
            driver.FindElement(element).Click();
        }
        public void EnterText(By element, string text)
        {
            driver.FindElement(element).Clear();
            driver.FindElement(element).SendKeys(text);
        }
        public void CheckOnRecentlyAddedAticle()
        {
            driver.FindElement(By.XPath("//div[@id='list_fullordering_chzn']//b")).Click();
            driver.FindElement(By.XPath("//li[contains(.,'ID descending')]")).Click();
            driver.FindElement(By.XPath("//input[@id='cb0']")).Click();
        }
        public void SelectComboBox(SelectElement element, IWebDriver driver, string id, string text)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("document.getElementById('" + id + "').style.display = 'block'");
                element.SelectByText(text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CheckMessageDisplayed(string message)
        {
            Assert.AreEqual(message, driver.FindElement(By.XPath("//div[@class = 'alert alert-success']/div[@class = 'alert-message']")).Text);
        }
        public void CheckStatusArticleIconDisplayed(string title, string status)
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//a[normalize-space()=\""+title+"\"]/ancestor::tr//span[@class = 'icon-"+status+"']")).Displayed);
        }
        public void CheckElementExist(By element)
        {
            Assert.IsTrue(driver.FindElement(element).Displayed);
        }
    }
}
