using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            
            Assert.AreEqual(fromTable,fromForm);
            Assert.AreEqual(fromTable.Address,fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones,fromForm.AllPhones);
        }       
        
        [Test]
        public void TestContactInformationInView()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string fromView = app.Contacts.GetContactInformationFromView(0);

            Console.WriteLine(fromView);
            
            // Assert.AreEqual(fromTable,fromForm);
            // Assert.AreEqual(fromTable.Address,fromForm.Address);
            // Assert.AreEqual(fromTable.AllPhones,fromForm.AllPhones);
        }
        
        
    }
}