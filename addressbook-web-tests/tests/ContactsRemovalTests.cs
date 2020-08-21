using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactsRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}