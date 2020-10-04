using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        public IWebDriver driver;

        protected string baseURL;

        public string BaseUrl => baseURL;
        
        public IWebDriver Driver => driver;
        
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8080";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstanse = new ApplicationManager();
                newInstanse.driver.Url = "http://localhost/mantisbt-2.24.3/mantisbt-2.24.3/login_page.php";
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