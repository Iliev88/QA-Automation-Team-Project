using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement Heading
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement FullName
        {
            get
            {
                return this.Driver.FindElement(By.Id("FullName"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input"));
            }
        }

        public IWebElement ErrorMessageForMissingEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageForInvalidEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        // XPATHS ARE THE SAME FOR EVERY MESSAGE
        // IF THE MESSAGES ARE MORE THAN ONE THE XPATHS DIFFERS ONLY BY [NUMBER] AT THE END
        // //html/body/div[2]/div/div/form/div[1]/ul/li[1]
        // //html/body/div[2]/div/div/form/div[1]/ul/li[2]
        // //html/body/div[2]/div/div/form/div[1]/ul/li[3]
        // //html/body/div[2]/div/div/form/div[1]/ul/li[4]
        public IWebElement ErrorMessageForMissingFullName
        {
            get
            { 
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
    }
}
