using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertMissingEmailMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForMissingEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForMissingEmail.Text);
        }
    }
}
