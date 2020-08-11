using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseUrl) : base(driver)
        {
            this.baseURL = baseUrl;
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