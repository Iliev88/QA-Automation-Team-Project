using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.CreateArticlePage
{
    public partial class CreateArticlePage
    {
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

        public IWebElement CreateArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement CancelArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));
            }
        }

        public IWebElement ArticleIsCreated
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("Test Automation is the key")));
                return this.Driver.FindElement(By.LinkText("Test Automation is the key"));
            }
        }

        public IWebElement Create_ArticleText
        {
            get
            {                                            
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/h2"));
            }
        }
        public IWebElement Create_Article_ContentFieldRequiered_Position1
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
        public IWebElement Create_Article_TitleFieldRequiered_Position1
        { 
            get
            {                                             
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
        public IWebElement Create_Article_ContentFieldRequiered_Position2
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]"));
            }
        }
    }
}
