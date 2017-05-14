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
        public static void AssertRegisterWithValidData(this LoginPage page)
        {
            Assert.IsTrue(page.LogOff.Displayed);
        }
    }
}
