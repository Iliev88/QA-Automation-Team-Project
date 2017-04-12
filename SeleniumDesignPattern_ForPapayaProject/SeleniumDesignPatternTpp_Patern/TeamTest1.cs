using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumDesignPapaya_Team.Models;
using SeleniumDesignPapaya_Team.Pages.Home_Page;
using SeleniumDesignPapaya_Team.Pages.RegistartionPage;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumDesignPapaya_Team
{
    [TestFixture]
    public class Registration_Form_Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void InitialRuns()
        {
            this.driver = new ChromeDriver();
        }
        [TearDown]
        public void EndOfAllTests()
        {
            this.driver.Quit();
        }

        [Test, Property("Priority", 2)]
        [Author("Todor Peshin")]
        public void Test1()
        {

        }     
    }
}

