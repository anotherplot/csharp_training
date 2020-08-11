using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}