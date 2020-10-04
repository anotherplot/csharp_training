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

        public LoginHelper Auth { get; set; }
        public ProjectManagementHelper Projects { get; set; }
        public ManagementMenuHelper Menu { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.24.3/mantisbt-2.24.3/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Auth = new LoginHelper(this);
            Menu = new ManagementMenuHelper(this);
            Projects = new ProjectManagementHelper(this);
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
    }
}