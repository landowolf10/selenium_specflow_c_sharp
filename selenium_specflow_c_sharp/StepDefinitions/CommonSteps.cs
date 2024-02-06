using Gherkin.Ast;
using selenium_specflow_c_sharp.Pages;
using selenium_specflow_c_sharp.Utils;
using TechTalk.SpecFlow;

namespace selenium_specflow_c_sharp.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        LoginPage loginPage;

        [Given(@"I navigate to SauceLab demo page ""(.*)""")]
        public void navigateTo(string browser)
        {
            loginPage = new LoginPage(browser);
            loginPage.navigateToSauceLab();
        }

        [AfterScenario]
        public void closeDriver()
        {
            SetUp.quitDriver();
        }

        /*[AfterStep]
        public void screenShot(Scenario scenario)
        {
            takeScreenShot(scenario);
        }*/
    }
}