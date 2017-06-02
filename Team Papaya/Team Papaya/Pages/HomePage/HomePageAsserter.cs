using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.HomePage
{
    public static class HomePageAsserter
    {
        public static void AssertHomePageHeaderIsDisplayed(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssertHomePageFooterIsDisplayed(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.Footer.Text);
        }
        
        public static void AssertHomePageRegisterButtonIsDisplayed(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.RegisterButton.Text);
        }

        public static void AssertHomePageLoginButtonIsDisplayed(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.LoginButton.Text);
        }
    }
}
