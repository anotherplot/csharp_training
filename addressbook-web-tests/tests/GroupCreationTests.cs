using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using LinqToDB.Data;
using Newtonsoft.Json;
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(
                new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData newData)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(newData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            oldGroups.Add(newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            var fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            Console.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            DataConnection.DefaultSettings = new MySettings();

            AddressBookDb db = new AddressBookDb();

            var fromDb = (from g in db.Groups select g).ToList();

            end = DateTime.Now;
            Console.WriteLine(end.Subtract(start));
            db.Close();
        }
    }
}