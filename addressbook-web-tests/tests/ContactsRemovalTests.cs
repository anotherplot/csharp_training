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
            app.Contacts.Remove(1);
        }
    }
}