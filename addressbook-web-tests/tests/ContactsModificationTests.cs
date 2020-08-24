using System;
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
            ContactData contact = new ContactData("new", "data");
            contact.MiddleName = "new";
            contact.LastName = "new";
            contact.Title = "new";
            contact.Company = "new";
            contact.Address = "new";
            contact.Telephone = "new";
            contact.Home = "new";
            contact.Mobile = "new";
            contact.Work = "new";
            contact.Fax = "999";
            contact.Email = "new@mail.com";
            contact.Email2 = "new@mail.com";
            contact.Email3 = "new@mail.com";
            contact.Homepage = "newhomepage.com";
            contact.Birthday = new DateTime(1992, 8, 9);
            contact.Anniversary = new DateTime(2021, 1, 30);
            contact.SecondAddress = "new";
            contact.SecondHome = "new";
            contact.Notes = "new";
            app.Contacts.Modify(contact);
            
        }
    }
}