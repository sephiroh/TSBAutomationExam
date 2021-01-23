using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TSBAutomationExam.DataObjects;
using TSBAutomationExam.Util;

namespace TSBAutomationExam.Pages
{
    public class UsedCarPage : BasePage
    {
        public UsedCarPage(IWebDriver driver) : base(driver)
        {
        }

        private string strURL = "https://www.tmsandbox.co.nz/motors/used-cars/";

        private By usedCarsBy = By.CssSelector(".motors-heading-used-cars");
        private By resultsBy = By.CssSelector("li.tmm-search-card-list-view div.tmm-search-card-list-view__card");
        private By selectedCarBy(string year, string make, string model) => By.XPath($"//*[contains(text(), '{year} {make} {model}')]//ancestor::a[@class='tmm-search-card-list-view__link']");
        private By carMakeBy(string make) => By.XPath($"//*[text()='{make}']");
        private By numberPlateBy = By.XPath("//*[text()='Number plate']/ancestor::*[@class='key-details-attribute-label']/following-sibling::div//span");
        private By carDetailsBy = By.CssSelector(".key-details-attribute-label");
        private By carDetailValueBy => By.CssSelector(".motors-attribute-value");

        private IWebElement headerUsedCars => Webdriver.FindElement(usedCarsBy, 5);
        private IList<IWebElement> listResults => Webdriver.FindElements(resultsBy, 5);
        private IWebElement lnkSelectedCar(string year, string make, string model) => Webdriver.FindElement(selectedCarBy(year, make, model), 5);
        private IWebElement lnkCarMake(string make) => Webdriver.FindElement(carMakeBy(make), 10);
        private IList<IWebElement> listlblCarDetails => Webdriver.FindElements(carDetailsBy, 5);
        

        public void AccessURL()
        {
            Webdriver.Navigate().GoToUrl(strURL);
            IsPageDisplayed();
        }

        public void SelectCarInListing(string year, string make, string model)
        {
            lnkSelectedCar(year, make, model).Click();

        }

        public void IsCarMakeDisplayed(string make)
        {
            Assert.IsTrue(lnkCarMake(make).Displayed, $"Test Failed: Car Make {make} is NOT displayed.");
        }

        public void IsThereAListingDisplayed()
        {
            Assert.IsTrue(listResults.Count >= 1, "Test Failed: There is no listing results displayed.");
        }

        public void IsCarDetailsCorrect(CarDO car)
        {
            if (listlblCarDetails.Count >= 1)
            {
                var webCar = GetCarDetails(car.CarName);
                Assert.AreEqual(car.NumberPlate, webCar.NumberPlate, "Test Failed: Number Plate displayed as expected.");
                Assert.AreEqual(car.Kilometres, webCar.Kilometres, "Test Failed: Kilometres is not displayed as expected.");
                Assert.AreEqual(car.Body, webCar.Body, "Test Failed: Body is not displayed as expected.");
                Assert.AreEqual(car.Seats, webCar.Seats, "Test Failed: Seats are not displayed as expected.");
                Assert.AreEqual(car.FuelType, webCar.FuelType, "Test Failed: Fuel Type is not displayed as expected.");
                Assert.AreEqual(car.Engine, webCar.Engine, "Test Failed: Engine is not displayed as expected.");
                Assert.AreEqual(car.Transmission, webCar.Transmission, "Test Failed: Transmission is not displayed as expected.");
                Assert.AreEqual(car.History, webCar.History, "Test Failed: History is not displayed as expected.");
                Assert.AreEqual(car.RegistrationExpires, webCar.RegistrationExpires, "Test Failed: Registration Expires is not displayed as expected.");
                Assert.AreEqual(car.WoFExpires, webCar.WoFExpires, "Test Failed: WoF Expires is not displayed as expected.");
                Assert.AreEqual(car.ModelDetail, webCar.ModelDetail, "Test Failed: Model Details is not displayed as expected.");
            }
            else
                Assert.Fail("Test Failed: Car Details page is not displayed.");
        }

        public void IsPageDisplayed()
        {
            Assert.IsTrue(strURL.Contains(Webdriver.Url), "Test Failed: URL is not correct.");
            Assert.IsTrue(headerUsedCars.Displayed, "Test Failed: Motors side Header is not displayed");
        }

        private string GetCarDetailsByKey(string key)
        {
            foreach (IWebElement carDetailLabel in listlblCarDetails)
            {
                if (carDetailLabel.GetAttribute("innerHTML").ToUpper().Contains(key.ToUpper()))
                {
                    IWebElement nextSibling = (IWebElement)((IJavaScriptExecutor)Webdriver).ExecuteScript("return arguments[0].nextSibling;", carDetailLabel);
                    return nextSibling.FindElement(carDetailValueBy).GetAttribute("outerText");
                }
            }
            return string.Empty;
        }

        private CarDO GetCarDetails(string carName)
        {
            var carDetails = new CarDO();
            carDetails.CarName = carName;
            carDetails.NumberPlate = GetCarDetailsByKey("Number plate");
            carDetails.Kilometres = GetCarDetailsByKey("Kilometres");
            carDetails.Body = GetCarDetailsByKey("Body");
            carDetails.Seats = GetCarDetailsByKey("Seats");
            carDetails.FuelType = GetCarDetailsByKey("Fuel type");
            carDetails.Engine = GetCarDetailsByKey("Engine");
            carDetails.Transmission = GetCarDetailsByKey("Transmission");
            carDetails.History = GetCarDetailsByKey("History");
            carDetails.RegistrationExpires = GetCarDetailsByKey("Registration expires");
            carDetails.WoFExpires = GetCarDetailsByKey("WoF expires");
            carDetails.ModelDetail = GetCarDetailsByKey("Model detail");
            return carDetails;
        }
    }
}