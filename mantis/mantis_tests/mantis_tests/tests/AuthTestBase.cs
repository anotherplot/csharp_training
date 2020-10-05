using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        protected const string Login = "administrator";
        protected const string Password = "root";
        
        
        [SetUp]
        public void SetUpLogin()
        {
            app.Auth.Login(new AccountData()
            {
                Name = Login,
                Password = Password
            });
        }
    }
}