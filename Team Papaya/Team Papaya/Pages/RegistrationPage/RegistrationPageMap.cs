using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
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

        public IWebElement LogOffButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("logoutForm"));
            }
        }

        public IWebElement ErrorMessageForMissingEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The Email field is required.']"));
            }
        }

        public IWebElement ErrorMessageForInvalidEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The Email field is not a valid e-mail address.']"));
            }
        }

        public IWebElement ErrorMessageForMissingFullName
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The Full Name field is required.']"));
            }
        }

        public IWebElement ErrorMessageForTooLongFullName
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The field Full Name must be a string with a maximum length of 50.']"));
            }
        }

        public IWebElement ErrorMessageForMissingPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The Password field is required.']"));
            }
        }

        public IWebElement ErrorMessageForUnmatchedPasswords
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The password and confirmation password do not match.']"));
            }
        }

        public IWebElement ErrorMessageForTooLongPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//div[.='The field Password must be a string with a maximum length of 50.']"));
            }
        }

        public IWebElement ErrorMessageForEmptyFormFields
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul"));
            }
        }
        public IWebElement RegisterHeader
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }
    }
}
