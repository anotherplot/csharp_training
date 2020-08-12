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
            newData.Header = "eee";
            newData.Footer = "lll";
            
            app.Groups.Modify(newData,1);
        }
    }
}