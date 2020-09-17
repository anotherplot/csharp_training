using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            IEnumerable<ContactData> contactsNotInGroup = ContactData.GetAll().Except(oldList);
            if (!contactsNotInGroup.Any())
            {
                app.Contacts.InitContactCreation();
                app.Contacts.Create(new ContactData("test","contact"));
            }
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactDataToGroup(contact, group);
            
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList,newList);
            
        }
    }
}