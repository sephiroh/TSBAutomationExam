using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TSBAutomationExam.Util;

namespace TSBAutomationExam.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private string strURL = "https://www.tmsandbox.co.nz/";


        private By tradeMeBy = By.CssSelector("#SiteHeader_SiteTabs_kevin[title='Trade Me - Life lives here']");
        private By motorsBy = By.CssSelector("#SearchTabs1_MotorsLink");

        private IWebElement imgTradeMe => Webdriver.FindElement(tradeMeBy, 5);
        private IWebElement lnkMotors => Webdriver.FindElement(motorsBy, 5);


        public void AccessURL()
        {
            Webdriver.Navigate().GoToUrl(strURL);
            IsPageDisplayed();
        }

        public MotorsPage NavigateToMotorsPage()
        {
            lnkMotors.Click();
            return new MotorsPage(Webdriver);
        }

        public void IsPageDisplayed()
        {
            Assert.IsTrue(strURL.Contains(Webdriver.Url), "Test Failed: URL is not correct.");
            Assert.IsTrue(imgTradeMe.Displayed, "Test Failed: TradeMe Label image is not displayed");
        }
    }
}
