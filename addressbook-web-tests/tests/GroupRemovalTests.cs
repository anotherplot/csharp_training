using System.Collections.Generic;
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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups,newGroups);

            foreach (var group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}