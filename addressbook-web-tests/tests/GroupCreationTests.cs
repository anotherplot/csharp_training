using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData newData = new GroupData("groupName");
            newData.Header = "groupHeader";
            newData.Footer = "groupFooter";
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            var oldData = oldGroups[0];
            app.Groups.Create(newData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            oldGroups.Add(newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData newData = new GroupData("");
            newData.Header = "";
            newData.Footer = "";
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            var oldData = oldGroups[0];
            
            app.Groups.Create(newData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            
            oldGroups.Add(newData);
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }
    }
}