using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Team_Papaya.Models;
using Team_Papaya.Pages.RegistrationPage;

namespace Team_Papaya
{
    [TestFixture]
    public class RegistrationPageTests
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
        [Property("RegistrationPage Tests", 1)]
        [Author("Hristo Bahnev")]
        public void RP_TC0_RegisterButtonTest()
        {
            var registrationPage = new RegistrationPage(driver);

            registrationPage.NavigateTo();

            registrationPage.AssertRegistrationPageRegisterHeaderIsDisplayed("Register");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
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
        [Property("RegistrationPage Tests", 1)]
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
        [Property("RegistrationPage Tests", 1)]
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
        [Property("RegistrationPage Tests", 1)]
        [Author("Iliya Iliev")]
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
        [Author("Iliya Iliev")]
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
        [Author("Iliya Iliev")]
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
        [Author("Hristo Bahnev")]
        public void RP_TC7_RegistrationWithMissingFullnameAndPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmptyFormFields("The Full Name field is required.\r\nThe Password field is required.");
        }
        [Test]
        [Property("RegistrationPage Tests", 1)]
        [Author("Iliya Iliev")]
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
        [Author("Iliya Iliev")]
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
        [Author("Iliya Iliev")]
        public void RP_TC10_RegistrationWithShortPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "Ivan Ivanov", "12345", "12345");


            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertTooLongPasswordMessage("Password must be at least 6 symbols");
        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        [Author("Iliya Iliev")]
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
        [Author("Hristo Bahnev")]
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
        [Author("Hristo Bahnev")]
        public void RP_TC13_RegistrationWithMissingPasswordANdConfirmPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("test" + DateTime.Now.Millisecond + "@test.com", "Test", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPasswordMessage("The Password field is required.");

        }

        [Test]
        [Property("RegistrationPage Tests", 1)]
        [Author("Hristo Bahnev")]
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
        [Author("Hristo Bahnev")]
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
        [Author("Hristo Bahnev")]
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
        [Author("Hristo Bahnev")]
        public void RP_TC17_RegistrationWithMissingEmailAndPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegisterUser("", "Test", "", "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmptyFormFields("The Email field is required.\r\nThe Password field is required.");
        }


    }
}
