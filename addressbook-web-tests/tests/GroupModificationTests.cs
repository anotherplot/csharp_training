using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase

    {
        [SetUp]
        public void SetUp()
        {
            if (!app.Groups.IsAnyGroupExist())
            {
                app.Groups.Create(new GroupData("sds"));
            }
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("fff");
            app.Groups.Modify(newData, 1);
        }
    }
}