using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mantis_tests.Mantis;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public static List<ProjectData> GetAllProjects(string login, string password)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            var projects = client.mc_projects_get_user_accessible(login, password);
            List<ProjectData> result = new List<ProjectData>();
            foreach (var project in projects)
            {
                result.Add(new ProjectData()
                {
                    Id = Convert.ToInt32(project.id),
                    Name = project.name,
                    Description = project.description,
                    Status = Convert.ToInt32(project.status.id),
                    State = Convert.ToInt32(project.view_state.id)
                });
            }

            return result;
        }
    }
}