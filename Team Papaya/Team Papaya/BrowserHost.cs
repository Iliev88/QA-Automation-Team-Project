using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno;
using TestStack.Seleno.Configuration;

namespace Team_Papaya
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl=(@"http://localhost:9999/Article/List");

        static BrowserHost()
        {
            Instance.Run("Blog", 9999, w => w.WithRemoteWebDriver(() => new ChromeDriver()));
        }

        //--for TEAM CITY port must be other!!!--

        //--for CHROME--
        // Instance.Run("Blog", 9999, w => w.WithRemoteWebDriver(() => new ChromeDriver()));

    }
}
