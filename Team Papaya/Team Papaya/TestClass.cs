using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Papaya.Models;
using Team_Papaya.Pages.HomePage;
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
        public void RP_TC1_RegistrationWithValidData()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + new Random().Next(100000, 100000000) + "@abv.bg", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertRegisterWithValidData();
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC2_RegistrationWithInvalidEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@.abv.bg", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertInvalidEmailMessage("The Email field is not a valid e-mail address.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC4_RegistrationWithEmptyEmailField()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC6_RegistrationWithTooLongFullName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "TestsTestsTestsTestsTestsTestsTestsTestsTestsTests1", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongFullNameMessage("The field Full Name must be a string with a maximum length of 50.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC8_RegistrationWithEmptyFullNameField()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingFullNameMessage("The Full Name field is required.");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        public void RP_TC9_RegistrationWithDuplicateFullName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + new Random().Next(100000, 100000000) + "@abv.bg", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertRegisterWithValidData();
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
        public void RP_TC14_RegistrationWithDifferentPasswordAndConfirmPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test@abv.bg", "Test", "4321", "1234");

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
        [Property("Just for checking", 1)]
        public void RegisterWithMissingEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }

        [Test]
        [Property("Just for checking", 1)]
        public void RegisterWithMissingEmailSecond()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "TestTest", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }
    }
}
