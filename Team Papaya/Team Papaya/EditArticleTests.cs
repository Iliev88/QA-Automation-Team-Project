using NUnit.Framework;
using OpenQA.Selenium;
using Team_Papaya.Models;
using Team_Papaya.Pages.EditArticlePage;
using Team_Papaya.Pages.LoginPage;

namespace Team_Papaya
{
    [TestFixture]
    public class EditArticleTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = BrowserHost.Instance.Application.Browser;

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            // This is for TeamCity to build...
            //driver.Quit();
        }
        
        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC1_EditOwnArticleWithValidData()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);
            var articleContent = new EditArticleContent("This article has been Edited", "This article has been Edited. The original content of the article was starting with: Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();
            editArticlePage.FillEditArticleForm(articleContent);

            editArticlePage.AssertEditArticleWithValidData("This article has been Edited");
        }

        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC2_EditOwnArticleWithInvalidTitleMinimumLength()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);
            var articleContent = new EditArticleContent("Edit", "This article has been Edited. The original content of the article was starting with: Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();
            editArticlePage.FillEditArticleForm(articleContent);

            editArticlePage.AssertEditArticleWithInvalidTitleMinimunLenghtMessage("The field Title must be a string with a minimum length of 5.");
        }

        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC3_EditOwnArticleWithInvalidTitleMaximumLength()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);
            var articleContent = new EditArticleContent("Edited title with more that 50 characters.Edited title with more that 50 characters.", "This article has been Edited. The original content of the article was starting with: Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();
            editArticlePage.FillEditArticleForm(articleContent);

            editArticlePage.AssertEditArticleWithInvalidTitleMaximumLenghtMessage("The field Title must be a string with a maximum length of 50.");
        }

        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC4_EditOwnArticleWithInvalidContentMinimumLength()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);
            var articleContent = new EditArticleContent("This article has been Edited", "The article content has been edited with less than 100 characters.");

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();
            editArticlePage.FillEditArticleForm(articleContent);

            editArticlePage.AssertEditArticleWithInvalidContentMinimunLenghtMessage("The field Content must be a string with a minimum length of 100.");
        }

        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC5_EditOwnArticleWithInvalidContentMaximumLength()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);
            var articleContent = new EditArticleContent("This article has been Edited", "The article content has been edited with more than 100 characters. Преди изключително обширното разделение на труда и механизацията е било възможно самите работещи да контролират качеството на техните собствени продукти. Например през Средните векове гилдиите (в България еснафските съюзи през Възраждането и по-късно гилдиите след Освобождението) възприемат отговорността за контрол над качеството на техните членове, установявайки и поддържайки определени стандарти за членство.Разделението на труда и механизацията на производството, благодарение най - вече на индустриалната революция, увеличават силно брутния вътрешен продукт в световен мащаб.Създалата се конкуренция на новосформиралите се стокови пазари и нарастващо потребителско търсене, принуждават производствените предприятия да обърнат внимание на качеството на своята продукция.Новата система на производство в която все повече хора се специализират в дадена област, води до създаване на нови професии и необходимост от контрол на произведените стоки и услуги.По този начин възниква професия свързана с обезпечение на качеството в производствените процеси.По време на двете световни войни, индустриално развитите държави въвлечени пряко в конфликтните точки на света, увеличават човешкия капитал в своите производствени центрове.Този период характерен с масово производство и работници на надница, сформира нарастването на негодната продукция след производствения цикъл.Проблемът който възниква, води до назначаване на нови инспектори на пълен работен ден, които имат нужните правомощия да откриват и коригират нарастващите дефекти.Промишленото производство в САЩ през 20 - те години на XX век е предимно серийно и масово.Американският учен Уилям Шухард въвежда нов подход в методите по обезпечение на качеството - статистически контрол на качеството.Основата на която се осланя SQC е свързана със използване на два характерни инструмента: системни проби и създаване на тестови извадки.След втората световна война интересът към статистическите методи нараства.В САЩ учените работят върху подобряването му, а в Европа се дискутират начинът на формиране и обем на пробите.През 50 - те години на XX век е издигната концепцията за тотално управление на качеството, чийто автор е американският учен Арманд Фейгенбаум, мениджър във фирма General Electric През 1961 г.Фейгенбаум публикува труда си Total Quality Control.Тази система се развива в Япония с акцент върху статистическите методи, които са известни на японците още по време на втората световна война.След войната Япония е разрушена, американският генерал Дъглас Макартър надзирава нейното реконструиране.Уилям Едуардс Деминг и Джоузеф Джуран, ръководени от Макартър прилагат натрупания американски опит и принципи за качество върху набиращата скорост японска икономика.Един от активните последователи е Каору Ишикава, с дейността на който се свързва японското чудоПреди изключително обширното разделение на труда и механизацията е било възможно самите работещи да контролират качеството на техните собствени продукти.Например през Средните векове гилдиите(в България еснафските съюзи през Възраждането и по - късно гилдиите след Освобождението) възприемат отговорността за контрол над качеството на техните членове, установявайки и поддържайки определени стандарти за членство.Разделението на труда и механизацията на производството, благодарение най - вече на индустриалната революция, увеличават силно брутния вътрешен продукт в световен мащаб.Създалата се конкуренция на новосформиралите се стокови пазари и нарастващо потребителско търсене, принуждават производствените предприятия да обърнат внимание на качеството на своята продукция.Новата система на производство в която все повече хора се специализират в дадена област, води до създаване на нови професии и необходимост от контрол на произведените стоки и услуги.По този начин възниква професия свързана с обезпечение на качеството в производствените процеси.По време на двете световни войни, индустриално развитите държави въвлечени пряко в конфликтните точки на света, увеличават човешкия капитал в своите производствени центрове.Този период характерен с масово производство и работници на надница, сформира нарастването на негодната продукция след производствения цикъл.Проблемът който възниква, води до назначаване на нови инспектори на пълен работен ден, които имат нужните правомощия да откриват и коригират нарастващите дефекти.Промишленото производство в САЩ през 20 - те години на XX век е предимно серийно и масово.Американският учен Уилям Шухард въвежда нов подход в методите по обезпечение на качеството - статистически контрол на качеството.Основата на която се осланя SQC е свързана със използване на два характерни инструмента: системни проби и създаване на тестови извадки.След втората световна война интересът към статистическите методи нараства.В САЩ учените работят върху подобряването му, а в Европа се дискутират начинът на формиране и обем на пробите.През 50 - те години на XX век е издигната концепцията за тотално управление на качеството, чийто автор е американският учен Арманд Фейгенбаум, мениджър във фирма General Electric През 1961 г.Фейгенбаум публикува труда си Total Quality Control.Тази система се развива в Япония с акцент върху статистическите методи, които са известни на японците още по време на втората световна война.След войната Япония е разрушена, американският генерал Дъглас Макартър надзирава нейното реконструиране.Уилям Едуардс Деминг и Джоузеф Джуран, ръководени от Макартър прилагат натрупания американски опит и принципи за качество върху набиращата скорост японска икономика.Един от активните последователи е Каору Ишикава, с дейността на който се свързва японското чудоПреди изключително обширното разделение на труда и механизацията е било възможно самите работещи да контролират качеството на техните собствени продукти.Например през Средните векове гилдиите(в България еснафските съюзи през Възраждането и по - късно гилдиите след Освобождението) възприемат отговорността за контрол над качеството на техните членове, установявайки и поддържайки определени стандарти за членство.Разделението на труда и механизацията на производството, благодарение най - вече на индустриалната революция, увеличават силно брутния вътрешен продукт в световен мащаб.Създалата се конкуренция на новосформиралите се стокови пазари и нарастващо потребителско търсене, принуждават производствените предприятия да обърнат внимание на качеството на своята продукция.Новата система на производство в която все повече хора се специализират в дадена област, води до създаване на нови професии и необходимост от контрол на произведените стоки и услуги.По този начин възниква професия свързана с обезпечение на качеството в производствените процеси.По време на двете световни войни, индустриално развитите държави въвлечени пряко в конфликтните точки на света, увеличават човешкия капитал в своите производствени центрове.Този период характерен с масово производство и работници на надница, сформира нарастването на негодната продукция след производствения цикъл.Проблемът който възниква, води до назначаване на нови инспектори на пълен работен ден, които имат нужните правомощия да откриват и коригират нарастващите дефекти.Промишленото производство в САЩ през 20 - те години на XX век е предимно серийно и масово.Американският учен Уилям Шухард въвежда нов подход в методите по обезпечение на качеството - статистически контрол на качеството.Основата на която се осланя SQC е свързана със използване на два характерни инструмента: системни проби и създаване на тестови извадки.След втората световна война интересът към статистическите методи нараства.В САЩ учените работят върху подобряването му, а в Европа се дискутират начинът на формиране и обем на пробите.През 50 - те години на XX век е издигната концепцията за тотално управление на качеството, чийто автор е американският учен Арманд Фейгенбаум, мениджър във фирма General Electric През 1961 г.Фейгенбаум публикува труда си Total Quality Control.Тази система се развива в Япония с акцент върху статистическите методи, които са известни на японците още по време на втората световна война.След войната Япония е разрушена, американският генерал Дъглас Макартър надзирава нейното реконструиране.Уилям Едуардс Деминг и Джоузеф Джуран, ръководени от Макартър прилагат натрупания американски опит и принципи за качество върху набиращата скорост японска икономика.Един от активните последователи е Каору Ишикава, с дейността на който се свързва японското чудоПреди изключително обширното разделение на труда и механизацията е било възможно самите работещи да контролират качеството на техните собствени продукти.Например през Средните векове гилдиите(в България еснафските съюзи през Възраждането и по - късно гилдиите след Освобождението) възприемат отговорността за контрол над качеството на техните членове, установявайки и поддържайки определени стандарти за членство.Разделението на труда и механизацията на производството, благодарение най - вече на индустриалната революция, увеличават силно брутния вътрешен продукт в световен мащаб.Създалата се конкуренция на новосформиралите се стокови пазари и нарастващо потребителско търсене, принуждават производствените предприятия да обърнат внимание на качеството на своята продукция.Новата система на производство в която все повече хора се специализират в дадена област, води до създаване на нови професии и необходимост от контрол на произведените стоки и услуги.По този начин възниква професия свързана с обезпечение на качеството в производствените прПо време на двете световни войни, индустриално развитите държави въвлечени пряко в конфликтните точки на света, увеличават човешкия капитал в своите производствени центрове.Този период характерен с масово производство и работници на надница, сформира нарастването на негодната продукция след производствения цикъл.Проблемът който възниква, води до назначаване на нови инспектори на пълен работен ден, които имат нужните правомощия да откриват и коригират нарастващите дефекти.Промишленото производство в САЩ през 20 - те години на XX век е предимно серийно и масово.Американският учен Уилям Шухард въвежда нов подход в методите по обезпечение на качеството - статистически контрол на качеството.Основата на която се осланя SQC е свързана със използване на два характерни инструмента: системни проби и създаване на тестови извадки.След втората световна война интересът към статистическите методи нараства.В САЩ учените работят върху подобряването му, а в Европа се дискутират начинът на формиране и обем на пробите.През 50 - те години на XX век е издигната концепцията за тотално управление на качеството, чийто автор е американският учен Арманд Фейгенбаум, мениджър във фирма General Electric През 1961 г.Фейгенбаум публикува труда си Total Quality Control.Тази система се развива в Япония с акцент върху статистическите методи, които са известни на японците още по време на втората световна война.След войната Япония е разрушена, американският генерал Дъглас Макартър надзирава нейното реконструиране.Уилям Едуардс Деминг и Джоузеф Джуран, ръководени от Макартър прилагат натрупания американски опит и принципи за качество върху набиращата скорост японска икономика.Един от активните последователи е Каору Ишикава, с дейността на който се свързва японското чудо");

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();
            editArticlePage.FillEditArticleForm(articleContent);

            editArticlePage.AssertEditArticleWithInvalidContentMaximumLenghtMessage("The field Content must be a string with a maximum length of 10 000. ");
        }

        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC6_EditOtherusersArticle()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("test@abv.bg", "1234");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();

            editArticlePage.AssertEditArticleEditOtherUsersArticle();
        }

        [Test]
        [Property("EditArticlePage Tests", 1)]
        [Author("Petar Uzunov")]
        public void EAP_TC7_EditArticleWithValidDataAndAdminUser()
        {
            var loginPage = new LoginPage(driver);
            var user = new LoginUser("admin@admin.com", "123");

            loginPage.NavigateTo();
            loginPage.FillLoginForm(user);

            var editArticlePage = new EditArticlePage(driver);
            var articleContent = new EditArticleContent("This article has been Edited", "This article has been Edited. The original content of the article was starting with: Traditional quality assurance has become a bottleneck in the development process and the advancement of test automation. Innovative development teams ...");

            editArticlePage.NavigateTo();
            editArticlePage.OpenUserArticle.Click();
            editArticlePage.FillEditArticleForm(articleContent);

            editArticlePage.AssertEditArticleWithValidData("This article has been Edited");
        }
    }
}
