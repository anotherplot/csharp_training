using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();
            
            var account = new AccountData("admin","secret");
            app.Auth.Login(account);
            
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }      
        
        [Test]
        public void LoginWithInValidCredentials()
        {
            app.Auth.Logout();
            
            var account = new AccountData("admin","134254");
            app.Auth.Login(account);
            
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}