using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
                Status = GenerateRandomProjectStatus(),
                State = GenerateRandomProjectViewState()
            };
        }


        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldProjects = APIHelper.GetAllProjects(Login, Password);

            app.Menu.GoToProjectsList();
            app.Projects.Create(_project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectCount());

            oldProjects.Add(_project);
            List<ProjectData> newProjects = APIHelper.GetAllProjects(Login, Password);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}