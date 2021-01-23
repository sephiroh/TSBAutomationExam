using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSBAutomationExam.Pages
{
    public class BasePage
    {
        public IWebDriver Webdriver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Webdriver = driver;
        }

        public T As<T>() where T : BasePage
        {
            return (T)this;
        }

        public void Quit()
        {
            if (Webdriver != null)
                Webdriver.Quit();
        }

        public void Close()
        {
            try
            {
                Webdriver.Close();
            }
            catch (WebDriverException)
            {
            }
        }
    }
}