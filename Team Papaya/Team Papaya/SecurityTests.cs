using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Papaya.Models;
using Team_Papaya.Pages.BlogCreate;
using Team_Papaya.Pages.LoginPage;
using Team_Papaya.Pages.RegistrationPage;

namespace Team_Papaya
{
    class SecurityTests
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
        [Property("RegistrationPage Tests", 2)]
        public void RP_TC0_Register_100Users()
        {
            var registrationPage = new RegistrationPage(driver);
            char k = 'a';

            for (char j = k; j < k + 10; j++)
            {
                var user = new RegisterUser("test@abv.bg", "Test" + j, "123456", "123456");
                registrationPage.NavigateTo();
                registrationPage.FillRegistrationForm(user);
            }
        }


        [Test]
        [Property("RegistrationPage Tests", 2)]
        public void BL_TC0_Create100Posts()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillRegistrationForm(user);
            loginPage.AssertLoginWithValidData();

            var BlogCreatePage = new BlogCreate(driver);
            char a = 'a';
            for (char j=a; j<a+10;j++)
            {
                BlogCreatePage.NavigateTo();
                BlogCreatePage.Title.SendKeys("abv" + j);
                BlogCreatePage.Content.SendKeys("abv" + j);
                BlogCreatePage.ButtonCreate.Click();
            }
        }
    }
}
