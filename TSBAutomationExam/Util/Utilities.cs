using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TSBAutomationExam.DataObjects;

namespace TSBAutomationExam.Util
{
    public static class Utilities
    {
        public static string BaseDirectory => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
        public static string TestDataFolder => Path.Combine(BaseDirectory, "Util\\");

        public static CarDO GetCarDetails(string carName)
        {
            var carDetailsCSVPath = Path.Combine(TestDataFolder, "CarDetails.csv");
            IList<CarDO> carDetails = ReadInCSV<CarDO>(carDetailsCSVPath);
            return carDetails.Where(_ => _.CarName == carName).FirstOrDefault();
        }

        public static AuthDO GetAuthDetails(string type)
        {
            var authDetailsCSVPath = Path.Combine(TestDataFolder, "AuthDetails.csv");
            IList<AuthDO> authDetails = ReadInCSV<AuthDO>(authDetailsCSVPath);
            return authDetails.Where(_ => _.Type == type).FirstOrDefault();
        }

        /// <summary>
        /// Read in CSV File, and return object based on the specified type 'T'
        /// </summary>
        /// <param name="csvPath">CSV Path on where the CSV File resides</param>
        private static List<T> ReadInCSV<T>(string csvPath)
        {
            List<T> records = new List<T>();
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<T>().ToList();
            }
            return records;
        }

        /// <summary>
        /// Extension method of FindElement to include wait time
        /// </summary>
        /// <param name="driver">Webdriver</param>
        /// <param name="by">Webelement find 'By'</param>
        /// <param name="waitSeconds">Seconds to wait (optional)</param>
        public static IWebElement FindElement(this IWebDriver driver, By by, int waitSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
                return driver.FindElement(by);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Element with locator:{by} is not found!");
                return null;
            }
        }

        /// <summary>
        /// Extension method of FindElements to include wait time
        /// </summary>
        /// <param name="driver">Webdriver</param>
        /// <param name="by">Webelement find 'By'</param>
        /// <param name="waitSeconds">Seconds to wait (optional)</param>
        public static IList<IWebElement> FindElements(this IWebDriver driver, By by, int waitSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
                return driver.FindElements(by);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Elements with locator:{by} are not found!");
                return null;
            }
        }

    }
}
