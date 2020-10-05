using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            app.Menu.GoToProjectsList();
            if (!app.Projects.IsAnyProjectExist())
            {
                var project = new ProjectData()
                {
                    Name = "FirstProject",
                    Description = "some description",
                };
                await app.API.CreateProject(project, Login, Password);
                app.Projects.WaitForProjectToBeDisplayed(project.Name);
            }
        }

        [Test]
        public void ProjectRemovalTest()
        {
            List<ProjectData> oldProjects = APIHelper.GetAllProjects(Login, Password);
            var toBeRemoved = oldProjects[0];

            app.Projects.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());
            oldProjects.RemoveAt(0);
            List<ProjectData> newProjects = APIHelper.GetAllProjects(Login, Password);
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