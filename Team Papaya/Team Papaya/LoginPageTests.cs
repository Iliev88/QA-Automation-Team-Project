using NUnit.Framework;
using OpenQA.Selenium;
using Team_Papaya.Models;
using Team_Papaya.Pages.LoginPage;

namespace Team_Papaya
{
    [TestFixture]
    public class LoginPageTests
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
        [Property("LoginPage Tests", 1)]
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
        [Property("LoginPage Tests", 1)]
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
        [Property("LoginPage Tests", 1)]
        [Author("Petar Uzunov")]
        public void LP_TC3_LoginWithNotRegisteredEmail()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("NoReg@noreg.com", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            loginPage.AssertNotRegisteredEmailMessage("Invalid login attempt.");
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        [Author("Petar Uzunov")]
        public void LP_TC4_LoginWithRegisteredEmailAndInvalidPassword()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "123456");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            loginPage.AssertWrongPasswordMessage("Invalid login attempt.");
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        [Author("Petar Uzunov")]
        public void LP_TC5_LoginWithoutEmailAndPassword()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("", "");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            loginPage.AssertMissingEmailMessage("The Email field is required.");
            loginPage.AssertMissingPasswordMessage("The Password field is required.");
        }

        [Test]
        [Property("LoginPage Tests", 1)]
        [Author("Petar Uzunov")]
        public void LP_TC6_LogiOff()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);
            loginPage.LogOffButton.Click();

            loginPage.AssertUserRedirectedToHomePage("Log in");
        }
    }
}
