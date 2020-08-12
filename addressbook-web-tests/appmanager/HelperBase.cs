using OpenQA.Selenium;

namespace WebAddressBookTests
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
    }
}