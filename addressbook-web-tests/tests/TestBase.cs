using addressbook_web_tests.appmanager;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}