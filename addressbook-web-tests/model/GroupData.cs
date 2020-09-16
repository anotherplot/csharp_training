using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>

    {
        [Column(Name = "group_name")] public string Name { get; set; }
        [Column(Name = "group_header")] public string Header { get; set; }
        [Column(Name = "group_footer")] public string Footer { get; set; }
        [Column(Name = "group_id"),PrimaryKey,Identity] public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            DataConnection.DefaultSettings = new MySettings();
            using AddressBookDb db = new AddressBookDb();
            return (from g in db.Groups select g).ToList();
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public GroupData()
        {
        }

        public bool Equals(GroupData other)
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

        public int CompareTo(GroupData other)
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
            return "name = " + Name + "\n" + "header = " + Header + "\n" + "footer = " + Footer;
        }
    }
}