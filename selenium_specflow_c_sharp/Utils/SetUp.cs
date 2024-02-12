using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace selenium_specflow_c_sharp.Utils
{
    public class SetUp
    {
        IWebDriver driver;
        public static WebDriverWait wait;
        public static string browser;
        public static bool driverInstanceExists = false;
        public static IWebDriver driverInstance = null;

        public IWebDriver getDriver(string browser)
        {
            if (driverInstanceExists)
            {
                driver = driverInstance;
            }
            else
            {
                driver = createDriver(browser);
            }

            driverInstanceExists = true;
            driverInstance = driver;
            SetUp.browser = browser;

            Console.WriteLine("Browser: " + SetUp.browser);

            return driver;
        }

        private IWebDriver createDriver(string browser)
        {
            Console.WriteLine("OS: " + getOSName());

            if (browser.Equals("Chrome"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                //chromeOptions.AddArgument("--remote-allow-origins=*");
                //chromeOptions.AddArguments("--no-sandbox");
                chromeOptions.AddArguments("--headless");
                chromeOptions.AddArgument("--start-maximized");

                if (getOSName().Equals("Windows"))
                    driver = new ChromeDriver(chromeOptions);
                else if (getOSName().Equals("Linux"))
                {
                    chromeOptions.BinaryLocation = ConstantData.chromeDriverPathLinux;
                    driver = new ChromeDriver(chromeOptions);
                }
            }
            else if (browser.Equals("Firefox"))
            {
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArguments("--headless");
                firefoxOptions.AddArgument("--start-maximized");


                if (getOSName().Equals("Windows"))
                    driver = new FirefoxDriver(firefoxOptions);
                else if (getOSName().Equals("Linux"))
                {
                    firefoxOptions.BinaryLocation = ConstantData.geckoDriverPathLinux;
                    driver = new FirefoxDriver(firefoxOptions);
                }
            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return driver;
        }

        private string getOSName()
        {
            string osName = "";

            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                osName = "Windows";
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                osName = "Linux";

            return osName;
        }

        public static void quitDriver()
        {
            IWebDriver currentChromeDriver;

            if (driverInstanceExists)
            {
                currentChromeDriver = driverInstance;
                currentChromeDriver.Quit();
            }

            driverInstanceExists = false;
            driverInstance = null;
        }
    }
}
