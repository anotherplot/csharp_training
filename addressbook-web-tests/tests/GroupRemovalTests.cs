using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
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
            List<GroupData> oldGroups = GroupData.GetAll();
            var toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);
    
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups,newGroups);

            foreach (var group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}