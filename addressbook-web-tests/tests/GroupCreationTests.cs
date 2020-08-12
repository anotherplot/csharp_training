using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("groupName");
            group.Header = "groupHeader";
            group.Footer = "groupFooter";
            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
        }
    }
}