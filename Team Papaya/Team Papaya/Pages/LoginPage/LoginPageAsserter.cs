using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.LoginPage
{
    public static class LoginPageAsserter
    {
        public static void AssertLoginWithValidData(this LoginPage page)
        {
            Assert.IsTrue(page.LogOffButton.Displayed);
        }

        public static void AssertMissingEmailMessage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMissingEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForMissingEmail.Text);
        }

        public static void AssertInvalidEmailMessage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForInvalidEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForInvalidEmail.Text);
        }

        public static void AssertNotRegisteredEmailMessage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForNonRegisteredEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForNonRegisteredEmail.Text);
        }

        public static void AssertMissingPasswordMessage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMissingPassword.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForMissingPassword.Text);
        }

        public static void AssertWrongPasswordMessage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForWrongPassword.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForWrongPassword.Text);
        }

        public static void AssertUserRedirectedToHomePage(this LoginPage page, string text)
        {
            Assert.IsTrue(page.HomePageLoginButtonVisible.Displayed);
            Assert.AreEqual(text, page.HomePageLoginButtonVisible.Text);
        }
    }
}
