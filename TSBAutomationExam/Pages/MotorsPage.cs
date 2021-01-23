using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TSBAutomationExam.Util;

namespace TSBAutomationExam.Pages
{
    public class MotorsPage : BasePage
    {
        public MotorsPage(IWebDriver driver) : base(driver)
        {
        }

        private string strURL = "https://www.tmsandbox.co.nz/motors/";


        private By motorsBy = By.CssSelector("#SiteHeader_SideBar_AttributeSearch_SearchHeader[href='/motors']");
        private By usedCarsBy = By.CssSelector("#SiteHeader_SiteTabs_SubNavMotors_LinkUsedCars");
        private By advanceSearchBy = By.CssSelector("#AdvancedCarSearchLink");
       
        private IWebElement headerMotors => Webdriver.FindElement(motorsBy, 5);
        private IWebElement lnkUsedCars => Webdriver.FindElement(usedCarsBy, 5);
        private IWebElement lnkAdvanceSearch => Webdriver.FindElement(advanceSearchBy, 5);


        public void AccessURL()
        {
            Webdriver.Navigate().GoToUrl(strURL);
            IsPageDisplayed();
        }

        public UsedCarPage NavigateToUsedCarsPage()
        {
            lnkUsedCars.Click();
            return new UsedCarPage(Webdriver);
        }

        public void IsPageDisplayed()
        {
            Assert.IsTrue(strURL.Contains(Webdriver.Url), "Test Failed: URL is not correct.");
            Assert.IsTrue(headerMotors.Displayed, "Test Failed: Motors side Header is not displayed");
        }
    }
}
