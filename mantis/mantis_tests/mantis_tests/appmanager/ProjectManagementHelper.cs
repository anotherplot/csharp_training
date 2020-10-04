using OpenQA.Selenium;

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
            // ProceedAfterCreation();
        
        }

        private void ProceedAfterCreation()
        {
            throw new System.NotImplementedException();
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

        public double GetProjectCount()
        {
            throw new System.NotImplementedException();
        }
    }
}