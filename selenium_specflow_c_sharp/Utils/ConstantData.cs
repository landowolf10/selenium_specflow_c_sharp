using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_specflow_c_sharp.Utils
{
    public class ConstantData
    {
        public static String chromeDriverPathWindows = "C:\\Users\\orlan\\Documents\\Projects\\Automation\\Selenium\\selenium_specflow_c_sharp\\selenium_specflow_c_sharp\\Utils\\Drivers\\chromedriver.exe";
        public static String chromeDriverPathLinux = "./Utils/Drivers/chromedriver";
        public static String geckoDriverPathWindows = "./src/test/resources/drivers/geckodriver.exe";
        public static String geckoDriverPathLinux = "./Utils/Drivers/geckodriver";
        public static String URL = "https://www.saucedemo.com";
    }
}
