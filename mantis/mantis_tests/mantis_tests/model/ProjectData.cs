using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        [Column(Name = "name")] public string Name { get; set; }
        [Column(Name = "description")] public string Description { get; set; }

        [Column(Name = "id"),PrimaryKey,Identity] public int Id { get; set; }
        
        public int Status { get; set; }
        
        public int State { get; set; }
        
        public static List<ProjectData> GetAll()
        {
            DataConnection.DefaultSettings = new MySettings();
            using MantisDB db = new MantisDB();
            return (from c in db.Projects select c).ToList();
        }

        public bool Equals(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            return Name.CompareTo(other.Name);
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name + "\n" + "description = " + Description;
        }
        
       public enum StatusType
        {
            Development = 10,
            Released = 30,
            Stable = 50,
            Obsolete = 70
        }    
       
       public enum ViewState
        {
            Public = 10,
            Private = 50
        }
    }
}