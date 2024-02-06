using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_specflow_c_sharp.Locators
{
    public class CheckoutLocators
    {
        public static string checkoutButton = "//button[@id='checkout']";
        public static string txtFirstName = "//input[@placeholder='First Name']";
        public static string txtLastName = "//input[@placeholder='Last Name']";
        public static string txtZipCode = "//input[@placeholder='Zip/Postal Code']";
        public static string continueButton = "//input[@name='continue']";
        public static string subtotal = "//div[@class='summary_subtotal_label']";
        public static string finishButton = "//button[@id='finish']";
        public static string orderTitle = "//h2[@class='complete-header']";
        public static string orderMessage = "//div[@class='complete-text']";
        public static string backToHomeButton = "//button[@id='back-to-products']";
    }
}
