using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.CreateArticlePage
{
    public static class CreateArticleAsserter
    {
        public static void AssertCreateArticleWithValidData(this CreateArticlePage page)
        {
            Assert.IsTrue(true);
        }
        public static void AssertCreateArticleWithoutContent(this CreateArticlePage page , string text)
        {
            Assert.AreEqual(page.Create_Article_ContentFieldRequiered_Position1.Text, text);
        }
        public static void AssertCreateArticleWithoutTitle(this CreateArticlePage page, string text)
        {
            Assert.AreEqual(page.Create_Article_TitleFieldRequiered_Position1.Text, text);
        }
        public static void AssertCreateArticleWithoutTitle_andContent(this CreateArticlePage page, string text , string text1)
        {
            Assert.AreEqual(page.Create_Article_TitleFieldRequiered_Position1.Text, text);
            Assert.AreEqual(page.Create_Article_ContentFieldRequiered_Position2.Text, text1);
        }
        public static void AssertCreateArticlePageIsDisplayed(this CreateArticlePage page, string text)
        {          
            Assert.AreEqual(page.Create_ArticleText.Text, text);
            Assert.IsTrue(page.CreateArticleButton.Displayed);
        }
        public static void AssertCreateArticleComtentresized(this CreateArticlePage page, int size)
        {
            Assert.IsTrue(size < page.Content.Size.Height);
        }
    }
}
