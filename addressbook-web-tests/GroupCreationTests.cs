using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("groupName");
            group.Header = "groupHeader";
            group.Footer = "groupFooter";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
    }
}