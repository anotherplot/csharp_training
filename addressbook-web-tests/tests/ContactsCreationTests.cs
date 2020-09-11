using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                    {
                        MiddleName = GenerateRandomString(100),
                        Address = GenerateRandomString(100),
                        Email = GenerateRandomString(10) + "@" + GenerateRandomString(5) + ".com",
                        Work = GenerateRandomPhoneNumber(10),
                        Birthday = GenerateRandomDateInPast(50),
                    }
                );
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>) new XmlSerializer(typeof(List<ContactData>)).Deserialize(
                new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData newData)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.InitContactCreation();
            app.Contacts.Create(newData);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            oldContacts.Add(newData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}