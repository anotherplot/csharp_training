using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase

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
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeChanged = oldGroups[0];
            
            app.Groups.Modify(newData, toBeChanged);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
            foreach (var group in newGroups)
            {
                if (group.Id == toBeChanged.Id)
                {
                    Assert.AreEqual(newData.Name,group.Name);
                }
            }
        }
    }
}