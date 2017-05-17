using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Pages.BlogCreate
{
  public partial  class BlogCreate: BasePage
    {
        public BlogCreate(IWebDriver driver) : base(driver)
        {
        }
        public string URL
        {
            get
            {
                return base.url + "Article/Create";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

    }
}
