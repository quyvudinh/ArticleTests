using ClassLibrary1.PageObject;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using ClassLibrary1.TestDataAccess;

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
        public TestContext TestContext { get; set; }

        [TestInitialize]
        //[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\SATTDN18.02.07\\Desktop\\TestData.xlsx;Persist Security Info = False;Extended Properties='Excel 12.0;HDR=Yes'", "DataSet$", DataAccessMethod.Sequential)]        
        public void TestIntitialize()
        {
            //ExcelUtil util = new ExcelUtil();
            //util.PopulateInCollection(@"C:\Users\SATTDN18.02.07\Desktop\TestData.xlsx");
            UserData userdata = new UserData(); 
            options = new ChromeOptions();    
            //driver = new RemoteWebDriver(new Uri("http://" + ipAddress + ":4444/wd/hub"), options);
            //driver = new InternetExplorerDriver();
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();       
            login = new Login(driver);
            commonaction = new CommonAction(driver);
            login.goToPage();
            //login.login("quy", "quyquy");
            //string username = TestContext.DataRow["Username"].ToString();
            //string password = TestContext.DataRow["Password"].ToString();
            //login.login(username,password);
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
