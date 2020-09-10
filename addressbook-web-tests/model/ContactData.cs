using System;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _allPhones;
        private string _contactDataInViewForm;
        private string _allEmails;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }

        public string AllPhones
        {
            get => _allPhones ?? (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(SecondHomePhone)).Trim();
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
        public string SecondHomePhone { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }
        
        public string ContactDataInViewForm
        {
            get
            {
                if (_contactDataInViewForm == null)
                {
                    var name = $"{FirstName} {MiddleName} {LastName}\n";
                    var phones = $"H: {CleanUp(Home)}M: {CleanUp(Mobile)}W: {CleanUp(Work)}F: {CleanUp(Fax)}\n";
                    var emails = $"{Email}\n{Email2}\n{Email3}\n";
                    var homePage = $"Homepage:\n{Homepage}\n\n";
                    var birthDate =
                        $"Birthday {Birthday.Day.ToString()}. {Birthday:MMMM} {Birthday.Year.ToString()} ({CountYears(Birthday)})\n";
                    var anniversaryDate =
                        $"Anniversary {Anniversary.Day.ToString()}. {Anniversary:MMMM} {Anniversary.Year.ToString()} ({CountYears(Anniversary)})\n\n";
                    var secondPhone = $"P: {SecondHomePhone}\n\n";
                    var result = name + NickName + "\n" + Title + "\n" + Company + "\n" + Address + "\n\n" + phones +
                                 emails + homePage +
                                 birthDate + anniversaryDate + SecondAddress + "\n\n" + secondPhone + Notes;
                    return result;
                }

                return _contactDataInViewForm;
            }

            set => _contactDataInViewForm = value;
        }

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

        private string CleanUp(string phone)
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

        private int CountYears(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
