using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsRemovalTests : TestBase
    {
        [Test]
        public void ContactsRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}