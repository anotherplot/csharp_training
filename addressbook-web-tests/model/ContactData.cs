using System;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private string title;
        private string company;
        private string address;
        private string telephone;
        private string home;
        private string work;
        private string mobile;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private DateTime birthday;
        private DateTime anniversary;
        private string secondAddress;
        private string secondHome;
        private string notes;
        
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string MiddleName
        {
            get => middleName;
            set => middleName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string NickName
        {
            get => nickName;
            set => nickName = value;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Company
        {
            get => company;
            set => company = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        public string Home
        {
            get => home;
            set => home = value;
        }

        public string Work
        {
            get => work;
            set => work = value;
        }

        public string Mobile
        {
            get => mobile;
            set => mobile = value;
        }

        public string Fax
        {
            get => fax;
            set => fax = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Email2
        {
            get => email2;
            set => email2 = value;
        }

        public string Email3
        {
            get => email3;
            set => email3 = value;
        }

        public string Homepage
        {
            get => homepage;
            set => homepage = value;
        }

        public DateTime Birthday
        {
            get => birthday;
            set => birthday = value;
        }
        
        public DateTime Anniversary
        {
            get => anniversary;
            set => anniversary = value;
        }

        public string SecondAddress
        {
            get => secondAddress;
            set => secondAddress = value;
        }

        public string SecondHome
        {
            get => secondHome;
            set => secondHome = value;
        }

        public string Notes
        {
            get => notes;
            set => notes = value;
        }

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public ContactData(string firstName, string middleName, string lastName, string nickName, string title, string company, string address, string telephone, string home, string work, string mobile, string fax, string email, string email2, string email3, string homepage, DateTime birthday, DateTime anniversary, string secondAddress, string secondHome, string notes)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.nickName = nickName;
            this.title = title;
            this.company = company;
            this.address = address;
            this.telephone = telephone;
            this.home = home;
            this.work = work;
            this.mobile = mobile;
            this.fax = fax;
            this.email = email;
            this.email2 = email2;
            this.email3 = email3;
            this.homepage = homepage;
            this.birthday = birthday;
            this.anniversary = anniversary;
            this.secondAddress = secondAddress;
            this.secondHome = secondHome;
            this.notes = notes;
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
    }
}