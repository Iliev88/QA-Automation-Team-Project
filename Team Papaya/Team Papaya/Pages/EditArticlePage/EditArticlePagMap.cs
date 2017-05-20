using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.EditArticlePage
{
    public partial class EditArticlePage
    {
        public IWebElement OpenUserArticle
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Test Automation is the key")));
                return this.Driver.FindElement(By.LinkText("Test Automation is the key"));
            }
        }

        public IWebElement GoToEditArticlePageButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));
            }
        }

        public IWebElement Title
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Title")));
                return this.Driver.FindElement(By.Id("Title"));
            }
        }

        public IWebElement Content
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.Id("Content")));
                return this.Driver.FindElement(By.Id("Content"));
            }
        }

        public IWebElement EditArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement CancelEditArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));
            }
        }

        public IWebElement ErrorMessageForTooShortTitle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageForTooLongTitle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageForTooShortContent
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageForTooLongContent
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
    }
}
