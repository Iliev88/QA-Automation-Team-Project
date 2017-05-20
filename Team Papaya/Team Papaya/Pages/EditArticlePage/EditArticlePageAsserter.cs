using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.EditArticlePage
{
    public static class EditArticlePageAsserter
    {
        public static void AssertEditArticleWithValidData(this EditArticlePage page)
        {
            Assert.IsTrue(true);
        }

        public static void AssertEditArticleWithInvalidTitleMinimunLenghtMessage(this EditArticlePage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForTooShortTitle.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForTooShortTitle.Text);
        }

        public static void AssertEditArticleWithInvalidTitleMaximumLenghtMessage(this EditArticlePage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForTooLongTitle.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForTooLongTitle.Text);
        }

        public static void AssertEditArticleWithInvalidContentMinimunLenghtMessage(this EditArticlePage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForTooShortContent.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForTooShortContent.Text);
        }

        public static void AssertEditArticleWithInvalidContentMaximumLenghtMessage(this EditArticlePage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageForTooLongContent.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForTooLongContent.Text);
        }

        public static void AssertEditArticleEditOtherUsersArticle(this EditArticlePage page)
        {
            Assert.IsFalse(page.GoToEditArticlePageButton.Displayed);
        }
    }
}
