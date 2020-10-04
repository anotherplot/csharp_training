using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        private ProjectData _project;
       
        [SetUp]
        public void RandomProjectDataProvider()
        {
           _project = new ProjectData()
            {
                Name = GenerateRandomString(10),
                Description = GenerateRandomString(100),
            };
        }

        [Test]
        public void ProjectCreationTest()
        {
            // List<ProjectData> oldProjects = ProjectData.GetAll();

            app.Projects.InitProjectCreation();
            app.Projects.Create(_project);
            // Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectCount());
            //
            // oldProjects.Add(newData);
            // List<ProjectData> newContacts = ProjectData.GetAll();
            // oldProjects.Sort();
            // newContacts.Sort();
            // Assert.AreEqual(oldProjects, newContacts);
        }
    }
}