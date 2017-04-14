using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Team_Papaya.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return wait;
            }
        }
    }
}
