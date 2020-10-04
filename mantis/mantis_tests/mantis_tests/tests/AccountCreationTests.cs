using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests: TestBase
    {

        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php",FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php",localFile);
            }
            
        }

        [Test]
        public void AccountCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "test@r.r"
            };

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}