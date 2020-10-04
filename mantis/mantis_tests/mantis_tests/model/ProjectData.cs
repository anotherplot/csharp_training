using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public static List<ProjectData> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}