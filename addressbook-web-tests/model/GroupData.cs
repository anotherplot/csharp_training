using System;

namespace WebAddressBookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>

    {
        public string Header { get; set; }
        public string Name { get; set; }
        public string Footer { get; set; }
        public string Id { get; set; }

        public GroupData(string name)
        {
            Name = name;
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