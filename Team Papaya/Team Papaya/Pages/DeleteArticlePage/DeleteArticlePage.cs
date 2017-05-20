using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.DeleteArticlePage
{
    public partial class DeleteArticlePage : BasePage
    {
        public DeleteArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(@"http://localhost:60064/Article/Delete");
        }
    }
}
