using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData newData = new ContactData("FirstName", "LastName");
            newData.MiddleName = "TestMiddleName";
            newData.NickName = "TestNickName";
            newData.LastName = "TestLastName";
            newData.Title = "TestTitle";
            newData.Company = "TestCompany";
            newData.Address = "TestAddress";
            newData.Home = "77799988800";
            newData.Mobile = "77799988877";
            newData.Work = "888988899";
            newData.Fax = "909888999";
            newData.Email = "email@mail.com";
            newData.Email2 = "email2@mail.com";
            newData.Email3 = "email3@mail.com";
            newData.Homepage = "homepage.com";
            newData.Birthday = new DateTime(1990, 8, 9);
            newData.Anniversary = new DateTime(2000, 1, 30);
            newData.SecondAddress = "TestSecondAddress";
            newData.SecondHome = "TestSecondHome";
            newData.Notes = "TestNotes";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.InitContactCreation();
            app.Contacts.Create(newData);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            oldContacts.Add(newData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}