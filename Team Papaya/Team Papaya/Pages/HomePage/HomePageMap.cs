using OpenQA.Selenium;
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
                return this.Driver.FindElement(By.Id("registerLink"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }
    }
}
