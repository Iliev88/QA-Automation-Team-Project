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
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
        
        // SOME ELEMENTARY TESTS FOR HOMEPAGE
        // MUST THINK HOW EVERYONE COULD NAVIGATE TO THE BLOG
        [Test]
        public void HomePageHeaderTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageHeaderIsDisplayed("SOFTUNI BLOG");
        }

        [Test]
        public void HomePageFooterTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageFooterIsDisplayed("© 2017 - SoftUni Blog");
        }

        [Test]
        public void HomePageRegisterButtonTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageRegisterButtonIsDisplayed("Register");
        }

        [Test]
        public void HomePageLoginrButtonTest()
        {
            var homePage = new HomePage(driver);

            homePage.NavigateTo();

            homePage.AssertHomePageLoginButtonIsDisplayed("Log in");
        }

        // TEST REGISTRATION PAGE
        [Test]
        public void RegisterWithMissingEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "1234", "1234");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingEmailMessage("The Email field is required.");
        }
    }
}
