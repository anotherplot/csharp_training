using System;

namespace WebAddressBookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>

    {
        private string name;
        private string header;
        private string footer;

        public string Header
        {
            get => header;
            set => header = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Footer
        {
            get => footer;
            set => footer = value;
        }

        public GroupData(string name)
        {
            this.name = name;
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
            return "name = " + Name;
        }
    }
}