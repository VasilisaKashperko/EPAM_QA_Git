using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace QAForEpamLab10
{
    class PageObject
    {
        public WebDriver driver;

        public PageObject(WebDriver driver)
        {
            this.driver = driver;
        }

        #region [ICanWin]
        private WebElement postformText => (WebElement)driver.FindElement(By.Id("postform-text"));
        private WebElement expirationContainer => (WebElement)driver.FindElement(By.Id("select2-postform-expiration-container"));
        private WebElement expirationChoice10Minutes => (WebElement)driver.FindElement(By.XPath("//li[text()='10 Minutes']"));
        private WebElement postformName => (WebElement)driver.FindElement(By.Id("postform-name"));
        private WebElement sendButton => (WebElement)driver.FindElement(By.XPath("//button[@class='btn -big']"));
        #endregion

        #region [BringItOn]
        private WebElement formatContainer => (WebElement)driver.FindElement(By.Id("select2-postform-format-container"));
        private WebElement formatChoiceBash => (WebElement)driver.FindElement(By.XPath("//li[text()='Bash']"));
        #endregion

        #region [SearchForHotels]
        private WebElement browseHotelsByLocation => (WebElement)driver.FindElement(By.XPath("//a[text()='Browse Hotels By Location']"));
        private WebElement choiceSwitzerland => (WebElement)driver.FindElement(By.XPath("//a[text()='Switzerland']"));
        #endregion

        #region [BrowseHotelsByLocationFiveRatesWithAPool]
        private WebElement choiceBelgium => (WebElement)driver.FindElement(By.XPath("//a[text()='Belgium']"));
        private WebElement choiceFiveStars => (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/section/div/div/div[1]/div[2]/div/div/div[1]/span/span/input"));
        private WebElement rollupAmenities => (WebElement)driver.FindElement(By.CssSelector(".Qk4D:nth-child(10) .Qk4D-filter-title"));
        private WebElement rollup18More => (WebElement)driver.FindElement(By.CssSelector(".p6Cx-filter-section-list-toggle:nth-child(2)"));
        private WebElement choiceSwimmingPool => (WebElement)driver.FindElement(By.Id("valueSetFilter-pool"));
        #endregion

        public PageObject ICanWin(string helloFromWebDriver, string helloweb)
        {
            postformText.SendKeys(helloFromWebDriver);
            expirationContainer.Click();
            expirationChoice10Minutes.Click();
            postformName.SendKeys(helloweb);
            sendButton.Click();
            return new PageObject(driver);
        }

        public PageObject BringItOn(string gitConfigEtc, string howToGain)
        {
            postformText.SendKeys(gitConfigEtc);
            formatContainer.Click();
            formatChoiceBash.Click();
            expirationContainer.Click();
            expirationChoice10Minutes.Click();
            postformName.SendKeys(howToGain);
            sendButton.Click();
            return new PageObject(driver);
        }

        public PageObject SearchForHotels()
        {
            browseHotelsByLocation.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            choiceSwitzerland.Click();
            return new PageObject(driver);
        }

        public PageObject BrowseHotelsByLocationFiveRatesWithAPool()
        {
            browseHotelsByLocation.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            choiceBelgium.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            choiceFiveStars.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Thread.Sleep(20000);
            rollupAmenities.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            rollup18More.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            choiceSwimmingPool.Click();
            return new PageObject(driver);
        }
    }
}
