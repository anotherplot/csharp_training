using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationInView()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string fromView = app.Contacts.GetContactInformationFromView(0);

            string formData = GetFormDataInString(fromForm);

            Assert.AreEqual(formData, fromView);
        }

        private string GetFormDataInString(ContactData contact)
        {
            var name = $"{contact.FirstName} {contact.MiddleName} {contact.LastName}\n";
            var phones =
                $"H: {contact.CleanUp(contact.Home)}M: {contact.CleanUp(contact.Mobile)}W: {contact.CleanUp(contact.Work)}F: {contact.CleanUp(contact.Fax)}\n";
            var emails = $"{contact.Email}\n{contact.Email2}\n{contact.Email3}\n";
            var homePage = $"Homepage:\n{contact.Homepage}\n\n";
            var birthDate =
                $"Birthday {contact.Birthday.Day.ToString()}. {contact.Birthday:MMMM} {contact.Birthday.Year.ToString()} ({contact.CountYears(contact.Birthday)})\n";
            var anniversaryDate =
                $"Anniversary {contact.Anniversary.Day.ToString()}. {contact.Anniversary:MMMM} {contact.Anniversary.Year.ToString()} ({contact.CountYears(contact.Anniversary)})\n\n";
            var secondPhone = $"P: {contact.SecondHomePhone}\n\n";
            var result = name + contact.NickName + "\n" + contact.Title + "\n" + contact.Company + "\n" +
                         contact.Address + "\n\n" + phones +
                         emails + homePage +
                         birthDate + anniversaryDate + contact.SecondAddress + "\n\n" + secondPhone + contact.Notes;
            return result;
        }
    }
}