using OpenQA.Selenium;
using WebAddressBookTests;

namespace addressbook_web_tests.appmanager
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact, int p)
        {
            InitContactModification(p);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            SelectContact(index);
            RemoveContact();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int p)
        {
            driver.FindElement(By.XPath($"//a[@href='edit.php?id={p}']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        public void FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("middlename"), contactData.MiddleName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("nickname"), contactData.NickName);
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.Home);
            Type(By.Name("mobile"), contactData.Mobile);
            Type(By.Name("work"), contactData.Work);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("homepage"), contactData.Homepage);
            
            SelectOption( By.Name("bday"), contactData.Birthday.Day.ToString());
            SelectOption( By.Name("bmonth"), contactData.Birthday.ToString("MMMM"));
            Type(By.Name("byear"), contactData.Birthday.Year.ToString());
            SelectOption( By.Name("aday"), contactData.Anniversary.Day.ToString());
            SelectOption(By.Name("amonth"), contactData.Anniversary.ToString("MMMM"));
            Type(By.Name("ayear"), contactData.Anniversary.Year.ToString());
            
            Type(By.Name("address2"), contactData.SecondAddress);
            Type(By.Name("phone2"), contactData.SecondHome);
            Type(By.Name("notes"), contactData.Notes);
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}