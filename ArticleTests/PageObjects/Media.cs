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

        //#region Actions
        //public void UploadFile(string filename)
        //{
        //    SendKeys.SendWait(@"C:\Users\SATTDN18.02.07\Pictures\Saved Pictures\"+filename+"");
        //    SendKeys.SendWait(@"{Enter}");
        //}
        //#endregion
    }
}
