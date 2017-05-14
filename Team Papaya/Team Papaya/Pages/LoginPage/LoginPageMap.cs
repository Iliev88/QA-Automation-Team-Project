using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.LoginPage
{
    public partial class LoginPage
    {
        public IWebElement Email
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
                return this.Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));

            }
        }

        public IWebElement LogOff
        {
            get
            {
                return this.Driver.FindElement(By.Id("logoutForm"));
            }
        }
    }
}
