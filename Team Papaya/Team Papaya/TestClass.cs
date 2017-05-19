using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Papaya.Models;
using Team_Papaya.Pages.CreateArticlePage;
using Team_Papaya.Pages.HomePage;
using Team_Papaya.Pages.LoginPage;
using Team_Papaya.Pages.RegistrationPage;

namespace Team_Papaya
{
    [TestFixture]
    public class TestClass
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
        [Property("HomePage Tests", 1)]
        public void HomePageHeaderTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageHeaderIsDisplayed("SOFTUNI BLOG");
        }

        [Test]
        [Property("HomePage Tests", 1)]
        public void HomePageFooterTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageFooterIsDisplayed("© 2017 - SoftUni Blog");
        }

        [Test]
        [Property("HomePage Tests", 1)]
        public void HomePageRegisterButtonTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageRegisterButtonIsDisplayed("Register");
        }

        [Test]
        [Property("HomePage Tests", 1)]
        public void HomePageLoginButtonTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageLoginButtonIsDisplayed("Log in");
        }

        // TEST REGISTRATION PAGE
        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC0_RegisterButtonTest()
        {
            var registrationPage = new RegistrationPage(driver);

            registrationPage.NavigateTo();

            registrationPage.AssertRegistrationPageRegisterHeaderIsDisplayed("Register");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC1_RegistrationWithValidData()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "123456", "123456");
            //var user = new RegisterUser("test" + new Random().Next(100000, 100000000) + "@abv.bg", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertRegisterWithValidData();
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
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
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC3_RegistrationWithDuplicatedEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertInvalidEmailMessage("This email is already taken");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC4_RegistrationWithEmptyEmailField()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC5_RegistrationWithNameLessThanThreeChars()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "Iv", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongFullNameMessage("The name must be at least 3 symbols");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC6_RegistrationWithTooLongFullName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "TestsTestsTestsTestsTestsTestsTestsTestsTestsTests1", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongFullNameMessage("The field Full Name must be a string with a maximum length of 50.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC7_RegistrationWithNameLessThanThreeChars()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "1van Ivanov", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongFullNameMessage("The field Full Name must start with small or capital letter.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC8_RegistrationWithNameStartingWithNumber()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingFullNameMessage("The Full Name field is required.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC9_RegistrationWithDuplicateFullName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + new Random().Next(100000, 100000000) + "@abv.bg", "Test", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertRegisterWithValidData();
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC10_RegistrationWithShrotPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "Ivan Ivanov", "12345", "12345");


            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongPasswordMessage("Password must be at least 6 symbols");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC11_RegistrationWithTooLongPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "123456789012345678901234567890123456789012345678901", "123456789012345678901234567890123456789012345678901");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongPasswordMessage("The field Password must be a string with a maximum length of 50.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC12_RegistrationWithMissingPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPasswordMessage("The Password field is required.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC13_RegistrationWithMissingPasswordANdConfirmPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "Test", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPasswordMessage("The Password field is required.");
            //registrationPage.AssertUnmatchedPasswordMessage("The password and confirmation password do not match.");
        }


        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC14_RegistrationWithDifferentPasswordAndConfirmPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "654321", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertUnmatchedPasswordMessage("The password and confirmation password do not match.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC15_RegistrationWithEmptyForm()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmptyFormFields("The Email field is required.\r\nThe Full Name field is required.\r\nThe Password field is required.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC16_RegistrationWithMissingEmailAndFullname()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "", "12345", "12345");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmptyFormFields("The Email field is required.\r\nThe Full Name field is required.");
        }
        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC17_RegistrationWithMissingEmailAndPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmptyFormFields("The Email field is required.\r\nThe Password field is required.");
        }
        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC18_RegistrationWithMissingFullnameAndPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmptyFormFields("The Full Name field is required.\r\nThe Password field is required.");
        }

        [Test]
        [Property("Just for checking", 1)]
        public void RegisterWithMissingEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }

        [Test]
        [Property("Just for checking", 1)]
        public void RegisterWithMissingEmailSecond()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "TestTest", "123456", "123456");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }

        [Test]
        [Property("Just for checking", 1)]
        public void RegisterWithMissingEmailThird()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("Test GitHub for Desctop", "TestTC", "testTC", "testTC");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertInvalidEmailMessage("The Email field is not a valid e-mail address.");
        }


        // TEST LOGIN PAGE
        [Test]
        [Property("LoginPage Tests", 1)]
        public void LP_TC1_LoginWithValidData()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            loginPage.AssertLoginWithValidData();
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        public void LP_TC2_LoginWithInvalidEmailFormat()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            loginPage.AssertInvalidEmailMessage("The Email field is not a valid e-mail address.");
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        public void LP_TC3_LoginWithNotRegisteredEmail()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("NoReg@noreg.com", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            loginPage.AssertNotRegisteredEmailMessage("Invalid login attempt.");
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        public void LP_TC4_LoginWithRegisteredEmailAndInvalidPassword()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "123456");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            loginPage.AssertWrongPasswordMessage("Invalid login attempt.");
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        public void LP_TC5_LoginWithoutEmailAndPassword()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("", "");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            loginPage.AssertMissingEmailMessage("The Email field is required.");
            loginPage.AssertMissingPasswordMessage("The Password field is required.");
        }

        // TEST CREATE ARTICLE PAGE
        [Test]
        [Property("CreateArticlePage Tests", 1)]
        public void CAP_TC1_CreateArticleWithValidData()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            var createArticlePage = new CreateArticlePage(driver);
            var articleContent = new CreateArticleContent("Test Automation is the key", "Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            createArticlePage.NavigateTo();
            createArticlePage.FillRegistrationForm(articleContent);

            createArticlePage.AssertRegisterWithValidData();
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        public void CAP_TC2_Cancel_Empty_Article()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);

            var createArticlePage = new CreateArticlePage(driver);
            createArticlePage.NavigateTo();
            createArticlePage.Title.Clear();
            createArticlePage.Content.Clear();
            createArticlePage.CancelArticleButton.Click();
            createArticlePage.AssertRegisterWithValidData();
        }
        [Test]
        [Property("CreateArticlePage Tests", 1)]
        public void CAP_TC3_Create_ArticleWithoutContent()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);
            var createArticlePage = new CreateArticlePage(driver);
            createArticlePage.NavigateTo();
            createArticlePage.Title.Clear();
            createArticlePage.Title.SendKeys("Tralala");
            createArticlePage.Content.Clear();
            createArticlePage.CreateArticleButton.Click();
            createArticlePage.AssertCreateArticleWithoutContent("The Content field is required.");
        }
        [Test]
        [Property("CreateArticlePage Tests", 1)]
        public void CAP_TC4_Create_ArticleWithoutTitle()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);
            var createArticlePage = new CreateArticlePage(driver);
            createArticlePage.NavigateTo();
            createArticlePage.Title.Clear();           
            createArticlePage.Content.Clear();
            createArticlePage.Content.SendKeys("tralala");
            createArticlePage.CreateArticleButton.Click();
            createArticlePage.AssertCreateArticleWithoutTitle("The Title field is required.");
        }

        [Test]
        [Property("CreateArticlePage Tests", 1)]
        public void CAP_TC5_Create_ArticleWithoutTitle_Content()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);
            var createArticlePage = new CreateArticlePage(driver);
            createArticlePage.NavigateTo();
            createArticlePage.Title.Clear();
            createArticlePage.Content.Clear();           
            createArticlePage.CreateArticleButton.Click();
            createArticlePage.AssertCreateArticleWithoutTitle_andContent("The Title field is required.", "The Content field is required.");
        }
        [Test]
        [Property("CreateArticlePage Tests", 1)]
        public void CAP_TC6_Create_ArticlePageDisplayed()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");
            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);
            var createArticlePage = new CreateArticlePage(driver);
            createArticlePage.NavigateTo();
            createArticlePage.AssertCreateArticlePageIsDisplayed("Create Article");          
        }
    }
}
