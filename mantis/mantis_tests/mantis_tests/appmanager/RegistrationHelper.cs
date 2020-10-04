using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            ClickSubmitButton();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'signup_page.php')]")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.driver.Url = "http://localhost/mantisbt-2.24.3/mantisbt-2.24.3/login_page.php";
        }
    }
}