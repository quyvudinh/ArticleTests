using System;
using ClassLibrary1.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary1.TestObject
{
    [TestClass]
    public class ArticleTests : Testbase
    {
        string title;
        Random rand = new Random();
        string randdatetime = DateTime.Now.ToString("hhmmss");
        string articlecontent = "this is content";
        string messagearticlesaved = "Article saved.";
        string path = @"C:\Users\SATTDN18.02.07\Pictures\Saved Pictures\naruto.jpg";
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\SATTDN18.02.07\\Desktop\\TestData.xlsx;Persist Security Info = False;Extended Properties='Excel 12.0;HDR=Yes'", "DataSet$", DataAccessMethod.Sequential)]
        public void Login()
        {
            string username = TestContext.DataRow["Username"].ToString();
            string password = TestContext.DataRow["Password"].ToString();
            login.login(username, password);
        }

        [TestMethod]
        //[TestCategory(Verify user can create new article with valid information)]
        public void TestCase1()
        {
            Article article = new Article(driver);
            Homepage homepage = new Homepage(driver);
            title = "Article " + randdatetime + rand.Next(10000);
            commonaction.ClickElement(homepage.btnArticle);
            commonaction.ClickElement(article.btnNew);
            article.EnterArticleInfo(title, "Sample Data-Articles", "Unpublished", articlecontent);
            commonaction.ClickElement(article.btnSaveandClose);
            commonaction.CheckMessageDisplayed(messagearticlesaved);
            article.CheckArticleSaved(title, "Sample Data-Articles", "Unpublished", articlecontent);
        }

        [TestMethod]
        //[TestCategory(Verify user can edit an article)]
        public void TestCase2()
        {
            Article article = new Article(driver);
            Homepage homepage = new Homepage(driver);
            title = "Article " + randdatetime + rand.Next(10000);
            commonaction.ClickElement(homepage.btnArticle);
            commonaction.ClickElement(article.btnNew);
            article.EnterArticleInfo(title, "Sample Data-Articles", "Unpublished", articlecontent);
            commonaction.ClickElement(article.btnSaveandClose);
            commonaction.CheckOnRecentlyAddedAticle();
            commonaction.ClickElement(article.btnEdit);
            article.EnterArticleInfo("Test Article Edited", "- Park Site", "Unpublished", "this is modified content");
            commonaction.ClickElement(article.btnSaveandClose);
            commonaction.CheckMessageDisplayed(messagearticlesaved);
            article.CheckArticleSaved("Test Article Edited", "- Park Site", "Unpublished", "this is modified content");
        }

        [TestMethod]
        //[TestCategory(Verify user can publish an unpublished article)]
        public void TestCase3()
        {
            Article article = new Article(driver);
            Homepage homepage = new Homepage(driver);
            string publishmessage = CommonValue.ARTICLE_PUBLISH_MESSAGE;
            title = "Article " + randdatetime + rand.Next(10000);
            commonaction.ClickElement(homepage.btnArticle);
            commonaction.ClickElement(article.btnNew);
            article.EnterArticleInfo(title, "Sample Data-Articles", "Unpublished", articlecontent);
            commonaction.ClickElement(article.btnSaveandClose);
            commonaction.CheckOnRecentlyAddedAticle();
            commonaction.ClickElement(article.btnPublish);
            commonaction.CheckMessageDisplayed(publishmessage);
            commonaction.CheckStatusArticleIconDisplayed(title, "publish");
        }

        [TestMethod]
        //[TestCategory(Verify user can unpublish a published article)]
        public void TestCase4()
        {
            Article article = new Article(driver);
            Homepage homepage = new Homepage(driver);
            string unpublishmessage = CommonValue.ARTICLE_UNPUBLISH_MESSAGE;
            title = "Article " + randdatetime + rand.Next(10000);
            commonaction.ClickElement(homepage.btnArticle);
            commonaction.ClickElement(article.btnNew);
            article.EnterArticleInfo(title, "Sample Data-Articles", "Published", articlecontent);
            commonaction.ClickElement(article.btnSaveandClose);
            commonaction.CheckOnRecentlyAddedAticle();
            commonaction.ClickElement(article.btnUnpublish);
            commonaction.CheckMessageDisplayed(unpublishmessage);
            commonaction.CheckStatusArticleIconDisplayed(title, "unpublish");
        }

        [TestMethod]
        //[TestCategory(Verify user can move an article to the archive)]
        public void TestCase5()
        {
            Article article = new Article(driver);
            Homepage homepage = new Homepage(driver);
            string archivemessage = CommonValue.ARTICLE_ARCHIVE_MESSAGE;
            title = "Article " + randdatetime + rand.Next(10000);
            commonaction.ClickElement(homepage.btnArticle);
            commonaction.ClickElement(article.btnNew);
            article.EnterArticleInfo(title, "Sample Data-Articles", "Published", articlecontent);
            commonaction.ClickElement(article.btnSaveandClose);
            commonaction.CheckOnRecentlyAddedAticle();
            commonaction.ClickElement(article.btnArchive);
            commonaction.CheckMessageDisplayed(archivemessage);
            //Filter
            article.FilterArticlebyStatus(article.Archivedfilter);
            article.CheckArticleSaved(title, null, null, null);
        }

        [TestMethod]
        public void Uploadfiletopage()
        {
            Homepage homepage = new Homepage(driver);
            Media media = new Media(driver);
            commonaction.ClickElement(homepage.btnMedia);
            commonaction.ClickElement(media.btnUpload);
            System.Threading.Thread.Sleep(1000);
            commonaction.ClickElement(media.btnChoosefile);
            media.UploadFile(path);
            //driver.FindElement(By.Id("upload-file")).SendKeys(@"C:\Users\SATTDN18.02.07\Pictures\Saved Pictures\" + CommonValue.IMAGE_NAME + "");
            //commonaction.ClickObj(media.btnChoosefile);
            //System.Threading.Thread.Sleep(1000);
            //media.UploadFile(CommonValue.IMAGE_NAME);
            commonaction.ClickElement(media.btnStartUpload);
            commonaction.CheckMessageDisplayed(@"Upload Complete: \" + CommonValue.IMAGE_NAME);
            driver.SwitchTo().Frame("folderframe");
            commonaction.CheckElementExist(media.UploadedFile);
            commonaction.ClickElement(media.btnDeleteImage);
            driver.SwitchTo().DefaultContent();
        }
    }
}
