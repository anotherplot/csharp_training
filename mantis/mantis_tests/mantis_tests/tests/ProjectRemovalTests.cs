using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        
        [SetUp]
        public void SetUp()
        {
            app.Menu.GoToProjectsList();
            if (!app.Projects.IsAnyProjectExist())
            {
                app.Projects.Create(new ProjectData(){Name = "FirstProject"});
            }
        }
        
        [Test]
        public void ProjectRemovalTest()
        {
            List<ProjectData> oldProjects = ProjectData.GetAll();
            var toBeRemoved = oldProjects[0];

            app.Projects.Remove(toBeRemoved);
            
            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());
            oldProjects.RemoveAt(0);
            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            foreach (var project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }

        }
    }
}