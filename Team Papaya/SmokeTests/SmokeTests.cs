using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Team_Papaya.Models;
using Team_Papaya.Pages.CreateArticlePage;
using Team_Papaya.Pages.HomePage;
using Team_Papaya.Pages.LoginPage;
using Team_Papaya.Pages.RegistrationPage;


namespace Team_Papaya
{
    [TestFixture]
    public class SmokeTests
    {
        public IWebDriver driver;
        
        [SetUp]
        public void Initialize()
        {
            driver = BrowserHost.Instance.Application.Browser;

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            // This is for TeamCity to build...
            //driver.Quit();
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Hristo Bahnev")]
        public void HomePageHeaderTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageHeaderIsDisplayed("SOFTUNI BLOG");
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Iliya Iliev")]
        public void RP_TC1_RegistrationWithValidData()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + new Random().Next(100000, 100000000) + "@abv.bg", "Test" + new Random().Next(100000, 100000000), "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertRegisterWithValidData();
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Iliya Iliev")]
        public void RP_TC2_RegistrationWithInvalidEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@.abv.bg", "Test", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertInvalidEmailMessage("The Email field is not a valid e-mail address.");
        }

        // FAIL
        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Iliya Iliev")]
        public void RP_TC3_RegistrationWithDuplicatedEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertInvalidEmailMessage("This email is already taken");
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Petar Uzunov")]
        public void LP_TC1_LoginWithValidData()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            loginPage.AssertLoginWithValidData();
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Petar Uzunov")]
        public void LP_TC2_LoginWithInvalidEmailFormat()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            loginPage.AssertInvalidEmailMessage("The Email field is not a valid e-mail address.");
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC1_CreateArticleWithValidData()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var createArticlePage = new CreateArticlePage(driver);
            var articleContent = new CreateArticleContent("Test Automation is the key", "Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            createArticlePage.NavigateTo();
            createArticlePage.FillCreateArticleForm(articleContent);

            createArticlePage.AssertCreateArticleWithValidData("Test Automation is the key");
        }

        [Test]
        [Property("Smoke Tests", 1)]
        [Author("Todor Peshin")]
        public void CAP_TC3_Create_ArticleWithoutContent()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);
            var createArticlePage = new CreateArticlePage(driver);
            createArticlePage.NavigateTo();
            createArticlePage.Title.Clear();
            createArticlePage.Title.SendKeys("Tralala");
            createArticlePage.Content.Clear();
            createArticlePage.CreateArticleButton.Click();
            createArticlePage.AssertCreateArticleWithoutContent("The Content field is required.");
        }
    }
}
