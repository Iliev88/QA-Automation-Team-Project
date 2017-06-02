using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement Header
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("navbar-brand"));
            }
        }

        public IWebElement Footer
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/footer/p"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("registerLink")));
                return this.Driver.FindElement(By.Id("registerLink"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("loginLink")));
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }
    }
}
