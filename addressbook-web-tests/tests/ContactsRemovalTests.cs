using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsRemovalTests : AuthTestBase
    {
        [SetUp]
        public void SetUp()
        {
            if (!app.Contacts.IsAnyContactExist())
            {
                app.Contacts.InitContactCreation();
                app.Contacts.Create(new ContactData("contact", "name"));
            }
        }

        [Test]
        public void ContactsRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            
            Assert.AreEqual(oldContacts,newContacts);
            
            foreach (var contact in newContacts)
            {  Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
            
        }
    }
}