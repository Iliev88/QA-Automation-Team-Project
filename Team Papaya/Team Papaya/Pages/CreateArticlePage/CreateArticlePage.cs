using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Papaya.Models;

namespace Team_Papaya.Pages.CreateArticlePage
{
    public partial class CreateArticlePage : BasePage
    {
        public CreateArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(@"http://localhost:60064/Article/Create");
        }

        public void FillRegistrationForm(CreateArticleContent articleContent)
        {
            Type(Title, articleContent.Title);
            Type(Content, articleContent.Content);
            CreateArticleButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(text);
        }
    }
}
