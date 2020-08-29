using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> _contactCache = null;
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

        public ContactHelper Modify(ContactData contact, int index)
        {
            InitContactModification(index);
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
            _contactCache = null;
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a"))
                .Click();
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            _contactCache = null;
            return this;
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            _contactCache = null;
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

            SelectOption(By.Name("bday"), contactData.Birthday.Day.ToString());
            SelectOption(By.Name("bmonth"), contactData.Birthday.ToString("MMMM"));
            Type(By.Name("byear"), contactData.Birthday.Year.ToString());
            SelectOption(By.Name("aday"), contactData.Anniversary.Day.ToString());
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

        public bool IsAnyContactExist()
        {
            return IsElementPresent(By.XPath("//img[@title='Edit']"));
        }

        public List<ContactData> GetContactList()
        {
            if (_contactCache == null)
            {
                _contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> contactLastNames = driver.FindElements(By.XPath("//*[@id='maintable']//td[2]"));
                ICollection<IWebElement> contactFirstNames = driver.FindElements(By.XPath("//*[@id='maintable']//td[3]"));

                var fullContactNames = contactLastNames
                    .Zip(contactFirstNames, (f, l)
                        => new {LastName = l, FirstName = f});

                foreach (var contact in fullContactNames)
                {
                    _contactCache.Add(new ContactData(contact.LastName.Text, contact.FirstName.Text)
                    {
                        Id = contact.LastName.FindElement(By.XPath("..//td[1]//input")).GetAttribute("id")
                    });
                }
            }

            return new List<ContactData>(_contactCache);
        }
        
        public int GetContactCount()
        {
            return (driver.FindElements(By.CssSelector("tr")).Count - 1);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };

        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            
            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone, 
                Work = workPhone
            };
        }
    }
}