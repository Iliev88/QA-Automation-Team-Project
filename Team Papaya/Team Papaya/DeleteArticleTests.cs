﻿using NUnit.Framework;
using OpenQA.Selenium;
using Team_Papaya.Models;
using Team_Papaya.Pages.DeleteArticlePage;
using Team_Papaya.Pages.LoginPage;

namespace Team_Papaya
{
    [TestFixture]
    public class DeleteArticleTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = BrowserHost.Instance.Application.Browser;

            driver.Manage().Window.Maximize();
            
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);
        }

        [TearDown]
        public void CleanUp()
        {
            // This is for TeamCity to build...
            //driver.Quit();
        }

        
        [Test]
        [Property("DeleteArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void DAP_TC1_DeleteOwnArticle()
        {
            var deleteArticlePage = new DeleteArticlePage(driver);

            deleteArticlePage.NavigateTo();
            deleteArticlePage.OpenUserArticle.Click();
            deleteArticlePage.GoToDeleteArticlePageButton.Click();
            deleteArticlePage.DeleteArticleButton.Click();

            deleteArticlePage.AssertUserOwnArticleIsDelted();
        }
    }
}
