using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void InitProjectCreation()
        {
           manager.Menu.SelectManageOverviewOption();
           manager.Menu.SelectProjectManageTab();
           manager.driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
        }

        public void Create(ProjectData project)
        {
            FillProjectForm(project);
            SubmitProjectCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.Url.Contains("manage_proj_page.php"));

        }

        private void SubmitProjectCreation()
        {
            manager.driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"),project.Name);
            Type(By.Id("project-description"),project.Description);
        }

        public int GetProjectCount()
        {
           // return manager.driver.FindElements(By.XPath("//table[@class='table_results ajax pma_table']/tbody/tr")).Count;
           return driver.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php?project_id')]")).Count;
        }
    }
}