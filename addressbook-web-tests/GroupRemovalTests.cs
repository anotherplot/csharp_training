using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "http://localhost:8080/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
        }

        private void DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        private void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])["+index+"]")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData accountData)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(accountData.Username);
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(accountData.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        
        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}