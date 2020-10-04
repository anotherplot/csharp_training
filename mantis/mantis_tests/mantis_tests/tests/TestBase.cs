using System;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static Random rnd = new Random();

        [OneTimeSetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }        
        
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }

        protected int GenerateRandomProjectStatus()
        {
            Array values = Enum.GetValues(typeof(ProjectData.StatusType));
            return (int) values.GetValue(rnd.Next(values.Length));
        }      
        protected int GenerateRandomProjectViewState()
        {
            Array values = Enum.GetValues(typeof(ProjectData.ViewState));
            return (int) values.GetValue(rnd.Next(values.Length));
        }
        
        [OneTimeTearDown]
        public void TearDownDriver()
        {
           app.driver.Quit();
        }
    }
}