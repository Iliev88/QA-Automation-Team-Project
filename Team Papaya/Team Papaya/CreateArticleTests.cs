using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Team_Papaya.Models;
using Team_Papaya.Pages.CreateArticlePage;
using Team_Papaya.Pages.LoginPage;

namespace Team_Papaya
{
    [TestFixture]
    public class CreateArticleTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = BrowserHost.Instance.Application.Browser;

            driver.Manage().Window.Maximize();

            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);
        }

        [TearDown]
        public void CleanUp()
        {
            // This is for TeamCity to build...
            //driver.Quit();
        }
        
        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC1_CreateArticleWithValidData()
        {
            var createArticlePage = new CreateArticlePage(driver);
            var articleContent = new CreateArticleContent("Test Automation is the key", "Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            createArticlePage.NavigateTo();
            createArticlePage.FillCreateArticleForm(articleContent);

            createArticlePage.AssertCreateArticleWithValidData("Test Automation is the key");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC2_Cancel_Empty_Article()
        {
            var createArticlePage = new CreateArticlePage(driver);

            createArticlePage.NavigateTo();
            createArticlePage.CancelArticleButton.Click();

            createArticlePage.AssertCreateArticleWithValidData("Test Automation is the key");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC3_Create_ArticleWithoutContent()
        {
            var createArticlePage = new CreateArticlePage(driver);

            createArticlePage.NavigateTo();
            createArticlePage.Title.SendKeys("Tralala");
            createArticlePage.CreateArticleButton.Click();

            createArticlePage.AssertCreateArticleWithoutContent("The Content field is required.");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC4_Create_ArticleWithoutTitle()
        {
            var createArticlePage = new CreateArticlePage(driver);

            createArticlePage.NavigateTo();
            createArticlePage.Content.SendKeys("tralala");
            createArticlePage.CreateArticleButton.Click();

            createArticlePage.AssertCreateArticleWithoutTitle("The Title field is required.");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC5_Create_ArticleWithoutTitle_Content()
        {
            var createArticlePage = new CreateArticlePage(driver);

            createArticlePage.NavigateTo();
            createArticlePage.CreateArticleButton.Click();

            createArticlePage.AssertCreateArticleWithoutTitle_andContent("The Title field is required.", "The Content field is required.");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC6_Create_ArticlePageDisplayed()
        {
            var createArticlePage = new CreateArticlePage(driver);

            createArticlePage.NavigateTo();

            createArticlePage.AssertCreateArticlePageIsDisplayed("Create Article");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC7_Create_ArticleContentResize()
        {
            var createArticlePage = new CreateArticlePage(driver);

            createArticlePage.NavigateTo();

            Actions builder = new Actions(this.driver);
            var action = builder.MoveToElement(createArticlePage.Content)
                                .MoveByOffset((createArticlePage.Content.Size.Width / 2) - 2, (createArticlePage.Content.Size.Height / 2) - 2)
                                .ClickAndHold()
                                .MoveByOffset(300, 300)
                                .Release();

            action.Perform();
            createArticlePage.AssertCreateArticlePageIsDisplayed("Create Article");
            createArticlePage.AssertCreateArticleComtentresized(300);
        }
    }
}
