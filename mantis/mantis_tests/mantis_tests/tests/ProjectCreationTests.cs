using System;
using System.Collections.Generic;
using System.Linq;
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
            };
        }

        [Test]
        public void ProjectCreationTest()
        {
             List<ProjectData> oldProjects = ProjectData.GetAll();

            app.Projects.InitProjectCreation();
            app.Projects.Create(_project);
           
            
            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectCount());
            
            oldProjects.Add(_project);
            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}