namespace selenium_specflow_c_sharp.Locators
{
    public class LoginLocators
    {
        public static string userTextbox = "//input[@id='user-name']";
        public static string passwordTextbox = "//input[@id='password']";
        public static string loginButton = "//input[@id='login-button']";
        public static string errorMessage = "//div[@id='login_button_container']/div/form/div[3]";
    }
}
