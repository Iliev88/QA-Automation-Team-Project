using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team_Papaya.Models;

namespace Team_Papaya.Pages.EditArticlePage
{
    public partial class EditArticlePage : BasePage
    {
        public EditArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(@"http://localhost:60064/Article/Edit");
        }

        public void FillRegistrationForm(EditArticleContent articleContent)
        {
            Type(Title, articleContent.Title);
            Type(Content, articleContent.Content);
            EditArticleButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(text);
        }
    }
}
