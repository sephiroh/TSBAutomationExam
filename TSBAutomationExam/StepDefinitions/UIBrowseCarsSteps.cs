using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System;
using System.IO;
using OpenQA.Selenium;
using TSBAutomationExam.Util;
using TSBAutomationExam.Pages;
using TSBAutomationExam.DataObjects;

namespace TSBAutomationExam.StepDefinitions
{
    [Scope(Tag = "UI")]
    [Binding]
    public class UIBrowseCarsSteps
    {
        public IWebDriver driver;
        public WebBrowser browser = WebBrowser.Chrome;
        public static BasePage currentPage;

        [BeforeScenario]
        public void InitializeBrowser()
        {
            driver = WebDriverFactory.CreateWebDriver(browser);
            if (browser != WebBrowser.Chrome)
                driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            currentPage.Close();
        }

        [AfterTestRun]
        public static void Cleanup()
        {
            currentPage.Quit();
        }


        [Given(@"I navigated to the TradeMe website")]
        public void GivenINavigatedToTheTradeMeWebsite()
        {
            currentPage = new HomePage(driver);
            currentPage.As<HomePage>().AccessURL();
        }

        [When(@"I browse thru the Motors page")]
        public void WhenIBrowseThruTheMotorsPage()
        {
            currentPage = currentPage.As<HomePage>().NavigateToMotorsPage();
            currentPage.As<MotorsPage>().IsPageDisplayed();
        }

        [When(@"I look for Used Cars")]
        public void WhenILookForUsedCars()
        {
            currentPage = currentPage.As<MotorsPage>().NavigateToUsedCarsPage();
            currentPage.As<UsedCarPage>().IsPageDisplayed();
        }

        [Then(@"I can see there is at least one listing display")]
        public void ThenICanSeeThereIsAtLeastOneListingDisplay()
        {
            currentPage.As<UsedCarPage>().IsThereAListingDisplayed();
        }

        [Then(@"I can see the Make (.*) exists")]
        public void ThenICanSeeTheMakeKiaExists(string carMake)
        {
            currentPage.As<UsedCarPage>().IsCarMakeDisplayed(carMake);
        }

        [When(@"I select the (.*) (.*) (.*) car from the listing")]
        public void WhenISelectACarFromTheListing(string year, string make, string model)
        {
            currentPage.As<UsedCarPage>().SelectCarInListing(year, make, model);
        }

        [Then(@"I can see the Car (.*) (.*) (.*) Details is correct")]
        public void ThenICanSeeTheCarDetailsIsCorrect(string year, string make, string model)
        {
            string carName = $"{year} {make} {model}";
            CarDO carDetails = Utilities.GetCarDetails(carName);
            currentPage.As<UsedCarPage>().IsCarDetailsCorrect(carDetails);
        }

    }
}
