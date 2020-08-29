using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsModificationTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            if (!app.Contacts.IsAnyContactExist())
            {
                app.Contacts.InitContactCreation();
                app.Contacts.Create(new ContactData("contact","name"));
            }
        }
        
        [Test]
        public void ContactsModificationTest()
        {
            ContactData newData = new ContactData("new", "data");
            newData.MiddleName = "new";
            newData.LastName = "new";
            newData.Title = "new";
            newData.Company = "new";
            newData.Address = "new";
            newData.Home = "new";
            newData.Mobile = "new";
            newData.Work = "new";
            newData.Fax = "999";
            newData.Email = "new@mail.com";
            newData.Email2 = "new@mail.com";
            newData.Email3 = "new@mail.com";
            newData.Homepage = "newhomepage.com";
            newData.Birthday = new DateTime(1992, 8, 9);
            newData.Anniversary = new DateTime(2021, 1, 30);
            newData.SecondAddress = "new";
            newData.SecondHome = "new";
            newData.Notes = "new";
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(newData,0);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts,newContacts);
            
            foreach (var contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.FirstName,contact.FirstName);
                    Assert.AreEqual(newData.LastName,contact.LastName);
                }
            }
            
        }
    }
}