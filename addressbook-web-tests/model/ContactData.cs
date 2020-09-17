using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _contactDataInViewForm;
        private string _allEmails;
        
        [Column(Name = "firstname")] public string FirstName { get; set; }
        [Column(Name = "middlename")] public string MiddleName { get; set; }
        [Column(Name = "lastname")] public string LastName { get; set; }
        [Column(Name = "nickname")] public string NickName { get; set; }
        [Column(Name = "title")] public string Title { get; set; }
        [Column(Name = "company")] public string Company { get; set; }
        [Column(Name = "address")] public string Address { get; set; }
        [Column(Name = "home")] public string Home { get; set; }
        [Column(Name = "work")] public string Work { get; set; }
        [Column(Name = "deprecated")] public string Deprecated { get; set; }

        public string AllPhones
        {
            get => _allPhones ?? (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(SecondHomePhone)).Trim();
            set => _allPhones = value;
        }

        [Column(Name = "mobile")] public string Mobile { get; set; }
        [Column(Name = "fax")] public string Fax { get; set; }
        [Column(Name = "email")] public string Email { get; set; }
        [Column(Name = "email2")] public string Email2 { get; set; }
        [Column(Name = "email3")] public string Email3 { get; set; }
        [Column(Name = "homepage")] public string Homepage { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Anniversary { get; set; }
        [Column(Name = "address2")] public string SecondAddress { get; set; }
        [Column(Name = "phone2")] public string SecondHomePhone { get; set; }
        [Column(Name = "notes")] public string Notes { get; set; }
        [Column(Name = "id"),PrimaryKey,Identity] public string Id { get; set; }

        public string AllEmails {  
            
            get => _allEmails ?? (AddNewLine(Email) + AddNewLine(Email2) + AddNewLine(Email3)).Trim();
            set => _allEmails = value; }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
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
            return String.Format("lastname = {0}, firstname = {1}, middleName = {2}, address = {3}, email = {4}, workPhone = {5}, birthday = {6}",
                LastName, FirstName, MiddleName, Address, Email, Work, Birthday);
        }

        public string CleanUp(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return "";
            }

            return Regex.Replace(phone, "[ -()]", "") + "\n";
        }
        
        private string AddNewLine(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "";
            }

            return email + "\n";
        }

        public int CountYears(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        public static List<ContactData> GetAll()
        {
            DataConnection.DefaultSettings = new MySettings();
            using AddressBookDb db = new AddressBookDb();
            return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
        }
    }
}
