using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                    {
                        Header = GenerateRandomString(100),
                        Footer = GenerateRandomString(100)
                    }
                );
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData newData)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            var oldData = oldGroups[0];
            app.Groups.Create(newData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            oldGroups.Add(newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}