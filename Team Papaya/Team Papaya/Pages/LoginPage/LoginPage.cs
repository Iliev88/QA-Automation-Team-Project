using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Papaya.Models;

namespace Team_Papaya.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(@"http://localhost:60064/Account/Login");
        }

        public void FillRegistrationForm(LoginUser user)
        {
            Type(Email, user.Email);
            Type(Password, user.Password);
            LoginButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(text);
        }
    }
}
