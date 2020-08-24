using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
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
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
        }
    }
}