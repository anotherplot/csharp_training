using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillLoginData(account.Name, "username");
            SubmitLoginData();
            FillLoginData(account.Password,"password");
            SubmitLoginData();
        }
        private void SubmitLoginData()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        private void FillLoginData(string accountData, string loginField)
        {
            driver.FindElement(By.CssSelector($"input[id='{loginField}']")).SendKeys(accountData);
        }
        
        private void OpenMainPage()
        {
            manager.driver.Url = "http://localhost/mantisbt-2.24.3/mantisbt-2.24.3/login_page.php";
        }
    }
}