using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase

    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("fff");
            app.Groups.Modify(newData,1);
        }
    }
}