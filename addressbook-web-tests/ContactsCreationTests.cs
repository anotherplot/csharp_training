using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactsCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            ContactData contact = new ContactData("FirstName", "LastName");
            contact.MiddleName = "TestMiddleName";
            contact.NickName = "TestNickName";
            contact.LastName = "TestLastName";
            contact.Title = "TestTitle";
            contact.Company = "TestCompany";
            contact.Address = "TestAddress";
            contact.Telephone = "70099988800";
            contact.Home = "77799988800";
            contact.Mobile = "77799988877";
            contact.Work = "888988899";
            contact.Fax = "909888999";
            contact.Email = "email@mail.com";
            contact.Email2 = "email2@mail.com";
            contact.Email3 = "email3@mail.com";
            contact.Homepage = "homepage.com";
            contact.Birthday = new DateTime(1990, 8, 9);
            contact.Anniversary = new DateTime(2000, 1, 30);
            contact.SecondAddress = "TestSecondAddress";
            contact.SecondHome = "TestSecondHome";
            contact.Notes = "TestNotes";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
        }
    }
}