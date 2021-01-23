using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;


namespace TSBAutomationExam.Util
{

    /// <summary>
    /// Class for creating WebDriver for various browsers.
    /// </summary>
    public class WebDriverFactory
    {
        /// <summary>
        /// Initilizes IWebDriver base on the given WebBrowser name.
        /// </summary>
        /// <param name="name">Web Browser name to be used</param>
        /// <returns></returns>
        public static IWebDriver CreateWebDriver(WebBrowser name)
        {
            switch (name)
            {
                case WebBrowser.Firefox:
                    FirefoxOptions firefoxOption = new FirefoxOptions();
                    firefoxOption.AcceptInsecureCertificates = true;
                    return new FirefoxDriver(Environment.CurrentDirectory, firefoxOption);
                case WebBrowser.IE:
                    InternetExplorerOptions ieOption = new InternetExplorerOptions();
                    ieOption.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieOption.EnsureCleanSession = true;
                    ieOption.RequireWindowFocus = true;
                    return new InternetExplorerDriver(Environment.CurrentDirectory, ieOption);
                //If Edge Version 18, run in CMD Admin first - DISM.exe /Online /Add-Capability /CapabilityName:Microsoft.WebDriver~~~~0.0.1.0
                case WebBrowser.Edge:
                    EdgeOptions options = new EdgeOptions();
                    options.UseInPrivateBrowsing = true;
                    return new EdgeDriver(Environment.CurrentDirectory, options);
                case WebBrowser.HeadlessChrome:
                    ChromeOptions headlessOptions = new ChromeOptions();
                    headlessOptions.AddUserProfilePreference("download.directory_upgrade", true);
                    headlessOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    headlessOptions.AddArgument("--headless");
                    headlessOptions.AddArgument("--no-sandbox");
                    headlessOptions.AddArgument("--disable-gpu");
                    headlessOptions.AddArgument("start-maximized");
                    headlessOptions.AddArgument("disable-infobars");
                    headlessOptions.AddArgument("--disable-extensions");
                    headlessOptions.AddArgument("--no-proxy-server");
                    headlessOptions.AddArgument("--proxy-server='direct://'");
                    headlessOptions.AddArgument("--proxy-bypass-list=*");
                    headlessOptions.AddArgument("--ignore-certificate-errors");
                    return new ChromeDriver(Environment.CurrentDirectory, headlessOptions);  
                case WebBrowser.Chrome:
                default:

                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("start-maximized");
                    chromeOptions.AddArgument("disable-infobars");
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    return new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
                    //return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(300));

            }
        }
    }
}


public enum WebBrowser
{
    IE,
    Edge,
    Firefox,
    Chrome,
    HeadlessChrome
}
