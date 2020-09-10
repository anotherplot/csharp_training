using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressBookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        private static void Main(string[] args)
        {
            string typeOfTestData = args[0];
            var count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            StreamWriter writer = new StreamWriter(filename);
            GenerateTestData(typeOfTestData, count, format, writer);
            writer.Close();
        }

        private static void GenerateTestData(string typeOfTestData, in int count, string format,
            StreamWriter streamWriter)
        {
            if (typeOfTestData.Equals("groups"))
            {
                GenerateGroupData(count, format, streamWriter);
            }
            else if (typeOfTestData.Equals("contacts"))
            {
                GenerateContactData(count, format, streamWriter);
            }
            else
            {
                Console.WriteLine("Unknown type of test data");
            }
        }

        private static void GenerateContactData(in int count, string format, StreamWriter streamWriter)
        {
            List<ContactData> contacts = new List<ContactData>();

            for (var i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Address = TestBase.GenerateRandomString(10),
                    Work = TestBase.GenerateRandomPhoneNumber(10)
                });
            }

            switch (format)
            {
                case "json":
                    WriteContactsToJsonFile(contacts, streamWriter);
                    break;
                case "xml":
                    WriteContactsToXmlFile(contacts, streamWriter);
                    break;
                default:
                    Console.WriteLine("Unknown type of file format");
                    break;
            }
        }

        private static void GenerateGroupData(int count, string format, StreamWriter streamWriter)
        {
            List<GroupData> groups = new List<GroupData>();

            for (var i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

            switch (format)
            {
                case "json":
                    WriteGroupsToJsonFile(groups, streamWriter);
                    break;
                case "xml":
                    WriteGroupsToXmlFile(groups, streamWriter);
                    break;
                case "csv":
                    WriteGroupsToCsvFile(groups, streamWriter);
                    break;
                default:
                    Console.WriteLine("Unknown type of file format");
                    break;
            }
        }

        private static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteLine("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer);
            }
        }

        private static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        private static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }

        private static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
        }

        private static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}