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

        public IWebElement LogOffButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a"));
            }
        }

        public IWebElement HomePageLoginButtonVisible
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }

        public IWebElement ErrorMessageForMissingEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }

        public IWebElement ErrorMessageForInvalidEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }

        public IWebElement ErrorMessageForNonRegisteredEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageForWrongPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageForMissingPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span"));
            }
        }
    }
}
