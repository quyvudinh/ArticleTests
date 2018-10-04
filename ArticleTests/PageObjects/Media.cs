using AutoItX3Lib;
using OpenQA.Selenium;
namespace ClassLibrary1.PageObject
{
    class Media:CommonAction
    {
        private IWebDriver driver;
        public Media(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #region Elements
        public By btnUpload = By.Id("toolbar-upload");
        public By btnChoosefile = By.Id("upload-file");
        public By btnStartUpload = By.Id("upload-submit");
        public By UploadedFile = By.XPath("//li[.//input[@value='" + CommonValue.IMAGE_NAME + "']]");
        public By btnDeleteImage = By.XPath("//input[@value='" + CommonValue.IMAGE_NAME + "']/ancestor::li//a[@class = 'close delete-item']");
        #endregion

        #region Actions
        public void UploadFile(string path)
        {
            AutoItX3 autoIT = new AutoItX3();
            autoIT.ControlClick("Open", "", "Edit1");
            System.Threading.Thread.Sleep(1000);
            autoIT.Send(path);
            autoIT.ControlClick("Open", "", "Button1");
        }
        #endregion
    }
}
