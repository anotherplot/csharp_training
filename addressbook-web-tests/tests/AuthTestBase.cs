using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetUpLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}