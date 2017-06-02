using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.DeleteArticlePage
{
    public static class DeleteArticlePageAsserter
    {
        public static void AssertUserOwnArticleIsDelted(this DeleteArticlePage page)
        {
            Assert.IsTrue(page.ArticleIsDeleted.Displayed);
        }
    }
}
