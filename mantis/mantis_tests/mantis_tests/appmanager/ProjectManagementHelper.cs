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

        private void InitProjectCreation()
        {
            manager.driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
        }

        public void Create(ProjectData project)
        {
            InitProjectCreation();
            FillProjectForm(project);
            ClickSubmitButton();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.Url.Contains("manage_proj_page.php"));

        }

        private void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"),project.Name);
            Type(By.Id("project-description"),project.Description);
            SelectOption(By.Id("project-status"), project.Status.ToString());
            SelectOption(By.Id("project-view-state"), project.State.ToString());
        }

        public int GetProjectCount()
        {
           return driver.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php?project_id')]")).Count;
        }

        public void Remove(ProjectData toBeRemoved)
        {
            SelectProject(toBeRemoved.Id);
            RemoveProject();
            ClickSubmitButton();
        }

        private void SelectProject(int id)
        {
            driver.FindElement(By.XPath($"//a[@href='manage_proj_edit_page.php?project_id={id}']")).Click();
        }

        private void RemoveProject()
        {
           driver.FindElement(By.Id("project-delete-form")).Click();
        }

        public bool IsAnyProjectExist()
        {
            return IsElementPresent(By.XPath("//a[contains(@href,'manage_proj_edit_page.php?project_id')]"));
        }
    }
}