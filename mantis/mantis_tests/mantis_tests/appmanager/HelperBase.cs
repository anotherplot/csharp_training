using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        protected HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.driver;
        }

        protected void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        protected void ClickSubmitButton()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        protected void SelectOption(By locator, string option)
        {
            if (option != null)
            {
                driver.FindElement(locator).Click();
                new SelectElement(driver.FindElement(locator)).SelectByValue(option);
            }
        }
        
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}