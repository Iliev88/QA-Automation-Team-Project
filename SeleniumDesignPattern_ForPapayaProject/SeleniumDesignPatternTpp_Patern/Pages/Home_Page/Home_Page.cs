using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPapaya_Team.Pages.Home_Page
{
   public class Home_Page : BasePage
    {
       
        public Home_Page(IWebDriver driver)
            :base(driver)
        {         
        }

        public void Navigate()
        {
            this.Driver.Navigate().GoToUrl("http://www.demoqa.com");
        }
    }
}
