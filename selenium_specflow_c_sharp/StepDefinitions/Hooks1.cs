using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_specflow_c_sharp.Utils;
using TechTalk.SpecFlow;

namespace selenium_specflow_c_sharp.StepDefinitions
{
    [Binding]
    public sealed class Hooks1
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromeOptions);
        }

        [Given("I have navigated to youtube website")]
        public void navigateTo()
        {
            driver.Navigate().GoToUrl(ConstantData.URL);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}