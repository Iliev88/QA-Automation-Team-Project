using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Team_Papaya.Models;

namespace Team_Papaya.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "Account/Register";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60064/account/register");
        }

        public void FillRegistrationForm(RegisterUser user)
        {
            Type(Email, user.Email);
            Type(FullName, user.FullName);
            Type(Password, user.Password);
            Type(ConfirmPassword, user.ConfirmPassword);
            RegisterButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(text);
        }
    }
}
