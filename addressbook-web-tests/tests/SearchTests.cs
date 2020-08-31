using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            Console.WriteLine(app.Contacts.GetNumberOfResults());
        }
    }
}