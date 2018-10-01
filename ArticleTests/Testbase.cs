using ClassLibrary1.PageObject;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace ClassLibrary1
{
    [TestClass]
    public class Testbase
    {
        public IWebDriver driver;
        Random rand = new Random();
        public Login login;
        public CommonAction commonaction;
        string ipAddress = "192.168.190.250";           
        ChromeOptions options;

        [TestInitialize]
        public void TestIntitialize()
        {
            options = new ChromeOptions();    
            driver = new RemoteWebDriver(new Uri("http://" + ipAddress + ":4444/wd/hub"), options);
            //driver = new InternetExplorerDriver();
            //driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            driver.Manage().Window.Maximize();       
            login = new Login(driver);
            commonaction = new CommonAction(driver);
            login.goToPage();
            login.login("quy", "quyquy");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
