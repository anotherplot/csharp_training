using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }
        
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}