using OpenQA.Selenium;
using selenium_specflow_c_sharp.Locators;
using selenium_specflow_c_sharp.Utils;

namespace selenium_specflow_c_sharp.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(string browser) : base(browser)
        {
        }

        public void navigateToSauceLab()
        {
            navigateTo(ConstantData.URL);
        }

        public void writeCredentials(string email, string password)
        {
            writeText(By.XPath(LoginLocators.userTextbox), email);
            writeText(By.XPath(LoginLocators.passwordTextbox), password);
        }

        public void clickLoginButton()
        {
            clickElement(By.XPath(LoginLocators.loginButton));
        }

        public Dictionary<string, bool> getValidLoginElements()
        {
            Dictionary<string, bool> presentElements = new Dictionary<string, bool>();

            try
            {
                presentElements.Add("cart_icon", elementIsDisplayed(By.XPath(DashboardLocators.cartIcon)));
                presentElements.Add("drop_down", elementIsDisplayed(By.XPath(DashboardLocators.sortDropDown)));
            }
            catch (TimeoutException e)
            {
                presentElements.Add("cart_icon", false);
                presentElements.Add("drop_down", false);
                Console.WriteLine(e.ToString());
            }

            return presentElements;
        }

        public Dictionary<string, bool> getInvalidLoginElements()
        {
            Dictionary<string, bool> presentElements = new Dictionary<string, bool>();

            presentElements.Add("login_button", elementIsDisplayed(By.XPath(LoginLocators.loginButton)));
            presentElements.Add("error_message", elementIsDisplayed(By.XPath(LoginLocators.errorMessage)));

            return presentElements;
        }


        public string getErrorMessageText()
        {
            return getElementText(By.XPath(LoginLocators.errorMessage));
        }
    }
}
