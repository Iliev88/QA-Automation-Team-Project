using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.DeleteArticlePage
{
    public partial class DeleteArticlePage
    {
        public IWebElement OpenUserArticle
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.LinkText("This article has been Edited")));
                return this.Driver.FindElement(By.LinkText("This article has been Edited"));
            }
        }

        public IWebElement GoToDeleteArticlePageButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]"));
            }
        }

        public IWebElement DeleteArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input"));
            }
        }

        public IWebElement CancelDeleteArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/a"));
            }
        }

        public IWebElement ArticleIsDeleted
        {
            get
            {
                return this.Driver.FindElement(By.LinkText("This article has been Edited"));
            }
        }
    }
}
