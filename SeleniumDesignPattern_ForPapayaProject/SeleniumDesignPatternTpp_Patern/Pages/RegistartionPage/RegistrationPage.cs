using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDesignPapaya_Team.Models;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDesignPapaya_Team.Pages.RegistartionPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
            
            this.Driver.Manage().Window.Maximize();
        }

        // FUNCTIONS !!!!!!!!!!!!!!!

       
    }
}
