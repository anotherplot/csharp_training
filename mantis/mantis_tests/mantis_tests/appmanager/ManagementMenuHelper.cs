using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }
        
        public void SelectManageOverviewOption()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'/manage_overview_page.php')]")).Click();
        }        
        public void SelectProjectManageTab()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'/manage_proj_page.php')]")).Click();
        }
    }
}