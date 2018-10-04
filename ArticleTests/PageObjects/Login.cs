using ClassLibrary1.TestDataAccess;
using OpenQA.Selenium;

namespace ClassLibrary1.PageObject
{
    public class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }
        #region Elements
        public By username = By.Id("mod-login-username");
        public By password = By.Id("mod-login-password");
        public By loginbutton = By.ClassName("login-button");
        #endregion

        #region Action
        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://192.168.190.247/joomlatest/administrator/index.php");
        }

        public void login(string us, string pw)
        {
            driver.FindElement(username).SendKeys(us);
            driver.FindElement(password).SendKeys(pw);
            driver.FindElement(loginbutton).Click();
        }
        //public void login(string testName)
        //{
        //    var userData = ExcelDataAccess.GetTestData(testName);
        //    driver.FindElement(username).SendKeys(userData.Username);
        //    driver.FindElement(password).SendKeys(userData.Password);
        //    driver.FindElement(loginbutton).Click();
        //    //UserName.SendKeys(userData.Username);
        //    //Password.SendKeys(userData.Password);
        //    //Submit.Submit();
        //}
        #endregion

    }
}
