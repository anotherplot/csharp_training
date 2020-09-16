using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsRemovalTests : ContactTestBase
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
            List<ContactData> oldContacts = ContactData.GetAll();
            var toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);
            
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            
            oldContacts.RemoveAt(0);
            List<ContactData> newContacts = ContactData.GetAll();
            
            Assert.AreEqual(oldContacts,newContacts);
            
            foreach (var contact in newContacts)
            {  Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
            
        }
    }
}