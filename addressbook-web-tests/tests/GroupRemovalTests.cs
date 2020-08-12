using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .DeleteGroup()
                .ReturnToGroupsPage();
        }
    }
}