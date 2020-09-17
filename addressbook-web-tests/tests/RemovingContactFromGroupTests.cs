using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count==0)
            {
                app.Contacts.AddContactDataToGroup(ContactData.GetAll()[0], group);
            }
            ContactData contactToBeRemoved = group.GetContacts()[0];
            
            app.Contacts.RemoveContactDataFromGroup(contactToBeRemoved, group);
            
            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactToBeRemoved);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList,newList);
        }
        
    }
}