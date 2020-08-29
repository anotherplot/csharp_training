using System;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
        public string AllPhones {
            get => _allPhones ?? (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
            set => _allPhones = value;
        }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Anniversary { get; set; }
        public string SecondAddress { get; set; }
        public string SecondHome { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }
        
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
                return 1;
            int compareLastName = LastName.CompareTo(other.LastName);
            return compareLastName == 0
                ? FirstName.CompareTo(other.FirstName)
                : compareLastName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() + FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname = " + LastName + ", firstname = " + FirstName;
        }
        
        private string CleanUp(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }

            return phone.Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "") + "\n";
        }
    }
}