using NUnit.Framework;
using selenium_specflow_c_sharp.Pages;
using selenium_specflow_c_sharp.Utils;

namespace selenium_specflow_c_sharp.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        LoginPage loginPage = new LoginPage(SetUp.browser);

        [When(@"user types the username ""(.*)"" with password ""(.*)""")]
        public void typeCredentials(string user, string password)
        {
            loginPage.writeCredentials(user, password);
        }

        [When("press the login button")]
        public void pressLoginButton()
        {
            loginPage.clickLoginButton();
        }

        [Then("verify that the user successfully logged in")]
        public void verifySuccessfulLogin()
        {
            Assert.True(loginPage.getValidLoginElements()["cart_icon"]);
            Assert.True(loginPage.getValidLoginElements()["drop_down"]);
        }
    }
}