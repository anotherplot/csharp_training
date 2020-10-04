using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData
    {
        [Column(Name = "name")] public string Name { get; set; }
        [Column(Name = "description")] public string Description { get; set; }
        
        [Column(Name = "enabled")] public byte Enabled { get; set; }
        
        [Column(Name = "id"),PrimaryKey,Identity] public int Id { get; set; }
        
        public static List<ProjectData> GetAll()
        {
            DataConnection.DefaultSettings = new MySettings();
            using MantisDB db = new MantisDB();
            return (from c in db.Projects.Where(x => x.Enabled == 1) select c).ToList();
        }
    }
}