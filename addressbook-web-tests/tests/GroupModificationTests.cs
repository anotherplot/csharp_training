using System.Collections.Generic;
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
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            
            app.Groups.Modify(newData, 0);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
            foreach (var group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name,group.Name);
                }
            }
        }
    }
}