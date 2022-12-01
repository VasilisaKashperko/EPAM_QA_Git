using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace QAForEpamLab10
{
    public class Tests
    {
        private WebDriver driver { get; set; } = null!;

        private string driverPath { get; set; } = @"D:\\WebDriverChrome\\chromedriver.exe";

        private string helloFromWebDriver = "Hello from WebDriver";
        private string helloweb = "helloweb";
        private string gitConfigEtc = "git config --global user.name  \"New Sheriff in Town\"" +
                                    "\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") " +
                                    "\ngit push origin master --force";
        private string howToGain = "how to gain dominance among developers";

        private WebDriver GetChromeDriver()
        {
            return new ChromeDriver(driverPath, new ChromeOptions());
        }

        [SetUp]
        public void SetUp()
        {
            driver = GetChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        public void PasteBin()
        {
            driver.Navigate().GoToUrl("https://pastebin.com");
        }

        public void HotelsCombined()
        {
            driver.Navigate().GoToUrl("https://www.hotelscombined.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ICanWin()
        {
            var pastebinPage = new PageObject(driver);
            PasteBin();
            pastebinPage.ICanWin(helloFromWebDriver, helloweb);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            TearDown();
        }

        [Test]
        public void BringItOn()
        {
            var pastebinPage = new PageObject(driver);
            PasteBin();
            pastebinPage.BringItOn(gitConfigEtc, howToGain);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TearDown();
        }

        [Test]
        public void SearchForHotels()
        {
            var hotelscombinedPage = new PageObject(driver);
            HotelsCombined();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            hotelscombinedPage.SearchForHotels();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Assert.AreEqual("https://www.hotelscombined.com/Place/Switzerland.htm", driver.Url);
            TearDown();
        }

        [Test]
        public void BrowseHotelsByLocationFiveRatesWithAPool()
        {
            var hotelscombinedPage = new PageObject(driver);
            HotelsCombined();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            hotelscombinedPage.BrowseHotelsByLocationFiveRatesWithAPool();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            TearDown();
        }
    }
}