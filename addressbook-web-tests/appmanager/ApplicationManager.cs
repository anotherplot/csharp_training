using System;
using System.Threading;
using addressbook_web_tests.appmanager;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressBookTests
{
    public class ApplicationManager
    {
        public IWebDriver driver;

        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public LoginHelper Auth => loginHelper;
        public NavigationHelper Navigator => navigationHelper;
        public GroupHelper Groups => groupHelper;
        public ContactHelper Contacts => contactHelper;
        public IWebDriver Driver => driver;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "http://localhost:8080/addressbook";
            
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstanse = new ApplicationManager();
                newInstanse.Navigator.GoToHomePage();
                app.Value = newInstanse;
            }

            return app.Value;
        }
        
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}