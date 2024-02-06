using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace selenium_specflow_c_sharp.Utils
{
    public class BasePage
    {
        protected static IWebDriver driver;
        private static Actions action;

        public BasePage(string browser)
        {
            SetUp setUp = new SetUp();
            driver = setUp.getDriver(browser);
        }

        private IWebElement getElementBy(By elementLocator)
        {
            return SetUp.wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }

        public List<IWebElement> getAllElements(By elementLocator)
        {
            return new List<IWebElement>(driver.FindElements(elementLocator));
        }

        public void navigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void clickElement(By elementLocator)
        {
            getElementBy(elementLocator).Click();
        }

        public void writeText(By elementLocator, string text)
        {
            getElementBy(elementLocator).Clear();
            getElementBy(elementLocator).SendKeys(text);
        }

        public void clickElementFromList(IWebElement element)
        {
            element.Click();
        }

        public string getElementText(By elementLocator)
        {
            return getElementBy(elementLocator).Text;
        }

        public void goToLinkText(string linkText)
        {
            driver.FindElement(By.LinkText(linkText));
        }

        public void selectFromDropDownByValue(By elementLocator, string valueToSelect)
        {
            SelectElement dropdown = new SelectElement(getElementBy(elementLocator));
            dropdown.SelectByValue(valueToSelect);
        }

        public void selectFromDropDownByIndex(By elementLocator, int valueToSelect)
        {
            SelectElement dropdown = new SelectElement(getElementBy(elementLocator));
            dropdown.SelectByIndex(valueToSelect);
        }

        public void selectFromDropDownByText(By elementLocator, string valueToSelect)
        {
            SelectElement dropdown = new SelectElement(getElementBy(elementLocator));
            dropdown.SelectByText(valueToSelect);
        }

        public void hoverOverElement(By elementLocator)
        {
            action.MoveToElement(getElementBy(elementLocator));
        }

        public void doubleClick(By elementLocator)
        {
            action.DoubleClick(getElementBy(elementLocator));
        }

        public void rightClick(By elementLocator)
        {
            action.ContextClick(getElementBy(elementLocator));
        }

        public string getValueFromTable(By elementLocator, int row, int column)
        {
            string cell = elementLocator + "/table/tbody/tr[" + row + "]/td[" + column + "]";

            Console.WriteLine("Cell locator: " + cell);

            return getElementBy(By.XPath(cell)).Text;
        }

        public void setValueOnTable(By elementLocator, int row, int column, string value)
        {
            String cell = elementLocator + "/table/tbody/tr[" + row + "]/td[" + column + "]";

            getElementBy(By.XPath(cell)).SendKeys(value);
        }

        public void switchToiFrame(int iFrameIndex)
        {
            driver.SwitchTo().Frame(iFrameIndex);
        }

        public void switchToParentFrame()
        {
            driver.SwitchTo().ParentFrame();
        }

        public void dismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void waitUntilElementLocated(By locatorType, int maxWaitSec)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitSec));

            wait.Until(ExpectedConditions.ElementIsVisible(locatorType));
        }

        public bool elementIsDisplayed(By locatorType)
        {
            return getElementBy(locatorType).Displayed;
        }

        public bool elementIsSelected(By locatorType)
        {
            return getElementBy(locatorType).Selected;
        }

        public bool elementIsEnabled(By locatorType)
        {
            return getElementBy(locatorType).Enabled;
        }
    }
}
